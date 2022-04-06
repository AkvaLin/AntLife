using System;

namespace Practic.Insects
{
    public class ActingInsect: Insect
    {
        protected void AboutQueen(Queen queen)
        {
            Console.WriteLine($"Имя моей королевы: \n" +
                              $"Параметры моей королевы:"
                              );
        }
    }
}