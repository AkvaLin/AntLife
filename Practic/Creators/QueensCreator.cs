using Practic.Insects;

namespace Practic.Creators
{
    public class QueensCreator
    {
        public static Queen? createQueen(Colony.Colony colony)
        {
            Queen queen;
            
            switch (colony.name)
            {
                case ColonyColors.black:
                    queen = new Queen("Виктория", 
                            GetRandom.randomInt(from: 2, to: 6), 
                            3);
                    queen.setupQueen(colony, 19, 7, 20);
                    return queen;
                case ColonyColors.red:
                    queen = new Queen("Рогнеда", 
                        GetRandom.randomInt(from: 2, to: 5), 
                        GetRandom.randomInt(from:2, to: 4));
                    queen.setupQueen(colony, 22, 5, 28);
                    return queen;
                case ColonyColors.green:
                    queen = new Queen("Анна", 
                        GetRandom.randomInt(from: 2, to: 4), 
                        GetRandom.randomInt(from:2, to: 6));
                    queen.setupQueen(colony, 17, 5, 18);
                    return queen;
                default:
                    return null;
            }
        }
    }
}