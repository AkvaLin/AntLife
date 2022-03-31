using System;

namespace Practic.Insects
{
    public class ActingInsect: Insect
    {
        protected void AboutQueen()
        {
            Console.WriteLine($"Имя моей королевы: {colony.queen.name}\n" +
                              $"Параметры моей королевы: {colony.queen.queenStats}"
                              );
        }
    }
}