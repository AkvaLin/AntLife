using System;
using System.Collections.Generic;
using System.Linq;
using Practic.Creators;
using Practic.Insects;
using Practic.Modifiers;

namespace Practic.Colony
{
    public class Colony
    {
        public readonly ColonyColors name;
        private Queen queen;
        private int eggs;
        private int timerForNewInscets;
        private List<Worker> workers;
        private List<Warrior> warriors;
        private List<Special> special;
        private ColonyDataModel data;

        private Dictionary<Resources, int> resources = new Dictionary<Resources, int>()
        {
            {Resources.branch, 0},
            {Resources.leaf, 0},
            {Resources.dewDrop,0},
            {Resources.stone,0},
        };

        public Colony(ColonyColors name)
        {
            this.name = name;
        }

        public void setupColony(Queen queen, List<Worker> workers, List<Warrior> warriors, List<Special> special)
        {
            this.queen = queen;
            this.workers = workers;
            this.warriors = warriors;
            this.special = special;
        }
        
        private void aboutColony(ColonyDataModel data)
        {
            int[] queenData = queen.getQueenData();
            
            Console.WriteLine($"Колония <{data.name}>\n\n" +
                              $"\tОбщая численность муравьёв: {data.antsAmount}\n" +
                              $"\t\tЧисленность рабочих: {data.workersAmount}\n" +
                              $"\t\tЧисленность воинов: {data.warriorsAmount}\n" +
                              $"\t\tЧисленность специальных насекомых: {data.specialAmount}\n\n" +
                              $"\tКоролева {queen.name}\n" +
                              "\tСтатус королевы:\n" + 
                              $"\t\tЗдовроье: {queenData[0]}\n" +
                              $"\t\tЗащита: {queenData[1]}\n" +
                              $"\t\tУрон: {queenData[2]}\n" +
                              $"\t\t\tМожеть создать {queen.newQueenAmount} королев\n" +
                              $"\t\t\tЦикл роста личинок равен {queen.timeForNewInsect} дням\n\n" +
                              $"\tКоличество ресурсов: {data.resoursesAmount}"
                              );
        }

        private void getData()
        {
            data = new ColonyDataModel(name, 
                workers.Count + warriors.Count + special.Count,
                workers.Count, 
                warriors.Count,
                special.Count,
                resources.Values.Sum()
                );
        }

        public void getInfoAboutColony()
        {
            getData();
            aboutColony(this.data);
        }

        public Queen getQueen()
        {
            Queen queen = this.queen;
            return queen;
        }

        public int getEggs()
        {
            return eggs;
        }

        public void addEggs(int amount)
        {
            eggs = eggs + amount;
        }

        public void clearSpecials()
        {
            special = new List<Special>();
        }

        public void increaseTimer()
        {
            timerForNewInscets++;
        }

        public void resetTimer()
        {
            timerForNewInscets = 0;
        }

        public int getTimer()
        {
            return timerForNewInscets;
        }

        public void newInsects(LifeCycle life)
        {
            for (int i = 0; i < eggs; i++)
            {
                int number = GetRandom.randomInt(0, 3);
                switch (number)
                {
                    case 0:
                        switch (GetRandom.randomInt(0, 1))
                        {
                            case 0:
                                ModifiersModel workerBasicModel = WorkersCreator.createModifiers
                                    (this, false);
                                Worker basicWorker = WorkersCreator.createWorker(this, workerBasicModel);
                                basicWorker.setupResourcesSettings();
                                workers.Add(basicWorker);
                                break;
                            case 1:
                                ModifiersModel workerAdvancedModel = WorkersCreator.createModifiers
                                    (this, true);
                                Worker advancedWorker = WorkersCreator.createWorker(this, workerAdvancedModel);
                                advancedWorker.setupResourcesSettings();
                                workers.Add(advancedWorker);
                                break;
                        }
                        break;
                    case 1:
                        switch (GetRandom.randomInt(0, 1))
                        {
                            case 0:
                                ModifiersModel warriorBasicModel = WarriorsCreator.createModifiers
                                    (this, false);
                                warriors.Add(WarriorsCreator.createWarrior(this, warriorBasicModel));
                                break;
                            case 1:
                                ModifiersModel warriorAdvancedModel = WarriorsCreator.createModifiers
                                    (this, true);
                                warriors.Add(WarriorsCreator.createWarrior(this, warriorAdvancedModel));
                                break;
                        }
                        break;
                    case 2:
                        special.Add(SpecialCreator.createSpecial(this));
                        break;
                    case 3:
                        Queen newQueen = QueensCreator.createQueen(this);
                        switch (GetRandom.randomInt(0, 1))
                        {
                            case 0:
                                Colony newColony = new Colony(this.name);
                                newColony.setupColony(newQueen, 
                                    new List<Worker>(), new List<Warrior>(), new List<Special>());
                                break;
                            case 1:
                                break;
                        }
                        break;
                }
            }
        }
    }
}