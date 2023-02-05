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
            { new string[]{ "CommandoBody", "CaptainBody", "CaptainBody", "CaptainBody" }, "1COMMANDO3CAPTAIN" },
            { new string[]{ "CommandoBody", "CrocoBody", "CrocoBody", "CrocoBody" }, "1COMMANDO3CROCO" },
            { new string[]{ "CommandoBody", "VoidSurvivorBody", "VoidSurvivorBody", "VoidSurvivorBody" }, "1COMMANDO3VOIDSURVIVOR" },
            #endregion

            #region CrocoBody
            { new string[]{ "CrocoBody", "Bandit2Body", "LoaderBody", "MercBody" }, "SLICEDCLUB" },
            { new string[]{ "CrocoBody", "CrocoBody", "CrocoBody", "CrocoBody" }, "4CROCO" },
            { new string[]{ "CrocoBody", "TreebotBody", "TreebotBody", "TreebotBody" }, "1CROCO3TREEBOT" },
            { new string[]{ "CrocoBody", "CommandoBody", "EngiBody", "ToolbotBody" }, "DEVOLUTION" },
            #endregion

            #region Bandit2Body
            { new string[]{ "Bandit2Body", "CommandoBody", "EnforcerBody", "LoaderBody" }, "THEUNUSUALSUSPECTS" },
            { new string[]{ "Bandit2Body", "Bandit2Body", "Bandit2Body", "Bandit2Body" }, "4BANDIT2" },
            { new string[]{ "Bandit2Body", "HuntressBody", "LoaderBody", "MercBody" }, "REFORMEDCREW" },
            { new string[]{ "Bandit2Body", "CommandoBody", "CommandoBody", "CommandoBody" }, "1BANDIT23COMMANDO" },
            { new string[]{ "Bandit2Body", "EnforcerBody", "EnforcerBody", "EnforcerBody" }, "1BANDIT23ENFORCER" },
            #endregion

            //engi
            { new string[]{ "EngiBody", "EngiBody", "EngiBody", "EngiBody" }, "4ENGI" },
            { new string[]{ "EngiBody", "ToolbotBody", "ToolbotBody", "ToolbotBody" }, "1ENGI3TOOLBOT" },
            { new string[]{ "EngiBody", "CommandoBody", "CommandoBody", "CommandoBody" }, "1ENGI3COMMANDO" },
            { new string[]{ "EngiBody", "LoaderBody", "ToolbotBody", "TreebotBody" }, "ENGIREPAIRSTEAM" },

            //huntress
            { new string[]{ "HuntressBody", "HuntressBody", "HuntressBody", "HuntressBody" }, "4HUNTRESS" },
            { new string[]{ "HuntressBody", "CrocoBody", "CrocoBody", "CrocoBody" }, "1HUNTRESS3CROCO" },
            { new string[]{ "HuntressBody", "CommandoBody", "HuntressBody", "CommandoBody" }, "DD2LOBBY_REDLINERAIDERS" },
            { new string[]{ "HuntressBody", "CaptainBody", "CaptainBody", "CaptainBody" }, "1HUNTRESS3CAPTAIN" },

            //loader
            { new string[]{ "LoaderBody", "LoaderBody", "LoaderBody", "LoaderBody" }, "4LOADER" },
            { new string[]{ "LoaderBody", "ToolbotBody", "ToolbotBody", "ToolbotBody" }, "1LOADER3TOOLBOT" },
            { new string[]{ "LoaderBody", "TreebotBody", "TreebotBody", "TreebotBody" }, "1LOADER3TREEBOT" },
            { new string[]{ "LoaderBody", "CommandoBody", "ToolbotBody", "CaptainBody" }, "SHOCKANDAWE" },

            //toolbot
            { new string[]{ "ToolbotBody", "ToolbotBody", "ToolbotBody", "ToolbotBody" }, "4TOOLBOT" },
            { new string[]{ "ToolbotBody", "LoaderBody", "LoaderBody", "LoaderBody" }, "1TOOLBOT3LOADER" },
            { new string[]{ "ToolbotBody", "CommandoBody", "CommandoBody", "CommandoBody" }, "1TOOLBOT3COMMANDO" },
            { new string[]{ "ToolbotBody", "HuntressBody", "HuntressBody", "HuntressBody" }, "1TOOLBOT3HUNTRESS" },

            //merc
            { new string[]{ "MercBody", "MercBody", "MercBody", "MercBody" }, "4MERC" },
            { new string[]{ "MercBody", "CrocoBody", "CrocoBody", "CrocoBody" }, "1MERC3CROCO" },

            //treebot
            { new string[]{ "TreebotBody", "TreebotBody", "TreebotBody", "TreebotBody" }, "4TREEBOT" },
            { new string[]{ "TreebotBody", "TreebotBody", "TreebotBody", "TreebotBody" }, "1TREEBOT3CROCO" },

            //railgunner
            { new string[]{ "RailgunnerBody", "RailgunnerBody", "RailgunnerBody", "RailgunnerBody" }, "4RAILGUNNER" },
            { new string[]{ "RailgunnerBody", "SniperClassicBody", "HuntressBody", "ToolbotBody" }, "CAMPINGCOHORTS" },

            //void survivor
            { new string[]{ "VoidSurvivorBody", "VoidSurvivorBody", "VoidSurvivorBody", "VoidSurvivorBody" }, "4VOIDSURVIVOR" },
            { new string[]{ "VoidSurvivorBody", "VoidSurvivorBody", "SS2UNemmandoBody", "CommandoBody" }, "MEMYSELFANDI" },


            //MageBody
            { new string[]{ "MageBody", "MageBody", "MageBody", "MageBody" }, "4MAGE" },
            { new string[]{ "MageBody", "HuntressBody", "LoaderBody", "RailgunnerBody" }, "SISTERSOFBATTLE" },
            { new string[]{ "MageBody", "CrocoBody", "CrocoBody", "CrocoBody" }, "1MAGE3CROCO" },

            //Sniper Classic
            { new string[]{ "SniperClassicBody", "SniperClassicBody", "SniperClassicBody", "SniperClassicBody" }, "4SNIPERCLASSIC" },
            { new string[]{ "SniperClassicBody", "MinerModBody", "CHEFBody", "EnforcerBody" }, "ABANDONEDADVENTURERS" },

            //Enforcer
            { new string[]{ "EnforcerBody", "EnforcerBody", "EnforcerBody", "EnforcerBody" }, "4ENFORCER" },
            { new string[]{ "EnforcerBody", "CrocoBody", "CrocoBody", "CrocoBody" }, "1ENFORCER3CROCO" },
            { new string[]{ "EnforcerBody", "CommandoBody", "CommandoBody", "CommandoBody" }, "1ENFORCER3COMMANDO" },

            //Miner
            { new string[]{ "MinerModBody", "MinerModBody", "MinerModBody", "MinerModBody" }, "4MINERMOD" },
            { new string[]{ "MinerModBody", "MinerModBody", "MinerModBody", "MercBody" }, "3MINERMOD1MERC" },

            //RobPaladin
            { new string[]{ "RobPaladinBody", "RobPaladinBody", "RobPaladinBody", "RobPaladinBody" }, "4ROBPALADIN" },
            { new string[]{ "RobPaladinBody", "CrocoBody", "CrocoBody", "CrocoBody" }, "1ROBPALADIN3CROCO" },

            //chef
            { new string[]{ "ChefBody", "ChefBody", "ChefBody", "ChefBody" }, "4CHEF" },
            { new string[]{ "ChefBody", "TreebotBody", "TreebotBody", "TreebotBody" }, "1CHEF3TREEBOT" },

            //handovercloekd
            { new string[]{ "HANDOverclockedBody", "HANDOverclockedBody", "HANDOverclockedBody", "HANDOverclockedBody" }, "4HANDOVERCLOCKED" },

            //Rocket
            { new string[]{ "RocketSurvivorBody", "RocketSurvivorBody", "RocketSurvivorBody", "RocketSurvivorBody" }, "4ROCKETSURVIVOR" },

            //imposter
            { new string[]{ "ImpostorBody", "ImpostorBody", "ImpostorBody", "ImpostorBody" }, "Among Us" },

            //Henry
            { new string[]{ "HenryBody", "HenryBody", "HenryBody", "HenryBody" }, "4HENRY" },
            { new string[]{ "HenryBody", "ChefBody", "MercBody", "LoaderBody" }, "DOJOFIGHTERS" },

            //RMOR
            { new string[]{ "RMORBody", "RMORBody", "RMORBody", "RMORBody" }, "4RMOR" },

            //Tesla Trooper
            { new string[]{ "TeslaTrooperBody", "TeslaTrooperBody", "TeslaTrooperBody", "TeslaTrooperBody" }, "4TESLATROOPER" },
            { new string[]{ "TeslaTrooperBody", "DesolatorBody", "TeslaTrooperBody", "DesolatorBody" }, "TESDESTESDES" },
            { new string[]{ "TeslaTrooperBody", "DesolatorBody", "TeslaTrooperBody", "DesolatorBody" }, "2TESLATROOPER2LOADER" },

            //Desolator
            { new string[]{ "DesolatorBody", "DesolatorBody", "DesolatorBody", "DesolatorBody" }, "4DESOLATOR" },

            //Regigigas
            { new string[]{ "RegigigasBody", "RegigigasBody", "RegigigasBody", "RegigigasBody" }, "4REGIGIGAS" },

            //Deputy
            { new string[]{ "Deputy", "Deputy", "Deputy", "Deputy" }, "4DEPUTY" },
            { new string[]{ "Deputy", "Deputy", "Bandit2Body", "Bandit2Body" }, "2DEPUTY2BANDIT2SHARED" },
            { new string[]{ "Bandit2Body", "Bandit2Body", "Deputy", "Deputy" }, "2DEPUTY2BANDIT2SHARED" },
            { new string[]{ "Deputy", "CommandoBody", "MinerModBody", "MinerModBody" }, "STARBOUND" },

            //Deku
            { new string[]{ "DekuBody", "DekuBody", "DekuBody", "DekuBody" }, "4DEKU" },

            //Amp
            { new string[]{ "AmpBody", "AmpBody", "AmpBody", "AmpBody" }, "4AMP" },

            //NemAmp
            //{ new string[]{ "AmpBody", "AmpBody", "AmpBody", "AmpBody" }, "4AMP" },

            //Sett
            { new string[]{ "SettBody", "SettBody", "SettBody", "SettBody" }, "4SETT" },

            //AlienHominid
            { new string[]{ "AliemBody", "AliemBody", "AliemBody", "AliemBody" }, "4ALIEM" },

            //Joe
            { new string[]{ "JoeBody", "JoeBody", "JoeBody", "JoeBody" }, "4JOE" },
            { new string[]{ "JoeBody", "CrocoBody", "CrocoBody", "CrocoBody" }, "1JOE3CROCO" },

            //Pathfinder
            { new string[]{ "PathfinderBody", "PathfinderBody", "PathfinderBody", "PathfinderBody" }, "4PATHFINDER" },

            //Heretic
            { new string[] { "HereticBody", "HereticBody", "HereticBody", "HereticBody" }, "4HERETIC" }
        };
    }
}
