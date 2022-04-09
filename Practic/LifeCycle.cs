using System;
using System.Collections.Generic;
using Practic.Creators;

namespace Practic
{
    public class LifeCycle
    {
        private int counter = 13;
        private List<Heap> heaps;
        private List<Colony.Colony> colonies;
        private bool specialEventWasActivated = false;

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

        public void day()
        {
            // Проверка засухи
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

        private void dayActivites()
        {
            // Каст специального ивента
            if (!specialEventWasActivated)
            {
                int number = GetRandom.randomInt(1, 10);
                if (number == 10)
                {
                    SpecialEvent.action(colonies);
                    specialEventWasActivated = true;
                }
            }
            // Добавление новых яиц
            for (int i = 0; i < colonies.Count; i++)
            {
                if (colonies[i].getEggs() == 0)
                {
                    colonies[i].addEggs(GetRandom.randomInt(3, 7));
                }
            }
            // Распределение муравьев
            for (int i = 0; i < colonies.Count; i++)
            {
                
            }
            // Походы муравьев
            
            // +1 к таймеру взросления, проверка и создание новых насекомых
            for (int i = 0; i < colonies.Count; i++)
            {
                colonies[i].increaseTimer();
                if (colonies[i].getTimer() == colonies[i].getQueen().timeForNewInsect)
                {
                    colonies[i].newInsects(this);
                    colonies[i].resetTimer();
                }
            }
            // -1 день до засухи
            counter--;
        }

        public void addColony(Colony.Colony colony)
        {
            colonies.Add(colony);
        }
    }
}