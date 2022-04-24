using System;
using System.Collections.Generic;
using System.Linq;
using Practic.Creators;
using Practic.Insects;

namespace Practic
{
    public class LifeCycle
    {
        private int counter = 13;
        private List<Heap> heaps;
        private List<Colony.Colony> colonies;

        private Dictionary<int, Dictionary<ColonyColors, List<List<ActingInsect>>>> antsOnHeaps =
            new Dictionary<int, Dictionary<ColonyColors, List<List<ActingInsect>>>>()
            {
                {1, new Dictionary<ColonyColors, List<List<ActingInsect>>>()
                {
                    {ColonyColors.green, new List<List<ActingInsect>>()},
                    {ColonyColors.red, new List<List<ActingInsect>>()},
                    {ColonyColors.black, new List<List<ActingInsect>>()}
                }},
                {2, new Dictionary<ColonyColors, List<List<ActingInsect>>>()
                {
                    {ColonyColors.green, new List<List<ActingInsect>>()},
                    {ColonyColors.red, new List<List<ActingInsect>>()},
                    {ColonyColors.black, new List<List<ActingInsect>>()}
                }},
                {3, new Dictionary<ColonyColors, List<List<ActingInsect>>>()
                {
                    {ColonyColors.green, new List<List<ActingInsect>>()},
                    {ColonyColors.red, new List<List<ActingInsect>>()},
                    {ColonyColors.black, new List<List<ActingInsect>>()}
                }},
                {4, new Dictionary<ColonyColors, List<List<ActingInsect>>>()
                {
                    {ColonyColors.green, new List<List<ActingInsect>>()},
                    {ColonyColors.red, new List<List<ActingInsect>>()},
                    {ColonyColors.black, new List<List<ActingInsect>>()}
                }},
                {5, new Dictionary<ColonyColors, List<List<ActingInsect>>>()
                {
                    {ColonyColors.green, new List<List<ActingInsect>>()},
                    {ColonyColors.red, new List<List<ActingInsect>>()},
                    {ColonyColors.black, new List<List<ActingInsect>>()}
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
            newHeaps.Add(new Heap(33, 18, 0, 0));
            newHeaps.Add(new Heap(33, 0, 37, 0));
            newHeaps.Add(new Heap(12, 0, 13, 46));
            newHeaps.Add(new Heap(11, 35, 36, 35));
            newHeaps.Add(new Heap(35, 41, 0, 0));

            heaps = newHeaps;
            colonies = newColonies;
        }

        public void day()
        {
            // Проверка засухи
            if (counter > 0)
            {
                userInteraction();
                day();
            }
            else
            {
                Colony.Colony winColony = colonies[0];
                Console.WriteLine("Program is over");
                for (int i = 0; i < colonies.Count-1; i++)
                {
                    if (colonies[i + 1].getResourcesAmount() > winColony.getResourcesAmount())
                        winColony = colonies[i + 1];
                }
                Console.WriteLine("Выжившая колония");
                winColony.getInfoAboutColony();
            }
        }

        private void dayActivites()
        {
            // Каст специального ивента
            if (!specialEventWasActivated)
            {
                int number = GetRandom.randomInt(1, 11);
                if (number == 10)
                {
                    SpecialEvent.action(colonies);
                    specialEventWasActivated = true;
                    Console.WriteLine("Лягушка вышла на охоту и съела всех специальных насекомых");
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
            // Распределение рес-ов
            addResources();
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
            antsOnHeaps = new Dictionary<int, Dictionary<ColonyColors, List<List<ActingInsect>>>>()
                {
                    {1, new Dictionary<ColonyColors, List<List<ActingInsect>>>()
                    {
                        {ColonyColors.green, new List<List<ActingInsect>>()},
                        {ColonyColors.red, new List<List<ActingInsect>>()},
                        {ColonyColors.black, new List<List<ActingInsect>>()}
                    }},
                    {2, new Dictionary<ColonyColors, List<List<ActingInsect>>>()
                    {
                        {ColonyColors.green, new List<List<ActingInsect>>()},
                        {ColonyColors.red, new List<List<ActingInsect>>()},
                        {ColonyColors.black, new List<List<ActingInsect>>()}
                    }},
                    {3, new Dictionary<ColonyColors, List<List<ActingInsect>>>()
                    {
                        {ColonyColors.green, new List<List<ActingInsect>>()},
                        {ColonyColors.red, new List<List<ActingInsect>>()},
                        {ColonyColors.black, new List<List<ActingInsect>>()}
                    }},
                    {4, new Dictionary<ColonyColors, List<List<ActingInsect>>>()
                    {
                        {ColonyColors.green, new List<List<ActingInsect>>()},
                        {ColonyColors.red, new List<List<ActingInsect>>()},
                        {ColonyColors.black, new List<List<ActingInsect>>()}
                    }},
                    {5, new Dictionary<ColonyColors, List<List<ActingInsect>>>()
                    {
                        {ColonyColors.green, new List<List<ActingInsect>>()},
                        {ColonyColors.red, new List<List<ActingInsect>>()},
                        {ColonyColors.black, new List<List<ActingInsect>>()}
                    }},
                };
        }

        public void addColony(Colony.Colony colony)
        {
            colonies.Add(colony);
        }

        private void sortAnts()
        {
            for (int i = 0; i < colonies.Count; i++)
            {
                List<ActingInsect> model = colonies[i].getInsects();
                model.shuffle();
                List<int> forInsect = new List<int>();
                for (int j = 0; j < model.Count; j++)
                {
                    forInsect.Add(GetRandom.randomInt(0,5));
                }
                switch (colonies[i].name)
                {
                    case ColonyColors.green:
                        addAnts(forInsect, model, ColonyColors.green);
                        break;
                    case ColonyColors.red:
                        addAnts(forInsect, model, ColonyColors.red);
                        break;
                    case ColonyColors.black:
                        addAnts(forInsect, model, ColonyColors.black);
                        break;
                }
            }
        }

        private void addAnts(List<int> forInsect,
            List<ActingInsect> model, ColonyColors color)
        {
            for (int j = 0; j < 5; j++)
            {
                List<int> insectIndex = forInsect.FindAll(item => item==j);
                List<ActingInsect> newInsects = new List<ActingInsect>();
                List<ActingInsect> newModel = new List<ActingInsect>();
                for (int k = 0; k < insectIndex.Count; k++)
                {
                    newInsects.Add(model[k]);
                }

                foreach (var insect in newInsects)
                {
                    newModel.Add(insect);
                }
                antsOnHeaps[j+1][color].Add(newModel);
            }
        }
        
        private void crusade()
        {
            for (int heapNumber = 1; heapNumber < 6; heapNumber++)
            {
                List<ActingInsect> shuffledAntsList = new List<ActingInsect>();
                bool isFirst = true;
                bool hasLegend = false;
                for (int j = 0; j < 3; j++)
                {
                    switch (j)
                    {
                        case 0:
                            for (int k = 0; k < antsOnHeaps[heapNumber][ColonyColors.green].Count; k++)
                            {
                                foreach (var ant in antsOnHeaps[heapNumber][ColonyColors.green][k])
                                {
                                    shuffledAntsList.Add(ant);
                                }
                            }
                            break;
                        case 1:
                            for (int k = 0; k < antsOnHeaps[heapNumber][ColonyColors.red].Count; k++)
                            {
                                foreach (var ant in antsOnHeaps[heapNumber][ColonyColors.red][k])
                                {
                                    shuffledAntsList.Add(ant);
                                }
                            }
                            break;
                        case 2:
                            for (int k = 0; k < antsOnHeaps[heapNumber][ColonyColors.black].Count; k++)
                            {
                                foreach (var ant in antsOnHeaps[heapNumber][ColonyColors.black][k])
                                {
                                    shuffledAntsList.Add(ant);
                                }
                            }
                            break;
                    }
                }
                shuffledAntsList.shuffle();
                foreach (var insect in shuffledAntsList)
                {
                    if (insect.getIsLegend())
                        hasLegend = true;
                }
                while (shuffledAntsList.Count > 0)
                {
                    if (!shuffledAntsList[0].isAlive())
                    {
                        shuffledAntsList.Remove(shuffledAntsList[0]);
                        continue;
                    }
                    for (int j = 0; j < shuffledAntsList[0].getTurnCounter(); j++)
                    {
                        ActingInsect? target = null;
                        List<ColonyColors> targetColonies = new List<ColonyColors>()
                        {
                            ColonyColors.black,
                            ColonyColors.green,
                            ColonyColors.red
                        };
                        if (shuffledAntsList[0].getModifiers().specialWarriorsModifiers != SpecialWarriorsModifiers.anomalistic || hasLegend)
                        {
                            targetColonies.Remove(shuffledAntsList[0].getColor());
                        }
                        else
                        {
                            targetColonies.Clear();
                            targetColonies.Add(shuffledAntsList[0].getColor());
                        }
                        if (shuffledAntsList[0].getType() != Types.worker)
                        {
                            int colonyColor = GetRandom.randomInt(0, targetColonies.Count);
                            int colony;
                            int colonyCounter = 0;
                            int antCounter = 0;
                            if (!hasLegend)
                            {
                                foreach (var color in targetColonies)
                                {
                                    foreach (var selectedColony in antsOnHeaps[heapNumber][color])
                                    {
                                        foreach (var insect in selectedColony)
                                        {
                                            if (insect.getModifiers().specialWarriorsModifiers == SpecialWarriorsModifiers.heavy && insect.isAlive())
                                            {
                                                target = insect;
                                            }
                                        }
                                    }
                                }
                            }

                            if (target == null)
                            {
                                if (antsOnHeaps[heapNumber][targetColonies[colonyColor]].Count > 0)
                                {
                                    while (true)
                                    {
                                        colony  = GetRandom.randomInt(0,
                                            antsOnHeaps[heapNumber][targetColonies[colonyColor]].Count);
                                        if (antsOnHeaps[heapNumber][targetColonies[colonyColor]][colony].Count > 0)
                                        {
                                            while (true)
                                            {
                                                int targetNumber = GetRandom.randomInt(0,
                                                    antsOnHeaps[heapNumber][targetColonies[colonyColor]][colony].Count);

                                                if (antsOnHeaps[heapNumber][targetColonies[colonyColor]][colony]
                                                        [targetNumber].getCanBeAttacked() && (antsOnHeaps[heapNumber][targetColonies[colonyColor]][colony]
                                                            [targetNumber].getModifiers().specialWorkersModifiers != SpecialWorkersModifiers.sprinter || 
                                                        antsOnHeaps[heapNumber][targetColonies[colonyColor]][colony]
                                                            [targetNumber].getModifiers().specialWorkersModifiers == SpecialWorkersModifiers.sprinter && !isFirst) && 
                                                    antsOnHeaps[heapNumber][targetColonies[colonyColor]][colony]
                                                        [targetNumber].isAlive())
                                                {
                                                    target = antsOnHeaps[heapNumber][targetColonies[colonyColor]][colony]
                                                        [targetNumber];
                                                    break;
                                                }

                                                antCounter++;
                                                if (antCounter == antsOnHeaps[heapNumber][targetColonies[colonyColor]][colony].Count)
                                                {
                                                    break;
                                                }
                                            }
                                            break;
                                        }

                                        colonyCounter++;
                                        if (colonyCounter == antsOnHeaps[heapNumber][targetColonies[colonyColor]].Count)
                                        {
                                            break;
                                        }
                                    }
                                }
                                else if (antsOnHeaps[heapNumber][targetColonies[Math.Abs(colonyColor-1)]].Count > 0)
                                {
                                    while (true)
                                    {
                                        colony  = GetRandom.randomInt(0,
                                            antsOnHeaps[heapNumber][targetColonies[Math.Abs(colonyColor-1)]].Count);
                                        if (antsOnHeaps[heapNumber][targetColonies[Math.Abs(colonyColor-1)]][colony].Count > 0)
                                        {
                                            while (true)
                                            {
                                                int targetNumber = GetRandom.randomInt(0,
                                                    antsOnHeaps[heapNumber][targetColonies[Math.Abs(colonyColor-1)]][colony].Count);

                                                if (antsOnHeaps[heapNumber][targetColonies[Math.Abs(colonyColor-1)]][colony]
                                                        [targetNumber].getCanBeAttacked() && (antsOnHeaps[heapNumber][targetColonies[Math.Abs(colonyColor-1)]][colony]
                                                            [targetNumber].getModifiers().specialWorkersModifiers != SpecialWorkersModifiers.sprinter || 
                                                        antsOnHeaps[heapNumber][targetColonies[Math.Abs(colonyColor-1)]][colony]
                                                            [targetNumber].getModifiers().specialWorkersModifiers == SpecialWorkersModifiers.sprinter && !isFirst) && 
                                                    antsOnHeaps[heapNumber][targetColonies[Math.Abs(colonyColor-1)]][colony]
                                                        [targetNumber].isAlive())
                                                {
                                                    target = antsOnHeaps[heapNumber][targetColonies[Math.Abs(colonyColor-1)]][colony]
                                                        [targetNumber];
                                                    break;
                                                }
                                                antCounter++;
                                                if (antCounter == antsOnHeaps[heapNumber][targetColonies[Math.Abs(colonyColor-1)]][colony].Count)
                                                {
                                                    break;
                                                }
                                            }
                                            break;
                                        }
                                    
                                        colonyCounter++;
                                        if (colonyCounter == antsOnHeaps[heapNumber][targetColonies[Math.Abs(colonyColor-1)]].Count)
                                        {
                                            break;
                                        }
                                    }
                                }
                            }
                        }
                        shuffledAntsList[0].action(heaps[heapNumber-1], target, hasLegend);
                    }
                    shuffledAntsList.Remove(shuffledAntsList[0]);
                    isFirst = false;
                }
            }
        }

        private void addResources()
        {
            for (int heapNumber = 1; heapNumber < 6; heapNumber++)
            {
                foreach (var heap in antsOnHeaps[heapNumber])
                {
                    foreach (var insects in heap.Value)
                    {
                        foreach (var insect in insects)
                        {
                            if (insect.isAlive() && insect.getType() != Types.warrior)
                            {
                                Dictionary<Resources, int> tempResources = insect.getResources();
                                insect.getColony().addResources(tempResources[Resources.branch], tempResources[Resources.leaf], 
                                    tempResources[Resources.dewDrop], tempResources[Resources.stone]);
                            }
                        }
                    }
                }
            }
        }

        private void userInteraction()
        {
            Console.WriteLine("Введите 1 для начала нового дня\n" +
                              "Введите 2, чтобы получить информацию о колониях\n" +
                              "Введите 3, чтобы получить информацию о муравяьях\n" +
                              "Введите 4, чтобы получить информацию о королевах");
            string userInput = Console.ReadLine();
            List<string> coloniesAmount = new List<string>();
            switch (userInput)
            {
                case "1":
                    Console.Clear();
                    dayActivites();
                    foreach (var colony in colonies)
                    {
                        colony.getInfoAboutColony();
                    }

                    Console.WriteLine("День завершён");
                    Console.WriteLine($"До засухи - {counter}");
                    Console.WriteLine("Нажмите кнопку, чтобы продолжить");
                    Console.ReadKey();
                    Console.Clear();
                    break;
                case "2":
                    Console.Clear();
                    Console.WriteLine($"Выберите колонию от 1 до {colonies.Count}");
                    userInput = Console.ReadLine();
                    coloniesAmount.Clear();
                    for (int i = 1; i <= colonies.Count; i++)
                    {
                        coloniesAmount.Add(i.ToString());
                    }
                    if (coloniesAmount.Contains(userInput))
                    {
                        colonies[Convert.ToInt32(userInput) - 1].getInfoAboutColony();
                        Console.WriteLine("Нажмите, чтобы продолжить");
                        Console.ReadKey();
                        Console.Clear();
                        userInteraction();
                    }
                    else
                    {
                        Console.WriteLine("Некорректный ввод. Нажмите кнопку, чтобы продолжить");
                        Console.ReadKey();
                        Console.Clear();
                        userInteraction();
                    }
                    break;
                case "3":
                    Console.Clear();
                    Console.WriteLine($"Выберите колонию от 1 до {colonies.Count}");
                    userInput = Console.ReadLine();
                    coloniesAmount.Clear();
                    for (int i = 1; i <= colonies.Count; i++)
                    {
                        coloniesAmount.Add(i.ToString());
                    }
                    if (coloniesAmount.Contains(userInput))
                    {
                        Colony.Colony userColony = colonies[Convert.ToInt32(userInput) - 1];
                        Console.WriteLine($"Выберите тип муравья от 1 до {userColony.getInsects().Count}");
                        userInput = Console.ReadLine();
                        List<string> antsAmount = new List<string>();
                        for (int i = 1; i <= userColony.getInsects().Count; i++)
                        {
                            antsAmount.Add(i.ToString());
                        }
                        if (antsAmount.Contains(userInput))
                        {
                            userColony.getInsects()[Convert.ToInt32(userInput) - 1].AboutMe();
                            Console.WriteLine("Нажмите, чтобы продолжить");
                            Console.ReadKey();
                            Console.Clear();
                            userInteraction();
                        }
                        else
                        {
                            Console.WriteLine("Некорректный ввод. Нажмите кнопку, чтобы продолжить");
                            Console.ReadKey();
                            Console.Clear();
                            userInteraction();
                        }
                    }
                    else
                    {
                        Console.WriteLine("Некорректный ввод. Нажмите кнопку, чтобы продолжить");
                        Console.ReadKey();
                        Console.Clear();
                        userInteraction();
                    }
                    break;
                case "4":
                    Console.Clear();
                    Console.WriteLine($"Выберите колонию от 1 до {colonies.Count}");
                    userInput = Console.ReadLine();
                    coloniesAmount.Clear();
                    for (int i = 1; i <= colonies.Count; i++)
                    {
                        coloniesAmount.Add(i.ToString());
                    }
                    if (coloniesAmount.Contains(userInput))
                    {
                        colonies[Convert.ToInt32(userInput) - 1].getQueen().AboutMe();
                        Console.WriteLine("Нажмите, чтобы продолжить");
                        Console.ReadKey();
                        Console.Clear();
                        userInteraction();
                    }
                    else
                    {
                        Console.WriteLine("Некорректный ввод. Нажмите кнопку, чтобы продолжить");
                        Console.ReadKey();
                        Console.Clear();
                        userInteraction();
                    }
                    break;
                default:
                    Console.WriteLine("Некорректный ввод. Нажмите кнопку, чтобы продолжить");
                    Console.ReadKey();
                    Console.Clear();
                    userInteraction();
                    break;
                    
            }
        }
    }
}