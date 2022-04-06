namespace Practic.Modifiers
{
    public struct ModifiersModel
    {
        public readonly BasicModifiers basicModifier;
        public readonly SpecialWorkersModifiers? specialWorkersModifiers;
        public readonly SpecialWarriorsModifiers? specialWarriorsModifiers;

        public ModifiersModel(BasicModifiers basicModifier = default, SpecialWorkersModifiers? specialWorkersModifiers = default, SpecialWarriorsModifiers? specialWarriorsModifiers = default)
        {
            this.basicModifier = basicModifier;
            this.specialWorkersModifiers = specialWorkersModifiers;
            this.specialWarriorsModifiers = specialWarriorsModifiers;
        }
    }
}