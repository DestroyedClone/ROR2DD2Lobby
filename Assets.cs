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
            { new string[]{ "CaptainBody", "CaptainBody", "CaptainBody", "CaptainBody" }, "4CAPTAIN" },
            { new string[]{ "CaptainBody", "CommandoBody", "CommandoBody", "LoaderBody" }, "UESAUTHORIZED" },
            { new string[]{ "CaptainBody", "EngineerBody", "PaladinBody", "EnforcerBody" }, "PROTECTORS" },
            { new string[]{ "CaptainBody", "MercBody", "CommandoBody", "MercBody" }, "BOYSCLUB" },
            #endregion

            #region CommandoBody
            { new string[]{ "CommandoBody", "CommandoBody", "CommandoBody", "CommandoBody" }, "4COMMANDO" },
            #endregion

            #region CrocoBody
            { new string[]{ "CrocoBody", "Bandit2Body", "LoaderBody", "MercBody" }, "SLICEDCLUB" },
            { new string[]{ "CrocoBody", "CrocoBody", "CrocoBody", "CrocoBody" }, "4CROCO" },
            #endregion

            #region Bandit2Body
            { new string[]{ "Bandit2Body", "CommandoBody", "EnforcerBody", "LoaderBody" }, "THEUNUSUALSUSPECTS" },
            { new string[]{ "Bandit2Body", "Bandit2Body", "Bandit2Body", "Bandit2Body" }, "4BANDIT2" },
            { new string[]{ "Bandit2Body", "HuntressBody", "LoaderBody", "MercBody" }, "REFORMEDCREW" },
            #endregion

            #region CrocoBody
            #endregion

            //engi
            { new string[]{ "EngiBody", "EngiBody", "EngiBody", "EngiBody" }, "4ENGI" },
            { new string[]{ "EngiBody", "ToolbotBody", "ToolbotBody", "ToolbotBody" }, "1ENGI3TOOLBOT" },

            //huntress
            { new string[]{ "HuntressBody", "HuntressBody", "HuntressBody", "HuntressBody" }, "4HUNTRESS" },

            //loader
            { new string[]{ "LoaderBody", "LoaderBody", "LoaderBody", "LoaderBody" }, "4LOADER" },

            //toolbot
            { new string[]{ "ToolbotBody", "ToolbotBody", "ToolbotBody", "ToolbotBody" }, "4TOOLBOT" },

            //merc
            { new string[]{ "MercBody", "MercBody", "MercBody", "MercBody" }, "4MERC" },

            //treebot
            { new string[]{ "TreebotBody", "TreebotBody", "TreebotBody", "TreebotBody" }, "4TREEBOT" },

            //railgunner
            { new string[]{ "RailgunnerBody", "RailgunnerBody", "RailgunnerBody", "RailgunnerBody" }, "4RAILGUNNER" },
            { new string[]{ "RailgunnerBody", "SniperClassicBody", "HuntressBody", "ToolbotBody" }, "CAMPINGCOHORTS" },

            //void survivor
            { new string[]{ "VoidSurvivorBody", "VoidSurvivorBody", "VoidSurvivorBody", "VoidSurvivorBody" }, "4VOIDSURVIVOR" },
            { new string[]{ "VoidSurvivorBody", "VoidSurvivorBody", "SS2UNemmandoBody", "CommandoBody" }, "MEMYSELFANDI" },


            //MageBody
            { new string[]{ "MageBody", "MageBody", "MageBody", "MageBody" }, "4MAGE" },
            { new string[]{ "MageBody", "HuntressBody", "LoaderBody", "RailgunnerBody" }, "SISTERSOFBATTLE" },

            //Sniper Classic
            { new string[]{ "SniperClassicBody", "SniperClassicBody", "SniperClassicBody", "SniperClassicBody" }, "4SNIPERCLASSIC" },
            { new string[]{ "SniperClassicBody", "MinerModBody", "CHEFBody", "EnforcerBody" }, "ABANDONEDADVENTURERS" },

            //Enforcer
            { new string[]{ "EnforcerBody", "EnforcerBody", "EnforcerBody", "EnforcerBody" }, "4ENFORCER" },

            //Miner
            { new string[]{ "MinerModBody", "MinerModBody", "MinerModBody", "MinerModBody" }, "4MINERMOD" },

            //RobPaladin
            { new string[]{ "RobPaladinBody", "RobPaladinBody", "RobPaladinBody", "RobPaladinBody" }, "4ROBPALADIN" },

            //chef
            { new string[]{ "ChefBody", "ChefBody", "ChefBody", "ChefBody" }, "4CHEF" },

            //handovercloekd
            { new string[]{ "HANDOverclockedBody", "HANDOverclockedBody", "HANDOverclockedBody", "HANDOverclockedBody" }, "4HANDOVERCLOCKED" },

            //Rocket
            { new string[]{ "RocketSurvivorBody", "RocketSurvivorBody", "RocketSurvivorBody", "RocketSurvivorBody" }, "4ROCKETSURVIVOR" },

            //imposter
            { new string[]{ "ImpostorBody", "ImpostorBody", "ImpostorBody", "ImpostorBody" }, "Among Us" },

            //Henry
            { new string[]{ "HenryBody", "HenryBody", "HenryBody", "HenryBody" }, "4HENRY" },

            //RMOR
            { new string[]{ "RMORBody", "RMORBody", "RMORBody", "RMORBody" }, "4RMOR" },

            //Tesla Trooper
            { new string[]{ "TeslaTrooperBody", "TeslaTrooperBody", "TeslaTrooperBody", "TeslaTrooperBody" }, "4TESLATROOPER" },
            { new string[]{ "TeslaTrooperBody", "DesolatorBody", "TeslaTrooperBody", "DesolatorBody" }, "TESDESTESDES" },

            //Desolator
            { new string[]{ "DesolatorBody", "DesolatorBody", "DesolatorBody", "DesolatorBody" }, "4DESOLATOR" },
        };
    }
}
