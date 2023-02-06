using BepInEx;
using BepInEx.Configuration;
using BepInEx.Logging;
using HG;
using R2API.Utils;
using RoR2;
using RoR2.UI;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Security.Permissions;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using static DD2HUD.Assets;
using static DD2HUD.Configuration;
using static DD2HUD.ModCompatibility;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using HG;
using UnityEngine;

[module: UnverifiableCode]
#pragma warning disable CS0618 // Type or member is obsolete
[assembly: SecurityPermission(SecurityAction.RequestMinimum, SkipVerification = true)]
#pragma warning restore CS0618 // Type or member is obsolete

[assembly: HG.Reflection.SearchableAttribute.OptIn]

namespace DD2HUD
{
    [BepInPlugin("com.DestroyedClone.DD2Lobby", "Darkest Dungeon 2 Lobby", "1.0.0")]
    //[BepInDependency(R2API.R2API.PluginGUID, R2API.R2API.PluginVersion)]
    [NetworkCompatibility(CompatibilityLevel.NoNeedForSync, VersionStrictness.DifferentModVersionsAreOk)]
    [BepInDependency("com.KingEnderBrine.ScrollableLobbyUI", BepInDependency.DependencyFlags.SoftDependency)]
    public class Main : BaseUnityPlugin
    {
        public static Dictionary<BodyIndex[], string> bodyIndices_to_teamName = new Dictionary<BodyIndex[], string>();

        public static readonly bool ENABLEDEBUGMODE = true;

        internal static ConfigFile _config;
        internal static ManualLogSource _logger;

        public void Start()
        {
            _config = Config;
            _logger = Logger;


            if (ENABLEDEBUGMODE)
            {
                _logger.LogWarning("Debug mode is on, disable before compiling and uploading!");
                On.RoR2.Networking.NetworkManagerSystemSteam.OnClientConnect += (s, u, t) => { };
            }
            Configuration.SetupConfig();
            ModCompatibility.CheckModCompatibility();

            On.RoR2.UI.CharacterSelectController.Awake += CharacterSelectController_Awake;
            On.RoR2.UI.CharacterSelectController.RebuildLocal += CharacterSelectController_RebuildLocal;
            if (ENABLEDEBUGMODE)
                On.RoR2.UI.CharacterSelectController.OnDisable += CharacterSelectController_OnDisable; //debugging
            if (cfgModifyCharacterOrder.Value)
            {
                On.RoR2.SurvivorMannequins.SurvivorMannequinDioramaController.UpdateSortedNetworkUsersList += SurvivorMannequinDioramaController_UpdateSortedNetworkUsersList;
            }
        }

        private void SurvivorMannequinDioramaController_UpdateSortedNetworkUsersList(On.RoR2.SurvivorMannequins.SurvivorMannequinDioramaController.orig_UpdateSortedNetworkUsersList orig, RoR2.SurvivorMannequins.SurvivorMannequinDioramaController self)
        {
            orig(self);
            self.sortedNetworkUsers.Clear();
            for (int i = 0; i < NetworkUser.readOnlyInstancesList.Count; i++)
            {
                ListUtils.AddIfUnique<NetworkUser>(self.sortedNetworkUsers, NetworkUser.readOnlyInstancesList[i]);
            }
        }

        //replacing SelectSurvivor
        private void CharacterSelectController_RebuildLocal(On.RoR2.UI.CharacterSelectController.orig_RebuildLocal orig, CharacterSelectController self)
        {
            orig(self);

            if (DD2LobbySetupComponent.instance)
            {
                DD2LobbySetupComponent.instance.UpdateTeamName(NetworkUser.instancesList[0].GetSurvivorPreference().survivorIndex);
            }
        }

        //replacing Start
        private void CharacterSelectController_Awake(On.RoR2.UI.CharacterSelectController.orig_Awake orig, CharacterSelectController self)
        {
            orig(self);
            self.gameObject.AddComponent<DD2LobbySetupComponent>();
            if (ENABLEDEBUGMODE)
                self.gameObject.AddComponent<DD2LobbyDebugComponent>();
        }

        private void CharacterSelectController_OnDisable(On.RoR2.UI.CharacterSelectController.orig_OnDisable orig, CharacterSelectController self)
        {
            orig(self);
            var netUsers = InstanceTracker.GetInstancesList<FakeNetworkUserMarker>();
            foreach (var user in netUsers.ToList())
            {
                Destroy(user.gameObject);
            }
        }

        [ConCommand(commandName = "dd2lobby_debug_setNetworkBodies", flags = ConVarFlags.None, helpText = "Dev only Command. Rank 1, Rank2, Rank 3, Rank 4. Rank 1 is ignored as its your playerslot")]
        private static void CCChangeNetworkBodies(ConCommandArgs args)
        {
            DD2LobbyDebugComponent.debug_characters = new string[]
            {
                args.GetArgString(0),
                args.GetArgString(1),
                args.GetArgString(2),
                args.GetArgString(3)
            };
            DD2LobbyDebugComponent.instance.UpdateTemporaryNetworkUsers();
            if (DD2LobbySetupComponent.instance)
            {
                DD2LobbySetupComponent.instance.UpdateTeamName(NetworkUser.instancesList[0].GetSurvivorPreference().survivorIndex);
            }

        }

        [RoR2.SystemInitializer(dependencies: new System.Type[]
        {
            typeof(BodyCatalog),
            typeof(RoR2.SurvivorCatalog),
            typeof(RoR2.MasterCatalog),
        })]
        public static void ConvertBodyNamesToBodyIndices()
        {
            return;
            foreach (var entry in characterNames_to_teamName)
            {
                List<BodyIndex> bodyIndices = new List<BodyIndex>();
                foreach (var bodyName in entry.Key)
                {
                    bodyIndices.Add(BodyCatalog.FindBodyIndex(bodyName));
                }
                bodyIndices_to_teamName.Add(bodyIndices.ToArray(), entry.Value);
            }

            var index = 0;
            foreach (var a in bodyIndices_to_teamName)
            {
                var text = $"{index} : ";
                foreach (var b in a.Key)
                {
                    text += $"{b}, ";
                }
                text += $"{a.Value}";
                _logger.LogMessage(text);
            }
            _logger.LogMessage($"Team Count: {bodyIndices_to_teamName.Count}");
        }

        public class FakeNetworkUserMarker : MonoBehaviour
        {
            public void OnEnable()
            { InstanceTracker.Add(this); }

            public void OnDisable()
            { InstanceTracker.Remove(this); _logger.LogMessage("Destroyed Fake User " + name); }
        }

        private class DD2LobbyDebugComponent : MonoBehaviour
        {
            public static DD2LobbyDebugComponent instance;
            public static bool debug = false;
            public float age = 0;
            private bool hasSetup = false;

            public static string[] debug_characters = new string[]
                {
                    "Bandit2Body",
                    "HuntressBody",
                    "LoaderBody",
                    "MercBody"
                };

            public void OnEnable()
            {
                instance = this;
            }
            public void OnDisable()
            {
                instance = null;
            }


            public ulong GetNetworkName(string bodyName)
            {
                switch (bodyName)
                {
                    case "CrocoBody": return 76561198124912729;
                    case "MageBody": return 76561198348262420;
                    case "Bandit2Body": return 76561198064142548;
                    case "Captain": return 76561198177832603;
                    case "CommandoBody": return 76561198115125395;
                    case "EngineerBody": return 76561197988953445;
                    case "HuntressBody": return 76561198210922492;
                    case "LoaderBody": return 76561198246537066;
                    case "MercBody": return 76561198198967470;
                    case "ToolbotBody": return 76561198069591654;
                    case "TreebotBody": return 76561198267390855;
                    default: return 76561197960447933;
                }
            }

            public void CreateTemporaryNetworkUsers()
            {
                if (!debug) return;
                GameObject meUser = LocalUserManager.GetFirstLocalUser().currentNetworkUser.gameObject;
                List<string> bodyNamesToCopy = new List<string>(DD2LobbyDebugComponent.debug_characters);
                bodyNamesToCopy.RemoveAt(0);
                foreach (string bodyName in bodyNamesToCopy)
                {
                    if (InstanceTracker.GetInstancesList<FakeNetworkUserMarker>().Count == 3)
                        break;
                    var copy = Instantiate(meUser);
                    var nU = copy.GetComponent<NetworkUser>();
                    nU.SetBodyPreference(BodyCatalog.FindBodyIndex(bodyName));
                    nU.id = new NetworkUserId()
                    {
                        value = GetNetworkName(bodyName)
                    };
                    copy.name = bodyName;
                    copy.AddComponent<FakeNetworkUserMarker>();
                    _logger.LogMessage($"Adding fake NetworkUser as {bodyName}");
                }
            }

            public void UpdateTemporaryNetworkUsers()
            {
                if (!debug) return;
                List<string> bodyNamesToCopy = new List<string>(DD2LobbyDebugComponent.debug_characters);
                bodyNamesToCopy.RemoveAt(0);
                var list = InstanceTracker.GetInstancesList<FakeNetworkUserMarker>();
                for (int i = 0; i < list.Count; i++)
                {
                    FakeNetworkUserMarker fakeNetworkUser = list[i];
                    string newBodyName = bodyNamesToCopy[i];
                    fakeNetworkUser.GetComponent<NetworkUser>().SetBodyPreference(BodyCatalog.FindBodyIndex(newBodyName));
                }
            }

            private void FixedUpdate()
            {
                if (hasSetup) return;
                age += Time.fixedDeltaTime;
                if (age > 0.35f)
                {
                    CreateTemporaryNetworkUsers();
                    hasSetup = true;
                }
            }

        }

        public class DD2LobbySetupComponent : MonoBehaviour
        {
            public float age = 0;
            public bool hasSetup = false;

            public float mp_age = 0;
            public bool mp_hasSetup = false;

            public bool btn_GetTeamName = false;
            public HGTextMeshProUGUI hgTMP;
            public CharacterSelectController characterSelectController;

            //public string teamText = "Sussimaximus";
            public HGTextMeshProUGUI theTMP;

            public static DD2LobbySetupComponent instance;

            private void OnEnable()
            {
                mp_hasSetup = RoR2Application.isInSinglePlayer;
                instance = this;
                NetworkUser.onLoadoutChangedGlobal += NetworkUser_onLoadoutChangedGlobal;
                UserProfile.onLoadoutChangedGlobal += UserProfile_onLoadoutChangedGlobal;
            }

            private void OnDisable()
            {
                instance = null;
                NetworkUser.onLoadoutChangedGlobal -= NetworkUser_onLoadoutChangedGlobal;
                UserProfile.onLoadoutChangedGlobal -= UserProfile_onLoadoutChangedGlobal;
            }

            private void NetworkUser_onLoadoutChangedGlobal(NetworkUser obj)
            { instance.NewSetup(); }

            private void UserProfile_onLoadoutChangedGlobal(UserProfile obj)
            { instance.NewSetup(); }

            private void FixedUpdate()
            {
                if (!hasSetup)
                {
                    age += Time.fixedDeltaTime;
                    if (age > 0.35f)
                    {
                        NewSetup();
                        hasSetup = true;
                    }
                }
                if (!mp_hasSetup)
                {
                    mp_age += Time.fixedDeltaTime;
                    if (age > 0.75f)
                    {
                        NewSetup();
                        mp_hasSetup = true;
                    }
                }
                if (btn_GetTeamName)
                {
                    //GetTeamName();
                    btn_GetTeamName = false;
                }
            }

            private string GetTeamName2(SurvivorIndex firstSurvivorIndex = SurvivorIndex.None)
            {
                var networkUsers = NetworkUser.readOnlyLocalPlayersList;

                List<string> bodyNames = new List<string>();
                List<BodyIndex> bodyIndices = new List<BodyIndex>();
                if (!DD2HUD.Main.ENABLEDEBUGMODE)
                {
                    if (networkUsers.Count <= 3)
                    {
                        return string.Empty;
                    }
                    foreach (var networkUser in networkUsers)
                    {
                        bodyIndices.Add(networkUser.NetworkbodyIndexPreference);
                        bodyNames.Add(BodyCatalog.GetBodyName(networkUser.NetworkbodyIndexPreference));
                    }
                }
                else
                {
                    bodyNames = DD2LobbyDebugComponent.debug_characters.ToList();
                    foreach (var bodyName in DD2LobbyDebugComponent.debug_characters)
                    {
                        bodyIndices.Add(BodyCatalog.FindBodyIndex(bodyName));
                    }
                }
                if (firstSurvivorIndex != SurvivorIndex.None)
                {
                    bodyIndices[0] = SurvivorCatalog.GetBodyIndexFromSurvivorIndex(firstSurvivorIndex);
                    bodyNames[0] = SurvivorCatalog.GetSurvivorDef(firstSurvivorIndex).bodyPrefab.name;
                }

                /*
                if (characterNames_to_teamName.TryGetValue(bodyNames.ToArray(), out string output))
                {
                    Debug.Log(output);
                }*/

                if (ENABLEDEBUGMODE)
                    foreach (var name in bodyNames)
                    {
                        _logger.LogMessage(name);
                    }

                foreach (var entry in characterNames_to_teamName)
                {
                    var key = entry.Key;
                    if (
                        key[0] == bodyNames[0] &&
                        key[1] == bodyNames[1] &&
                        key[2] == bodyNames[2] &&
                        key[3] == bodyNames[3]
                        )
                    {
                        return Language.GetString("DD2LOBBY_"+entry.Value);
                    }
                }
                return string.Empty;
            }

            private void UpdateTeamText(string newText)
            {
                hgTMP.enabled = false;
                hgTMP.text = newText;
                hgTMP.enabled = true;
            }

            //public Transform difficultySection;

            private void InitialHUDSetup()
            {
                //Flatten
                Transform leftHandPanel = characterSelectController.transform.Find("SafeArea/LeftHandPanel (Layer: Main)");
                leftHandPanel.GetComponent<VerticalLayoutGroup>().enabled = false;
                leftHandPanel.Find("BorderImage").gameObject.SetActive(false);
                leftHandPanel.eulerAngles = Vector3.zero;
                //Move Choices to center middle of screen
                Transform survivorChoiceGrid = leftHandPanel.Find("SurvivorChoiceGrid, Panel");
                survivorChoiceGrid.eulerAngles = Vector3.zero; //It Doesn't need, but might as well
                survivorChoiceGrid.position = new Vector3(0f, -45f, 100f); //def? 302.4 331.1 0 def: -59.8734 43.622 100
                survivorChoiceGrid.gameObject.SetActive(false);
                //Move info panel to right of screen
                Transform survivorInfoPanel = leftHandPanel.Find("SurvivorInfoPanel, Active (Layer: Secondary)");
                survivorInfoPanel.GetComponent<VerticalLayoutGroup>().enabled = false;
                survivorInfoPanel.transform.position = new Vector3(30, 32.14879f, 100);


                Transform survivorNamePanel = survivorInfoPanel.Find("SurvivorNamePanel");
                Transform survivorNamePanelClone = null;
                if (!theTMP || !hgTMP)
                    survivorNamePanelClone = Instantiate(survivorNamePanel, characterSelectController.transform);
                //SkillScrollContainer is missing so
                //ContentPanel (Overview, Skills, Loadout)/SkillScrollContainer/DescriptionPanel, Skill


                /* NORMALLY its: ContentPanel (Overview, Skills, Loadout)/SkillPanel/DescriptionPanel, Skill
                 * but with ScrollableLobbything its:
                 * ContentPanel (Overview, Skills, Loadout)/OverviewScrollPanel
                 * ContentPanel (Overview, Skills, Loadout)/LoadoutScrollContainer
                 * ContentPanel (Overview, Skills, Loadout)/SkillScrollContainer
                 * NONE! so....
                 * ContentPanel (Overview, Skills, Loadout)/OverviewScrollPanel/DescriptionPanel, Skill
                 */


                /*var skillDescPanel = survivorInfoPanel.Find("ContentPanel (Overview, Skills, Loadout)/SkillScrollContainer/DescriptionPanel, Skill");
                if (skillDescPanel && !skillDescPanel.GetComponent<DD2LobbyDescriptionTracksCursor>())
                    skillDescPanel.gameObject.AddComponent<DD2LobbyDescriptionTracksCursor>().lobbyDescTransform = skillDescPanel;*/

                Transform skillDescPanel;
                if (compat_ScrollableLobbyUI)
                {
                    //skillDescPanel = survivorInfoPanel.Find("ContentPanel (Overview, Skills, Loadout)/OverviewScrollPanel/DescriptionPanel, Skill");
                    skillDescPanel = survivorInfoPanel.Find("ContentPanel (Overview, Skills, Loadout)/SkillScrollContainer/DescriptionPanel, Skill");
                } else
                {
                    skillDescPanel = survivorInfoPanel.Find("ContentPanel (Overview, Skills, Loadout)/SkillPanel/DescriptionPanel, Skill");
                }
                if (skillDescPanel)
                    skillDescPanel.position = new Vector3(-50, 19.66f, 100);

                if (!theTMP)
                {
                    Transform theText = UnityEngine.Object.Instantiate(survivorNamePanelClone, survivorNamePanel);
                    theText.localPosition = new Vector3(70, 20, 0);
                    theText.name = "TheText";
                    theTMP = theText.Find("SurvivorName").GetComponent<HGTextMeshProUGUI>();
                    theTMP.text = "The";
                    theTMP.transform.localPosition = Vector3.zero;
                }

                Transform subheaderPanel = survivorInfoPanel.Find("SubheaderPanel (Overview, Skills, Loadout)");
                subheaderPanel.eulerAngles = new Vector3(0, 0, 270);
                subheaderPanel.position = new Vector3(100, 27, 100);

                RectTransform rightHandPanel = (RectTransform)characterSelectController.transform.Find("SafeArea/RightHandPanel");
                //rightHandPanel.position = new Vector3(0f, 63f, 100f);
                rightHandPanel.rotation = Quaternion.identity;
                rightHandPanel.localScale = Vector3.one * 0.8f;
                //rightHandPanel.position = new Vector3(20, -20, 100);
                Transform ruleVerticalLayout = rightHandPanel.Find("RuleVerticalLayout");
                ruleVerticalLayout.position = new Vector3(-75, 20, 100); //new Vector3(0f, 23f, 100f);
                ruleVerticalLayout.Find("BlurPanel").gameObject.SetActive(false);
                ruleVerticalLayout.Find("BorderImage").gameObject.SetActive(false);

                var ruleVerticalLayoutVertical = ruleVerticalLayout.Find("RuleBookViewerVertical");
                ruleVerticalLayoutVertical.GetComponent<Image>().enabled = false;
                //var difficultySection = ruleVerticalLayoutVertical.Find("Viewport/Content/RulebookCategoryPrefab(Clone)");
                //difficultySection.Find("/Header").gameObject.SetActive(false);
                ruleVerticalLayoutVertical.Find("Viewport/Content/RulebookCategoryPrefab(Clone)/Header").gameObject.SetActive(false);
                //SOTV: Has RuleCategoryController


                //difficultySection.parent = difficultySection.parent.parent; //(needs permanent reference)

                Transform readyPanel = characterSelectController.transform.Find("SafeArea/ReadyPanel");
                readyPanel.position = new Vector3(80, -45, 100);
                if (!hgTMP)
                {
                    Transform teamText = UnityEngine.Object.Instantiate(survivorNamePanelClone, readyPanel.parent); //really? you looked 2 in just to look 1 up, when you could just look 1 in???????
                    teamText.GetComponent<UnityEngine.UI.LayoutElement>().enabled = false;
                    teamText.localPosition = new Vector3(283, -370, 0);
                    teamText.localScale = Vector3.one * 2.5f;
                    teamText.name = "TeamText";
                    hgTMP = teamText.Find("SurvivorName").GetComponent<HGTextMeshProUGUI>();
                }

                var survivorTMP = survivorNamePanel.Find("SurvivorName").GetComponent<HGTextMeshProUGUI>();
                survivorTMP.transform.localScale = Vector3.one * 2f;

                Transform chatBox = characterSelectController.transform.Find("SafeArea/ChatboxPanel");
                chatBox.localPosition = new Vector3(-700, 305, 0);

                //no point, if we dont disable it theres a fuckhuge ugly blur square on the left
                /*if (!compat_LobbyAppearanceImprovements)
                {
                    leftHandPanel.Find("BlurPanel").gameObject.SetActive(false);
                }*/
                leftHandPanel.Find("BlurPanel").gameObject.SetActive(false);

                var readyButton = characterSelectController.readyButton.transform;
                readyButton.localScale = new Vector3(0.75f, 1f, 1f);
                readyButton.localPosition = new Vector3(450, -500, 0);

                var survivorName = characterSelectController.survivorName;


                if (survivorNamePanelClone)
                    Destroy(survivorNamePanelClone.gameObject);
                survivorChoiceGrid.gameObject.SetActive(true);
            }

            private void RepossitionHUD()
            {

            }

            private void RepositionCharacterPads()
            {
                if (!cfgModifyCharacterPosition.Value) return;
                if (!ENABLEDEBUGMODE && NetworkUser.readOnlyLocalPlayersList.Count <= 1)
                {
                    return;
                }
                var survivorMannequinDiorama = GameObject.Find("SurvivorMannequinDiorama");
                survivorMannequinDiorama.transform.rotation = Quaternion.Euler(new Vector3(0, 195, 0));
                //oldrot= 0 254.9986 0

                float index = 0;
                float xoffset = 1f;
                float zoffset = -0.25f;
                foreach (Transform child in survivorMannequinDiorama.transform)
                {
                    child.localPosition = new Vector3(index * xoffset, 0, index * zoffset);
                    index++;
                }
            }

            public void NewSetup(SurvivorIndex survivorIndex = SurvivorIndex.None)
            {
                characterSelectController = gameObject.GetComponent<CharacterSelectController>();
                InitialHUDSetup();
                RepositionCharacterPads();
                UpdateTeamName(survivorIndex);
            }

            public void UpdateTeamName(SurvivorIndex survivorIndex = SurvivorIndex.None)
            {
                UpdateTeamText(GetTeamName2(survivorIndex));
            }
        }
    }

    public class ModCompatibility
    {
        public static bool compat_LobbyAppearanceImprovements = false;
        public static bool compat_ScrollableLobbyUI = false;

        public static void CheckModCompatibility()
        {
            if (BepInEx.Bootstrap.Chainloader.PluginInfos.ContainsKey("com.DestroyedClone.LobbyAppearanceImprovements"))
            {
                compat_LobbyAppearanceImprovements = true;
            }

            if (BepInEx.Bootstrap.Chainloader.PluginInfos.ContainsKey("com.KingEnderBrine.ScrollableLobbyUI"))
            {
                compat_ScrollableLobbyUI = true;
            }
        }
    }

    public static class Configuration
    {
        public static ConfigEntry<bool> cfgModifyCharacterPosition;
        public static ConfigEntry<bool> cfgModifyCharacterOrder;

        public static void SetupConfig()
        {
            cfgModifyCharacterPosition = Main._config.Bind("", "Modify Character Display Positions", true, "If true, then the character positions will be modified in the lobby.");
            cfgModifyCharacterOrder = Main._config.Bind("", "Modify Character Display Order", true, "If true, then the order of the character displays will be changed to lobby join order.");
        }
    }
}