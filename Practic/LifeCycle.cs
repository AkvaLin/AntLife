using System;
using System.Collections.Generic;
using Practic.Creators;

namespace Practic
{
    public class LifeCycle
    {
        private static int counter = 13;
        private List<Heap> heaps;
        private List<Colony.Colony> colonies;

        public LifeCycle()
        {
            ColoniesCreator creator = new ColoniesCreator();
            List<Colony.Colony> newColonies = new List<Colony.Colony>();
            newColonies.Add(creator.createColony(ColonyColors.green));
            newColonies.Add(creator.createColony(ColonyColors.red));
            newColonies.Add(creator.createColony(ColonyColors.black));
            
            List<Heap> newHeaps = new List<Heap>();
            newHeaps.Add(new Heap(33, 18, null, null));
            newHeaps.Add(new Heap(33, null, 37, null));
            newHeaps.Add(new Heap(12, null, 13, 46));
            newHeaps.Add(new Heap(11, 35, 36, 35));
            newHeaps.Add(new Heap(35, 41, null, null));

            heaps = newHeaps;
            colonies = newColonies;
        }

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