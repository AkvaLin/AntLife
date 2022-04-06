namespace Practic.Creators
{
    public class ColoniesCreator
    {
        public static Colony.Colony createColony(ColonyColors colonyColor)
        {
            Colony.Colony newColony = new Colony.Colony(colonyColor);
            newColony.setupColony(QueensCreator.createQueen(newColony), 
                WorkersCreator.CreateWorkers(newColony), 
                WarriorsCreator.createWarriors(newColony), 
                SpecialCreator.createSpecials(newColony)
                );
            return newColony;
        }
    }
}