using System.Collections.Generic;
using Practic.Insects;
using Practic.Modifiers;

namespace Practic.Creators
{
    public class SpecialCreator
    {
        public static Special createSpecial(Colony.Colony colony)
        {
            Special special = new Special();
            
            switch (colony.name)
            {
                case ColonyColors.black:
                    special.setupSpecial(new SpecialsModifiersModel(
                            SpecialsModifiers.lazy, 
                            SpecialsModifiers.usual, 
                            SpecialsModifiers.agressive, 
                            SpecialsModifiers.legend), 
                        "Медвека", colony, 19, 7, 
                        9, 1, 3, 
                        null, null, null);
                    break;
                case ColonyColors.red:
                    special.setupSpecial(new SpecialsModifiersModel(
                            SpecialsModifiers.hardworking, 
                            SpecialsModifiers.usual, 
                            SpecialsModifiers.peaceful, 
                            SpecialsModifiers.sprinter), 
                        "Толстоножка", colony, 28, 5, 
                        null, null, null, 
                        new Resources[]{Resources.branch, Resources.leaf, Resources.stone, Resources.dewDrop},
                        2, false);
                    break;
                case ColonyColors.green:
                    special.setupSpecial(new SpecialsModifiersModel(SpecialsModifiers.hardworking,
                            SpecialsModifiers.invulnerable, 
                            SpecialsModifiers.peaceful, 
                            SpecialsModifiers.experienced),
                        "Бабочка", colony, 19, 6,
                        null, null, null, 
                        new Resources[]{Resources.leaf}, 3, false);
                    break;
            }
            return special;
        }

        public static List<Special> createSpecials(Colony.Colony colony)
        {
            List<Special> specials = new List<Special>(){createSpecial(colony)};
            return specials;
        }
    }
}