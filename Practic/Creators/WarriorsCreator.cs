using System.Collections.Generic;
using Practic.Insects;
using Practic.Modifiers;

namespace Practic.Creators
{
    public class WarriorsCreator
    {
        public static ModifiersModel createModifiers(Colony.Colony colony, bool isAdvanced)
        {
            ModifiersModel modifiers;
            
            switch (colony.name)
            {
                case ColonyColors.black:
                    modifiers = new ModifiersModel(isAdvanced ? BasicModifiers.senior : BasicModifiers.advanced, 
                        null, isAdvanced ? SpecialWarriorsModifiers.vindictive : null);
                    break;
                case ColonyColors.red:
                    modifiers = new ModifiersModel(isAdvanced ? BasicModifiers.advanced : BasicModifiers.elite,
                        null, isAdvanced ? SpecialWarriorsModifiers.havy : null);
                    break;
                case ColonyColors.green:
                    modifiers = new ModifiersModel(isAdvanced ? BasicModifiers.usual : BasicModifiers.legendary, 
                        null, isAdvanced ? SpecialWarriorsModifiers.anomalistic : null);
                    break;
                default:
                    modifiers = new ModifiersModel();
                    break;
            }
            return modifiers;
        }

        public static Warrior createWarrior(Colony.Colony colony, ModifiersModel modifiers)
        {
            Warrior warrior = new Warrior();

            switch (modifiers.basicModifier)
            {
                case BasicModifiers.usual:
                    warrior.setupWarrior(colony, 1, 0, 1,
                        modifiers, 1, 1);
                    break;
                case BasicModifiers.senior:
                    warrior.setupWarrior(colony, 1, 2, 1,
                        modifiers, 1, 1);
                    break;
                case BasicModifiers.advanced:
                    warrior.setupWarrior(colony, 2, 4, 2, 
                        modifiers, 2, 1);
                    break;
                case BasicModifiers.elite:
                    warrior.setupWarrior(colony, 8, 4, 3, 
                        modifiers, 2, 2);
                    break;
                case BasicModifiers.legendary:
                    warrior.setupWarrior(colony, 10, 6, 4, 
                        modifiers, 3, 1);
                    break;
            }
            
            return warrior;
        }

        public static List<Warrior> createWarriors(Colony.Colony colony)
        {
            List<Warrior> warriors = new List<Warrior>();
            int amountOfBasic;
            int amountOfAdvanced;
            
                        switch (colony.name)
            {
                case ColonyColors.black:
                    amountOfBasic = GetRandom.randomInt(0, 6);
                    amountOfAdvanced = 6 - amountOfBasic;
                    for (int i = 0; i < amountOfBasic; i++)
                    {
                        Warrior warrior = createWarrior(colony, createModifiers(colony, false));
                        warriors.Add(warrior);
                    }
                    for (int i = 0; i < amountOfAdvanced; i++)
                    {
                        Warrior warrior = createWarrior(colony, createModifiers(colony, true));
                        warriors.Add(warrior);
                    }
                    break;
                case ColonyColors.green:
                    amountOfBasic = GetRandom.randomInt(0, 9);
                    amountOfAdvanced = 9 - amountOfBasic;
                    for (int i = 0; i < amountOfBasic; i++)
                    {
                        Warrior warrior = createWarrior(colony, createModifiers(colony, false));
                        warriors.Add(warrior);
                    }
                    for (int i = 0; i < amountOfAdvanced; i++)
                    {
                        Warrior warrior = createWarrior(colony, createModifiers(colony, true));
                        warriors.Add(warrior);
                    }
                    break;
                case ColonyColors.red:
                    amountOfBasic = GetRandom.randomInt(0, 8);
                    amountOfAdvanced = 8 - amountOfBasic;
                    for (int i = 0; i < amountOfBasic; i++)
                    {
                        Warrior warrior = createWarrior(colony, createModifiers(colony, false));
                        warriors.Add(warrior);
                    }
                    for (int i = 0; i < amountOfAdvanced; i++)
                    {
                        Warrior warrior = createWarrior(colony, createModifiers(colony, true));
                        warriors.Add(warrior);
                    }
                    break;
            }
            return warriors;
        }
    }
}