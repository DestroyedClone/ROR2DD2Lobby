using HG;
using RoR2;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DD2HUD
{
    internal static class Assets
    {
        internal static List<ConditionSet> conditionSets = new List<ConditionSet>();
        internal static string GetKey(IEnumerable<string> names)
        {
            if (names.Count() <= 1) return string.Empty; // solos dont get team names
            foreach (var conditionSet in conditionSets) if (conditionSet.Check(names)) return Language.GetString("DD2LOBBY_" + conditionSet.Result);
            return string.Empty;
        }

        internal static void Init()
        {
            // the unique 4
            conditionSets.Add(new ConditionSet("BOYSCLUB", new ConditionKinds(3, Survivors.Captain, Survivors.Mercenary, Survivors.Commando)));
            conditionSets.Add(new ConditionSet("DOJOFIGHTERS", new ConditionKinds(4, Survivors.Henry, Survivors.CHEF, Survivors.Mercenary, Survivors.Loader)));
            conditionSets.Add(new ConditionSet("THEUNUSUALSUSPECTS", new ConditionKinds(4, Survivors.Bandit, Survivors.Commando, Survivors.Enforcer, Survivors.Loader)));
            conditionSets.Add(new ConditionSet("STARBOUND", new ConditionKinds(3, Survivors.Deputy, Survivors.Commando, Survivors.Miner)));
            conditionSets.Add(new ConditionSet("REDLINERAIDERS", new ConditionExact(Survivors.Huntress), new ConditionMinimum(2, Survivors.Commando)));
            conditionSets.Add(new ConditionSet("REFORMEDCREW", new ConditionKinds(3, Survivors.Bandit, Survivors.Huntress, Survivors.Loader, Survivors.Mercenary)));
            conditionSets.Add(new ConditionSet("SHOCKANDAWE", new ConditionKinds(4, Survivors.Loader, Survivors.Commando, Survivors.MULT, Survivors.Captain)));
            conditionSets.Add(new ConditionSet("DANCERDEPUTYDANCERDEPUTY", new ConditionHarmonyHounds(Survivors.Dancer, Survivors.Deputy)));
            conditionSets.Add(new ConditionSet("UESAUTHORIZED", new ConditionExact(Survivors.Captain), new ConditionKinds(2, Survivors.Loader, Survivors.Commando)));
            conditionSets.Add(new ConditionSet("MEMYSELFANDI", new ConditionKinds(3, Survivors.Commando, Survivors.NemesisCommando, Survivors.VoidFiend)));
            // 4 of a kinds
            conditionSets.Add(new ConditionSet("4ALIEM", new ConditionMinimum(Survivors.AlienHominid)));
            conditionSets.Add(new ConditionSet("4AMP", new ConditionMinimum(Survivors.Amp)));
            conditionSets.Add(new ConditionSet("4BANDIT2", new ConditionMinimum(Survivors.Bandit)));
            conditionSets.Add(new ConditionSet("4CAPTAIN", new ConditionMinimum(Survivors.Captain)));
            conditionSets.Add(new ConditionSet("4CHEF", new ConditionMinimum(Survivors.CHEF)));
            conditionSets.Add(new ConditionSet("4COMMANDO", new ConditionMinimum(Survivors.Commando)));
            conditionSets.Add(new ConditionSet("4CROCO", new ConditionMinimum(Survivors.Acrid)));
            conditionSets.Add(new ConditionSet("4DANCER", new ConditionMinimum(Survivors.Dancer)));
            conditionSets.Add(new ConditionSet("4DEKU", new ConditionMinimum(Survivors.Deku)));
            conditionSets.Add(new ConditionSet("4DEPUTYBODY", new ConditionMinimum(Survivors.Deputy)));
            conditionSets.Add(new ConditionSet("4DESOLATOR", new ConditionMinimum(Survivors.Desolator)));
            conditionSets.Add(new ConditionSet("4ENFORCER", new ConditionMinimum(Survivors.Enforcer)));
            conditionSets.Add(new ConditionSet("4ENGI", new ConditionMinimum(Survivors.Engineer)));
            conditionSets.Add(new ConditionSet("4HANDOVERCLOCKED", new ConditionMinimum(Survivors.HAND)));
            conditionSets.Add(new ConditionSet("4HENRY", new ConditionMinimum(Survivors.Henry)));
            conditionSets.Add(new ConditionSet("4HERETIC", new ConditionMinimum(Survivors.Heretic)));
            conditionSets.Add(new ConditionSet("4HUNTRESS", new ConditionMinimum(Survivors.Huntress)));
            conditionSets.Add(new ConditionSet("4IMPOSTER", new ConditionMinimum(Survivors.Impostor)));
            conditionSets.Add(new ConditionSet("4JOE", new ConditionMinimum(Survivors.FacelessJoe)));
            conditionSets.Add(new ConditionSet("4LOADER", new ConditionMinimum(Survivors.Loader)));
            conditionSets.Add(new ConditionSet("4MAGE", new ConditionMinimum(Survivors.Artificer)));
            conditionSets.Add(new ConditionSet("4MERC", new ConditionMinimum(Survivors.Mercenary)));
            conditionSets.Add(new ConditionSet("4MINERMOD", new ConditionMinimum(Survivors.Miner)));
            conditionSets.Add(new ConditionSet("4PATHFINDER", new ConditionMinimum(Survivors.Pathfinder)));
            conditionSets.Add(new ConditionSet("4RAILGUNNER", new ConditionMinimum(Survivors.Railgunner)));
            conditionSets.Add(new ConditionSet("4REGIGIGAS", new ConditionMinimum(Survivors.Regigigas)));
            conditionSets.Add(new ConditionSet("4RMOR", new ConditionMinimum(Survivors.RMOR)));
            conditionSets.Add(new ConditionSet("4ROBPALADIN", new ConditionMinimum(4, Survivors.Paladin)));
            conditionSets.Add(new ConditionSet("4ROCKETSURVIVOR", new ConditionMinimum(Survivors.Rocket)));
            conditionSets.Add(new ConditionSet("4SETT", new ConditionMinimum(Survivors.Sett)));
            conditionSets.Add(new ConditionSet("4SNIPERCLASSIC", new ConditionMinimum(Survivors.Sniper)));
            conditionSets.Add(new ConditionSet("4TESLATROOPER", new ConditionMinimum(Survivors.TeslaTrooper)));
            conditionSets.Add(new ConditionSet("4TOOLBOT", new ConditionMinimum(Survivors.MULT)));
            conditionSets.Add(new ConditionSet("4TREEBOT", new ConditionMinimum(Survivors.REX)));
            conditionSets.Add(new ConditionSet("4VOIDSURVIVOR", new ConditionMinimum(Survivors.VoidFiend)));
            // 4 of a kinds - PRODS ADDITIONS, FEEL FREE TO REMOVE
            conditionSets.Add(new ConditionSet("4ARCHANGEL", new ConditionMinimum(Survivors.Archangel)));
            conditionSets.Add(new ConditionSet("4BOMBER", new ConditionMinimum(Survivors.Bomber)));
            conditionSets.Add(new ConditionSet("4EXECUTIONER", new ConditionMinimum(4, Survivors.Executioner)));
            conditionSets.Add(new ConditionSet("4GUNSLINGER", new ConditionMinimum(Survivors.Gunslinger)));
            conditionSets.Add(new ConditionSet("4HOUSE", new ConditionMinimum(Survivors.House)));
            conditionSets.Add(new ConditionSet("4MELT", new ConditionMinimum(Survivors.MELT)));
            conditionSets.Add(new ConditionSet("4MYST", new ConditionMinimum(Survivors.Myst)));
            conditionSets.Add(new ConditionSet("4NEMESIS", new ConditionMinimum(Survivors.NemesisCommando)));
            conditionSets.Add(new ConditionSet("4NEMESIS", new ConditionMinimum(Survivors.NemesisEnforcer)));
            conditionSets.Add(new ConditionSet("4SPEARMAN", new ConditionMinimum(Survivors.Spearman)));
            conditionSets.Add(new ConditionSet("4TEMPLAR", new ConditionMinimum(Survivors.Templar)));
            // 2 and 2
            conditionSets.Add(new ConditionSet("2DANCER2DEPUTY", new ConditionEqual(Survivors.Dancer, Survivors.Deputy)));
            conditionSets.Add(new ConditionSet("DANCERDANCERHUNTRESSHUNTRESS", new ConditionEqual(Survivors.Dancer, Survivors.Huntress)));
            conditionSets.Add(new ConditionSet("2DEPUTY2BANDIT2SHARED", new ConditionEqual(Survivors.Deputy, Survivors.Bandit)));
            conditionSets.Add(new ConditionSet("2TESLATROOPER2LOADER", new ConditionEqual(Survivors.TeslaTrooper, Survivors.Loader)));
            // 1 and many
            conditionSets.Add(new ConditionSet("1BANDIT23COMMANDO", new ConditionExact(Survivors.Bandit), new ConditionMinimum(Survivors.Commando)));
            conditionSets.Add(new ConditionSet("1BANDIT23ENFORCER", new ConditionExact(Survivors.Bandit), new ConditionMinimum(Survivors.Enforcer)));
            conditionSets.Add(new ConditionSet("1CHEF3TREEBOT", new ConditionExact(Survivors.CHEF), new ConditionMinimum(Survivors.REX)));
            conditionSets.Add(new ConditionSet("1COMMANDO3CAPTAIN", new ConditionExact(Survivors.Captain), new ConditionMinimum(Survivors.Captain)));
            conditionSets.Add(new ConditionSet("1COMMANDO3VOIDSURVIVOR", new ConditionExact(Survivors.VoidFiend), new ConditionMinimum(Survivors.VoidFiend)));
            conditionSets.Add(new ConditionSet("1CROCO3TREEBOT", new ConditionExact(Survivors.Acrid), new ConditionMinimum(Survivors.REX)));
            conditionSets.Add(new ConditionSet("1ENFORCER3COMMANDO", new ConditionExact(Survivors.Enforcer), new ConditionMinimum(Survivors.Commando)));
            conditionSets.Add(new ConditionSet("1ENGI3COMMANDO", new ConditionExact(Survivors.Engineer), new ConditionMinimum(Survivors.Commando)));
            conditionSets.Add(new ConditionSet("1ENGI3TOOLBOT", new ConditionExact(Survivors.Engineer), new ConditionMinimum(3, Survivors.MULT)));
            conditionSets.Add(new ConditionSet("1HUNTRESS3CAPTAIN", new ConditionExact(Survivors.Huntress), new ConditionMinimum(Survivors.Captain)));
            conditionSets.Add(new ConditionSet("1LOADER3TOOLBOT", new ConditionExact(Survivors.Loader), new ConditionMinimum(Survivors.MULT)));
            conditionSets.Add(new ConditionSet("1LOADER3TREEBOT", new ConditionExact(Survivors.Loader), new ConditionMinimum(Survivors.REX)));
            conditionSets.Add(new ConditionSet("3MINERMOD1MERC", new ConditionExact(Survivors.Mercenary), new ConditionMinimum(Survivors.Miner)));
            conditionSets.Add(new ConditionSet("1TOOLBOT3COMMANDO", new ConditionExact(Survivors.MULT), new ConditionMinimum(Survivors.Commando)));
            conditionSets.Add(new ConditionSet("1TOOLBOT3HUNTRESS", new ConditionExact(Survivors.MULT), new ConditionMinimum(Survivors.Huntress)));
            conditionSets.Add(new ConditionSet("1TOOLBOT3LOADER", new ConditionExact(Survivors.MULT), new ConditionMinimum(Survivors.Loader)));
            // perhaps we have too much dog walker team names
            conditionSets.Add(new ConditionSet("1COMMANDO3CROCO", new ConditionExact(Survivors.Commando), new ConditionMinimum(Survivors.Acrid)));
            conditionSets.Add(new ConditionSet("1ENFORCER3CROCO", new ConditionExact(Survivors.Enforcer), new ConditionMinimum(Survivors.Acrid)));
            conditionSets.Add(new ConditionSet("1HUNTRESS3CROCO", new ConditionExact(Survivors.Huntress), new ConditionMinimum(Survivors.Acrid)));
            conditionSets.Add(new ConditionSet("1JOE3CROCO", new ConditionExact(Survivors.FacelessJoe), new ConditionMinimum(Survivors.Acrid)));
            conditionSets.Add(new ConditionSet("1MAGE3CROCO", new ConditionExact(Survivors.Artificer), new ConditionMinimum(Survivors.Acrid)));
            conditionSets.Add(new ConditionSet("1MERC3CROCO", new ConditionExact(Survivors.Mercenary), new ConditionMinimum(Survivors.Acrid)));
            conditionSets.Add(new ConditionSet("1ROBPALADIN3CROCO", new ConditionExact(Survivors.Paladin), new ConditionMinimum(Survivors.Acrid)));
            conditionSets.Add(new ConditionSet("1TREEBOT3CROCO", new ConditionExact(Survivors.REX), new ConditionMinimum(Survivors.Acrid)));
            // other teams
            conditionSets.Add(new ConditionSet("TESDESTESDES", new ConditionHarmonyHounds(Survivors.TeslaTrooper, Survivors.Desolator)));
            conditionSets.Add(new ConditionSet("PROTECTORS", new ConditionKinds(Survivors.Captain, Survivors.Engineer, Survivors.Paladin, Survivors.Enforcer, Survivors.Myst)));
            conditionSets.Add(new ConditionSet("SISTERSOFBATTLE", new ConditionUnique(3, Survivors.Artificer, Survivors.Huntress, Survivors.Loader, Survivors.Railgunner, Survivors.Deputy, Survivors.Heretic)));
            conditionSets.Add(new ConditionSet("SLICEDCLUB", new ConditionMinimum(Survivors.Sword), new ConditionMinimum(Survivors.Knuckle)));
            conditionSets.Add(new ConditionSet("CAMPINGCOHORTS", new ConditionMinimum(Survivors.Huntress), new ConditionMinimum(Survivors.Railgun)));
            conditionSets.Add(new ConditionSet("TOOLTIME", new ConditionMinimum(Survivors.Engineer), new ConditionMinimum(Survivors.Dancer), new ConditionMinimum(Survivors.Robot)));
            conditionSets.Add(new ConditionSet("ENGIREPAIRSTEAM", new ConditionMinimum(Survivors.Engineer), new ConditionMinimum(Union(Survivors.Cyborg, Survivors.Robot, L(Survivors.Artificer, Survivors.Loader, Survivors.TeslaTrooper, Survivors.Amp)).Except(L(Survivors.Engineer)).ToArray())));
            conditionSets.Add(new ConditionSet("DEVOLUTION", new ConditionDevolution(L(Survivors.Acrid), Survivors.Man, Survivors.Cyborg, Survivors.Robot)));
            // PRODS ADDITIONS, FEEL FREE TO REMOVE
            conditionSets.Add(new ConditionSet("EVOLUTION", new ConditionDevolution(Survivors.Robot, Survivors.Cyborg, Survivors.Man, L(Survivors.Acrid)))); // devolution but reversed
            conditionSets.Add(new ConditionSet("DUALIES", new ConditionKinds(Intersect(Survivors.Handgun, Survivors.DualWield)))); // two handgun
            conditionSets.Add(new ConditionSet("DOPPLEGANGER", new ConditionKinds(Survivors.NemesisEnforcer, Survivors.Templar))); // almost same moveset 
            conditionSets.Add(new ConditionSet("DOPPLEGANGER", new ConditionKinds(Survivors.Bandit, Survivors.Gunslinger))); // almost same 
            conditionSets.Add(new ConditionSet("DOPPLEGANGER", new ConditionKinds(Survivors.Railgunner, Survivors.Sniper))); // almost same 
            conditionSets.Add(new ConditionSet("DOPPLEGANGER", new ConditionKinds(Survivors.MULT, Survivors.MELT))); // variants
            conditionSets.Add(new ConditionSet("DOPPLEGANGER", new ConditionKinds(Survivors.RMOR, Survivors.HAND))); // variants
            conditionSets.Add(new ConditionSet("DOPPLEGANGER", new ConditionKinds(Survivors.NemesisCommando, Survivors.Commando))); // nemesis
            conditionSets.Add(new ConditionSet("DOPPLEGANGER", new ConditionKinds(Survivors.NemesisEnforcer, Survivors.Enforcer))); // nemesis
            conditionSets.Add(new ConditionSet("ECHOES", new ConditionKinds(Survivors.NemesisCommando, Survivors.NemesisEnforcer, Survivors.Gunslinger, Survivors.MELT, Survivors.RMOR))); // alt characters
            conditionSets.Add(new ConditionSet("SECONDWIND", new ConditionKinds(Survivors.Templar, Survivors.REX, Survivors.VoidFiend, Survivors.Heretic, Survivors.Amp, Survivors.Desolator))); // characters with "previous lives"
            conditionSets.Add(new ConditionSet("SERVANTS", new ConditionKinds(Survivors.Templar, Survivors.Artificer, Survivors.Paladin, Survivors.Enforcer, Survivors.Archangel, Survivors.Myst))); // ordered by higher being
            conditionSets.Add(new ConditionSet("VENDETTA", new ConditionKinds(Survivors.Templar, Survivors.Heretic, Survivors.Sniper, Survivors.Impostor))); // characters who betrayed their own kind
            conditionSets.Add(new ConditionSet("DASHLESS", new ConditionKinds(Survivors.Sett, Survivors.Engineer, Survivors.Enforcer, Survivors.NemesisEnforcer, Survivors.Artificer, Survivors.Captain, Survivors.House))); // no movement options lol
            conditionSets.Add(new ConditionSet("BIGSWORD", new ConditionKinds(Survivors.NemesisCommando, Survivors.Amp, Survivors.Myst, Survivors.Mercenary, Survivors.Paladin)));
            conditionSets.Add(new ConditionSet("ABSTRACT", new ConditionKinds(Survivors.VoidFiend, Survivors.FacelessJoe, Survivors.Amp, Survivors.Spearman, Survivors.Myst, Survivors.Executioner))); // human??s
            conditionSets.Add(new ConditionSet("ALIENS", new ConditionKinds(Survivors.VoidFiend, Survivors.AlienHominid, Survivors.Impostor, Survivors.Deku, Survivors.Sett))); // from outside of this world
            conditionSets.Add(new ConditionSet("CROSSOVER", new ConditionKinds(Survivors.Impostor, Survivors.Deku, Survivors.Sett, Survivors.Deputy, Survivors.NemesisEnforcer))); // yeah
            conditionSets.Add(new ConditionSet("FULLYAUTOMATED", new ConditionKinds(Survivors.Robot))); // robot
            conditionSets.Add(new ConditionSet("CYBERNETICENHANCEMENTS", new ConditionKinds(Survivors.Cyborg))); // cyborg
            conditionSets.Add(new ConditionSet("TEAM", new ConditionKinds(Survivors.Sett, Survivors.MELT, Survivors.MULT, Survivors.HAND, Survivors.RMOR, Survivors.Myst, Survivors.CHEF, Survivors.Deku))); // four letters
            conditionSets.Add(new ConditionSet("LEFTY", new ConditionKinds(Survivors.Lefty)));
            conditionSets.Add(new ConditionSet("LIGHTNING", new ConditionKinds(Survivors.Artificer, Survivors.Amp, Survivors.Deku, Survivors.Mercenary, Survivors.Deputy, Survivors.Spearman, Survivors.Executioner, Survivors.Loader, Survivors.TeslaTrooper))); // does lightning attacks or is fast
            conditionSets.Add(new ConditionSet("FIRE", new ConditionKinds(Survivors.Artificer, Survivors.FacelessJoe, Survivors.Templar, Survivors.Paladin, Survivors.CHEF, Survivors.MELT, Survivors.Sett, Survivors.Miner))); // fire attacks, sett, miner(heart of the forg)
            conditionSets.Add(new ConditionSet("DEBUFF", new ConditionKinds(Survivors.Desolator, Survivors.Gunslinger, Survivors.Acrid, Survivors.Templar, Survivors.Artificer, Survivors.Paladin, Survivors.REX, Survivors.Executioner, Survivors.Templar, Survivors.Dancer))); // inflict debuff on enemy (that isnt stun or bleed)
            conditionSets.Add(new ConditionSet("ELEMENTAL", new ConditionKinds(Survivors.Artificer, Survivors.FacelessJoe, Survivors.Amp, Survivors.Deku, Survivors.CHEF, Survivors.Desolator, Survivors.Acrid, Survivors.TeslaTrooper, Survivors.Templar, Survivors.Executioner, Survivors.Spearman, Survivors.Loader, Survivors.Paladin, Survivors.MELT))); // elemental attacks
            conditionSets.Add(new ConditionSet("MODUSOPERANDI", new ConditionKinds(Survivors.Sett, Survivors.MULT, Survivors.MELT, Survivors.Enforcer, Survivors.NemesisEnforcer, Survivors.Paladin, Survivors.Pathfinder, Survivors.House, Survivors.VoidFiend, Survivors.Myst, Survivors.TeslaTrooper, Survivors.FacelessJoe, Survivors.AlienHominid, Survivors.CHEF, Survivors.Deku, Survivors.Amp, Survivors.Templar))); // mode shift
            conditionSets.Add(new ConditionSet("BOMBS", new ConditionKinds(Survivors.Bomb)));
            conditionSets.Add(new ConditionSet("SHOTGUN", new ConditionKinds(Survivors.Shotgun)));
            conditionSets.Add(new ConditionSet("BIGGUNS", new ConditionKinds(Union(Survivors.Railgun, Survivors.Cannon))));
            conditionSets.Add(new ConditionSet("MELEE", new ConditionKinds(Survivors.Melee)));
            conditionSets.Add(new ConditionSet("SUITED", new ConditionKinds(Survivors.Suited)));
            conditionSets.Add(new ConditionSet("ARMORED", new ConditionKinds(Union(Survivors.Cyborg, Survivors.Armored))));
        }

        internal class ConditionSet
        {
            public string Result;
            public List<ConditionBase> Conditions;

            public ConditionSet(string result, params ConditionBase[] conditions)
            {
                Result = result;
                Conditions = conditions.ToList();
            }
            public bool Check(IEnumerable<string> list) 
            {
                int count = 0;
                foreach (var condition in Conditions)
                {
                    int _count = condition.Check(list);
                    if (_count == -1) return false;
                    count += _count;
                }
                return count == list.Count();
            }
        }

        internal class ConditionExact : ConditionCommon
        {
            public ConditionExact(params string[] target) : base(1, target) { }
            public ConditionExact(int number, params string[] target) : base(number, target) { }
            public override int Check(IEnumerable<string> list)
            {
                int ret = Survivors.Count(list, Target);
                if (ret == Number) return ret;
                return -1;
            }
        }

        internal class ConditionMinimum : ConditionCommon
        {
            public ConditionMinimum(params string[] target) : base(1, target) { }
            public ConditionMinimum(int number, params string[] target) : base(number, target) { }
            public override int Check(IEnumerable<string> list)
            {
                int ret = Survivors.Count(list, Target);
                if (ret >= Number) return ret;
                return -1;
            }
        }

        internal class ConditionUnique : ConditionCommon
        {
            public ConditionUnique(params string[] target) : base(1, target) { }
            public ConditionUnique(int number, params string[] target) : base(number, target) { }
            public override int Check(IEnumerable<string> list)
            {
                int ret = 0;
                foreach (string target in Target)
                {
                    int _ret = Survivors.Count(list, target);
                    if (_ret == 1) ret++;
                }
                if (ret >= Number) return ret;
                return -1;
            }
        }

        internal class ConditionKinds : ConditionCommon
        {
            public ConditionKinds(params string[] target) : base(2, target) { }
            public ConditionKinds(int number, params string[] target) : base(number, target) { }
            public override int Check(IEnumerable<string> list)
            {
                int ret = 0; int type = 0;
                foreach (string target in Target)
                {
                    int _ret = Survivors.Count(list, target);
                    if (_ret > 0)
                    {
                        type++;
                        ret += _ret;
                    }
                }
                if (type >= Number) return ret;
                return -1;
            }
        }

        internal class ConditionEqual : ConditionBase
        {
            public string[] TargetA;
            public string[] TargetB;

            public ConditionEqual(string targetA, string targetB)
            {
                TargetA = L(targetA);
                TargetB = L(targetB);
            }

            public ConditionEqual(string[] targetA, string[] targetB)
            {
                TargetA = targetA;
                TargetB = targetB;
            }

            public override int Check(IEnumerable<string> list)
            {
                int a = Survivors.Count(list, TargetA);
                if (a <= 0) return -1;
                if (a != Survivors.Count(list, TargetB)) return -1;
                return a * 2;
            }
        }

        internal class ConditionHarmonyHounds : ConditionBase
        {
            public string[][] Target;
            public ConditionHarmonyHounds(params string[] target)
            {
                List<string[]> ret = new List<string[]>();
                foreach (var item in target) ret.Add(L(item));
                Target = ret.ToArray();
            }
            public ConditionHarmonyHounds(params string[][] target)
            {
                Target = target;
            }

            public override int Check(IEnumerable<string> list)
            {
                for (var i = 0; i < list.Count(); i++) if (!Survivors.Check(list.ElementAt(i), Target[i % Target.Length])) return -1;
                return list.Count();
            }
        }

        internal class ConditionDevolution : ConditionBase
        {
            public string[][] Target;
            public ConditionDevolution(params string[] target)
            {
                List<string[]> ret = new List<string[]>();
                foreach (var item in target) ret.Add(L(item));
                Target = ret.ToArray();
            }
            public ConditionDevolution(params string[][] target)
            {
                Target = target;
            }

            public override int Check(IEnumerable<string> list)
            {
                int i = -1;
                List<string[]> target = Target.ToList();
                foreach (var item in list)
                {
                    int _i = target.FindIndex(x => Survivors.Check(list.ElementAt(i), x));
                    if (_i > i) i = _i; // -1 will be equal on init, and it only increases
                    else return -1;
                }
                return list.Count();
            }
        }

        internal abstract class ConditionCommon : ConditionBase
        {
            public string[] Target;
            public int Number;
            public ConditionCommon(int number, params string[] target)
            {
                Target = target;
                Number = number;
            }
        }

        internal abstract class ConditionBase { public abstract int Check(IEnumerable<string> list); }

        internal static class Survivors
        {
            // VANILLA
            internal const string Acrid = "CrocoBody";
            internal const string Artificer = "MageBody";
            internal const string Bandit = "Bandit2Body";
            internal const string Captain = "CaptainBody";
            internal const string Commando = "CommandoBody";
            internal const string Engineer = "EngiBody";
            internal const string Heretic = "HereticBody";
            internal const string Huntress = "HuntressBody";
            internal const string Loader = "LoaderBody";
            internal const string Mercenary = "MercBody";
            internal const string MULT = "ToolbotBody";
            internal const string Railgunner = "RailgunnerBody";
            internal const string REX = "TreebotBody";
            internal const string VoidFiend = "VoidSurvivorBody";
            // MODDED
            internal const string AlienHominid = "AliemBody";
            internal const string Amp = "AmpBody";
            internal const string CHEF = "CHEF";
            internal const string Dancer = "DancerBody";
            internal const string Deku = "DekuBody";
            internal const string Deputy = "DeputyBody";
            internal const string Desolator = "DesolatorBody";
            internal const string Enforcer = "EnforcerBody";
            internal const string FacelessJoe = "JoeBody";
            internal const string HAND = "HANDOverclockedBody";
            internal const string Henry = "HenryBody";
            internal const string Impostor = "ImpostorBody";
            internal const string Miner = "MinerBody";
            internal const string NemesisEnforcer = "NemesisEnforcerBody";
            internal const string Paladin = "RobPaladinBody";
            internal const string Pathfinder = "PathfinderBody";
            internal const string Regigigas = "RegigigasPlayerBody";
            internal const string RMOR = "RMORBody";
            internal const string Rocket = "RocketSurvivorBody";
            internal const string Sett = "SettBody";
            internal const string Sniper = "SniperClassicBody";
            internal const string TeslaTrooper = "TeslaTrooperBody";
            // MODDED - PROD'S ADDITIONS, FEEL FREE TO REMOVE
            internal const string Archangel = "ArchangelBody"; // literally unreleased lmfao
            internal const string Bomber = "DragonBomberBody"; // Dragonyck-Bomber
            internal const string Executioner = "ExecutionerBody"; // TeamMoonstorm-Starstorm2
            internal const string Gunslinger = "GunslingerBody"; // Dragonyck-Gunslinger
            internal const string House = "JavangleHouse"; // JavAngle-TheHouse
            internal const string LilHeretic = "LilHeretic"; // LuaFubuki-Lil_Heretic
            internal const string MELT = "MELTBody"; // PlasmaCore3-MELT
            internal const string Myst = "JavangleMystBody"; // JavAngle-Myst
            internal const string NemesisCommando = "NemmandoBody"; // TeamMoonstorm-Starstorm2
            internal const string Spearman = "SpearmanBody"; // SaucySquash-Spearman
            internal const string Templar = "Templar_Survivor"; // TemplarBoyz-PlayableTemplar

            //!!! MAKE SURE TO UPDATE THIS WHEN ADDING CHARACTERS !!!
            internal static string[] All = L(Acrid, Artificer, Bandit, Captain, Commando, Engineer, Heretic, Huntress, Loader, Mercenary, MULT, Railgunner, REX, VoidFiend, AlienHominid, Amp, CHEF, Dancer, Deku, Deputy, Desolator, Enforcer, FacelessJoe, HAND, Henry, Impostor, Miner, NemesisEnforcer, Paladin, Pathfinder, Regigigas, RMOR, Rocket, Sett, Sniper, TeslaTrooper, Archangel, Bomber, Executioner, Gunslinger, House, LilHeretic, MELT, Myst, NemesisCommando, Spearman, Templar);

            // being
            // internal static string[] Animal = L(Acrid);
            internal static string[] Man = L(Commando, Sett, Huntress, Bandit, Deputy, Enforcer, Gunslinger, Mercenary, Loader, Miner, Pathfinder, Captain, House, Railgunner, Myst, Templar, TeslaTrooper, Deku, Rocket, Sniper);
            internal static string[] Cyborg = L(Bomber, Engineer, Desolator);
            internal static string[] Robot = L(MULT, MELT, HAND, RMOR, CHEF, REX);
            // clothes
            internal static string[] Armored = L(Enforcer, NemesisEnforcer, Commando, NemesisCommando, Executioner, Artificer, Loader, Mercenary, TeslaTrooper, Sniper, FacelessJoe, Rocket, Dancer, Amp);
            internal static string[] Suited = L(Bandit, Captain, Commando, Deputy, Gunslinger, Pathfinder, House, Myst, Dancer);
            // sword
            internal static string[] Knuckle = L(Sett, HAND, Loader, Acrid, TeslaTrooper, Deku, RMOR);
            internal static string[] Sword = L(NemesisCommando, Mercenary, Paladin, Myst, Impostor, Amp, FacelessJoe, CHEF);
            internal static string[] Spear = L(Pathfinder, Spearman, Dancer);
            internal static string[] Handgun = L(Commando, Deputy, NemesisCommando, Bandit, REX, Executioner, House, Impostor, AlienHominid);
            internal static string[] Shotgun = L(Bandit, Enforcer, Captain);
            internal static string[] Minigun = L(MULT, Enforcer, NemesisEnforcer, Templar);
            internal static string[] Railgun = L(MULT, Railgunner, Sniper);
            internal static string[] Bomb = L(Bomber, Commando, Rocket, AlienHominid, Engineer, Templar, Pathfinder, Railgunner, Artificer, NemesisEnforcer, Enforcer, MELT, MULT);
            internal static string[] Cannon = L(MULT, RMOR, Rocket, Desolator);
            internal static string[] DualWield = Union(Knuckle, L(Bomber, Commando, Deputy, Miner, Impostor, FacelessJoe, Artificer, Enforcer));
            internal static string[] Lefty = L(NemesisCommando, MULT, MELT, REX, Pathfinder, Captain, Executioner, VoidFiend, Myst, FacelessJoe, AlienHominid, Dancer);
            internal static string[] Melee = Union(Knuckle, Sword, Spear, L(RMOR, NemesisEnforcer, Miner)).Except(L(TeslaTrooper)).ToArray();

            internal static int Count(IEnumerable<string> list, IEnumerable<string> list2) { return list2.ToList().Sum(x => Count(list, x)); }
            internal static int Count(IEnumerable<string> list, string to)
            {
                int ret = 0;
                foreach (var from in list) if (Check(from, to)) ret++;
                return ret;
            }

            internal static bool Check(string from, IEnumerable<string> list)
            {
                foreach (var to in list) if (Check(from, to)) return true;
                return false;
            }

            internal static bool Check(string from, string to) // from: INPUT, to: ~COMPARE TO
            {
                if (to == Heretic && from == LilHeretic) return true; // LilHeretic = Heretic
                return from == to;
            }
        }
        internal static T[] L<T>(params T[] element) { return element; } // kinda sick of writing `new string[] { A }`

        internal static T[] Intersect<T>(params T[][] element)
        {
            if (element.Length == 0) return Array.Empty<T>();
            IEnumerable<T> list = element[0];
            for (var i = 1; i < element.Length; i++) { list = list.Intersect(element[i]); }
            return list.ToArray();
        }
        internal static T[] Union<T>(params T[][] element) { return ArrayUtils.Join(element); } // only exists for consistency sake
        internal static string[] Invert(params string[] element) { return Survivors.All.Except(element).ToArray(); }
    }
}
