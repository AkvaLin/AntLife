namespace Practic.Creators
{
    public class ColoniesCreator
    {
        public static Colony.Colony createColony(ColonyColors colonyColor)
        {
            Colony.Colony newColony = new Colony.Colony(colonyColor, 
                QueensCreator, 
                WorkersCreator, 
                WarriorsCreator, 
                SpecialCreator);
            return newColony;
        }
    }
}