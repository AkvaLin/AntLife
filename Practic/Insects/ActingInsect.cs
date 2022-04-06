using System;

namespace Practic.Insects
{
    public class ActingInsect: Insect
    {
        protected void AboutQueen(Colony.Colony colony)
        {
            Queen queen = colony.getQueen();
            int[] queenData = queen.getQueenData();

            Console.WriteLine($"Королева {queen.name}\n" +
                              "Статус королевы:\n" + 
                              $"\tЗдовроье: {queenData[0]}\n" +
                              $"\tЗащита: {queenData[1]}\n" +
                              $"\tУрон: {queenData[2]}\n" +
                              $"\t\tМожеть создать {queen.newQueenAmount} королев\n" +
                              $"\t\tЦикл роста личинок равен {queen.timeForNewInsect} дням\n\n");
        }
    }
}