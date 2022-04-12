using System;
using System.Collections.Generic;
using Practic.Creators;
using Practic.Insects;

namespace Practic
{
    public class LifeCycle
    {
        private int counter = 13;
        private List<Heap> heaps;
        private List<Colony.Colony> colonies;

        private Dictionary<int, Dictionary<ColonyColors, List<AntsGroupModel>>> antsOnHeaps =
            new Dictionary<int, Dictionary<ColonyColors, List<AntsGroupModel>>>()
            {
                {1, new Dictionary<ColonyColors, List<AntsGroupModel>>()
                {
                    {ColonyColors.green, new List<AntsGroupModel>()},
                    {ColonyColors.red, new List<AntsGroupModel>()},
                    {ColonyColors.black, new List<AntsGroupModel>()}
                }},
                {2, new Dictionary<ColonyColors, List<AntsGroupModel>>()
                {
                    {ColonyColors.green, new List<AntsGroupModel>()},
                    {ColonyColors.red, new List<AntsGroupModel>()},
                    {ColonyColors.black, new List<AntsGroupModel>()}
                }},
                {3, new Dictionary<ColonyColors, List<AntsGroupModel>>()
                {
                    {ColonyColors.green, new List<AntsGroupModel>()},
                    {ColonyColors.red, new List<AntsGroupModel>()},
                    {ColonyColors.black, new List<AntsGroupModel>()}
                }},
                {4, new Dictionary<ColonyColors, List<AntsGroupModel>>()
                {
                    {ColonyColors.green, new List<AntsGroupModel>()},
                    {ColonyColors.red, new List<AntsGroupModel>()},
                    {ColonyColors.black, new List<AntsGroupModel>()}
                }},
                {5, new Dictionary<ColonyColors, List<AntsGroupModel>>()
                {
                    {ColonyColors.green, new List<AntsGroupModel>()},
                    {ColonyColors.red, new List<AntsGroupModel>()},
                    {ColonyColors.black, new List<AntsGroupModel>()}
                }},
            };
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
                foreach (var colony in colonies)
                {
                    colony.getInfoAboutColony();
                }
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
            sortAnts();
            // Походы муравьев
            crusade();
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

        private void sortAnts()
        {
            List<AntsGroupModel> greenAnts = new List<AntsGroupModel>();
            List<AntsGroupModel> redAnts = new List<AntsGroupModel>();
            List<AntsGroupModel> blackAnts = new List<AntsGroupModel>();
            
            for (int i = 0; i < colonies.Count; i++)
            {
                AntsGroupModel model= colonies[i].getAntsGroupModel();
                AntsGroupModel newModel = new AntsGroupModel();
                List<int> forWarriors = new List<int>();
                List<int> forWorkers = new List<int>();
                List<int> forSpecials = new List<int>();
                List<int> warriorsIndexes = new List<int>();
                List<int> workersIndexes = new List<int>();
                List<int> specialIndexes = new List<int>();
                for (int j = 0; j < model.warriors.Count; j++)
                {
                    forWarriors.Add(GetRandom.randomInt(0,4));
                }
                for (int j = 0; j < model.workers.Count; j++)
                {
                    forWorkers.Add(GetRandom.randomInt(0,4));
                }
                for (int j = 0; j < model.specials.Count; j++)
                {
                    forSpecials.Add(GetRandom.randomInt(0,4));
                }
                switch (colonies[i].name)
                {
                    case ColonyColors.green:
                        addAnts(warriorsIndexes, workersIndexes, specialIndexes, 
                            forWarriors, forWorkers, forSpecials, model, newModel);
                        break;
                    case ColonyColors.red:
                        addAnts(warriorsIndexes, workersIndexes, specialIndexes, 
                            forWarriors, forWorkers, forSpecials, model, newModel);
                        break;
                    case ColonyColors.black:
                        addAnts(warriorsIndexes, workersIndexes, specialIndexes, 
                            forWarriors, forWorkers, forSpecials, model, newModel);
                        break;
                }
            }
        }

        private void addAnts(List<int> warriorsIndexes, List<int> workersIndexes, List<int> specialIndexes,
            List<int> forWarriors, List<int> forWorkers, List<int> forSpecials, 
            AntsGroupModel model, AntsGroupModel newModel)
        {
            for (int j = 0; j < 5; j++)
            {
                warriorsIndexes = forWarriors.FindAll(item => item==j);
                workersIndexes = forWorkers.FindAll(item => item==j);
                specialIndexes = forSpecials.FindAll(item => item==j);
                List<Warrior> newWarriors = new List<Warrior>();
                List<Worker> newWorkers = new List<Worker>();
                List<Special> newSpecials = new List<Special>();
                for (int k = 0; k < warriorsIndexes.Count; k++)
                {
                    newWarriors.Add(model.warriors[k]);
                }

                for (int k = 0; k < workersIndexes.Count; k++)
                {
                    newWorkers.Add(model.workers[k]);
                }

                for (int k = 0; k < specialIndexes.Count; k++)
                {
                    newSpecials.Add(model.specials[k]);
                }
                newModel.warriors = newWarriors;
                newModel.specials = newSpecials;
                newModel.workers = newWorkers;
                antsOnHeaps[j+1][ColonyColors.green].Add(newModel);
            }
        }
        
        private void crusade()
        {
            
        }
    }
}