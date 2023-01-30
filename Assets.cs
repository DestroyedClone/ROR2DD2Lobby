using System;
using System.Collections.Generic;
using System.Text;

namespace DD2HUD
{
    internal static class Assets
    {        //{ new string[]{ "", "", "", "" }, "" },
        internal static Dictionary<string[], string> characterNames_to_teamName = new Dictionary<string[], string>()
        {
            // Todo: Organize
            // Category: Rank 4
            // Rank 4, RAnk 3, Rank 2, RAnk 1 : TeamName
            #region CaptainBody
            { new string[]{ "CaptainBody", "CaptainBody", "CaptainBody", "CaptainBody" }, "THECOMMITTEE" },
            { new string[]{ "CaptainBody", "CommandoBody", "CommandoBody", "LoaderBody" }, "UESAUTHORIZED" },
            { new string[]{ "CaptainBody", "EngineerBody", "PaladinBody", "EnforcerBody" }, "PROTECTORS" },
            { new string[]{ "CaptainBody", "MercBody", "CommandoBody", "MercBody" }, "BOYSCLUB" },
            #endregion

            #region CommandoBody
            { new string[]{ "CommandoBody", "CommandoBody", "CommandoBody", "CommandoBody" }, "IMMEASURABLENEWCOMERS" },
            #endregion

            #region CrocoBody
            { new string[]{ "CrocoBody", "Bandit2Body", "LoaderBody", "MercBody" }, "SLICEDCLUB" },
            { new string[]{ "CrocoBody", "CrocoBody", "CrocoBody", "CrocoBody" }, "THEKENNEL" },
            #endregion

            #region Bandit2Body
            { new string[]{ "Bandit2Body", "CommandoBody", "EnforcerBody", "LoaderBody" }, "THEUNUSUALSUSPECTS" },
            { new string[]{ "Bandit2Body", "Bandit2Body", "Bandit2Body", "Bandit2Body" }, "YEEHAW" },
            { new string[]{ "Bandit2Body", "HuntressBody", "LoaderBody", "MercBody" }, "REFORMEDCREW" },
            #endregion

            #region CrocoBody
            #endregion

            //unsorted
            // All survivors authorized to enter the rescue mission

            //MageBody
            { new string[]{ "MageBody", "MageBody", "MageBody", "MageBody" }, "HEFTYHEFTY" },
            { new string[]{ "MageBody", "HuntressBody", "LoaderBody", "RailgunnerBody" }, "SISTERSOFBATTLE" },

            // Modded
            { new string[]{ "RailgunnerBody", "SniperClassicBody", "HuntressBody", "ToolbotBody" }, "CAMPINGCOHORTS" },
            { new string[]{ "SniperClassicBody", "MinerModBody", "CHEFBody", "EnforcerBody" }, "ABANDONEDADVENTURERS" },
            { new string[]{ "EnforcerBody", "EnforcerBody", "EnforcerBody", "EnforcerBody" }, "POLICEBRUTALITY" },
            { new string[]{ "MinerModBody", "MinerModBody", "MinerModBody", "MinerModBody" }, "ROCKANDSTONE" },
        };
    }
}
