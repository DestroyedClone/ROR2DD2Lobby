using BepInEx;
using BepInEx.Configuration;
using R2API.Utils;
using RoR2;
using RoR2.UI;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Security.Permissions;
using UnityEngine;
using UnityEngine.UI;
using static DD2HUD.Assets;
using static DD2HUD.Main;

[module: UnverifiableCode]
#pragma warning disable CS0618 // Type or member is obsolete
[assembly: SecurityPermission(SecurityAction.RequestMinimum, SkipVerification = true)]
#pragma warning restore CS0618 // Type or member is obsolete

[assembly: HG.Reflection.SearchableAttribute.OptIn]

namespace DD2Lobby
{
    [BepInPlugin("com.DestroyedClone.DD2Lobby", "DD2Lobby Sotv", "1.0")]
    public class Main : BaseUnityPlugin
    {
        public static Dictionary<BodyIndex[], string> bodyIndices_to_teamName = new Dictionary<BodyIndex[], string>();

        private readonly bool DEBUG_addfakenetworkusers = false;

        internal static ConfigFile _config;

        public void Start()
        {
            _config = Config;

            if (DEBUG_addfakenetworkusers)
            {
                Logger.LogWarning("Debug mode is on, disable before compiling and uploading!");
                DD2LobbySetupComponent.debug = DEBUG_addfakenetworkusers;
            }

            //R2API.Utils.CommandHelper.AddToConsoleWhenReady();
            On.RoR2.UI.CharacterSelectController.Awake += AddDD2Component;
        }

        private void AddDD2Component(On.RoR2.UI.CharacterSelectController.orig_Awake orig, CharacterSelectController self)
        {
            orig(self);

            self.gameObject.AddComponent<DD2LobbySetupComponent>();
        }
    }

    public class ModCompatibility
    {
        //For some UI changes that we don't want to override for the player.
        public static bool compat_LobbyAppearanceImprovements = false;

        public static void CheckModCompatibility()
        {
            if (BepInEx.Bootstrap.Chainloader.PluginInfos.ContainsKey("com.DestroyedClone.LobbyAppearanceImprovements"))
            {
                compat_LobbyAppearanceImprovements = true;
            }
        }
    }

    public static class Configuration
    {
        public static ConfigEntry<bool> cfgModifyCharacterPosition;

        public static void SetupConfig()
        {
            cfgModifyCharacterPosition = Main._config.Bind("", "Modify Character Display Positions", true, "If true, then the character positions will be modified in the lobby.");
        }
    }
}