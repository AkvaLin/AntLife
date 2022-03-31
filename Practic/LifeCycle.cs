using System;
using System.Collections.Generic;

namespace Practic
{
    public class LifeCycle
    {
        private static int counter = 13;
        private List<Heap> heaps = new List<Heap>();
        
        public static void day()
        {
            if (counter > 0)
            {
                dayActivites();
                day();
            }
            else
            {
                Console.WriteLine("game is over");
            }
        }

        private static void dayActivites()
        {
            counter--;
        }
    }
}