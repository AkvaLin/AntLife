namespace Practic.Modifiers
{
    public struct SpecialsModifiersModel
    {
        public readonly SpecialsModifiers resourcesMod;
        public readonly SpecialsModifiers takeDamageMod;
        public readonly SpecialsModifiers attackMod;
        public readonly SpecialsModifiers specialMod;

        public SpecialsModifiersModel(SpecialsModifiers resourcesMod, SpecialsModifiers takeDamageMod, SpecialsModifiers attackMod, SpecialsModifiers specialMod)
        {
            this.resourcesMod = resourcesMod;
            this.takeDamageMod = takeDamageMod;
            this.attackMod = attackMod;
            this.specialMod = specialMod;
        }
    }
}