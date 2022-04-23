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
        private List<ActingInsect> insects;
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

        public void setupColony(Queen queen, List<Worker> workers, List<Warrior> warriors, List<Special> specials)
        {
            this.queen = queen;
            
            List<ActingInsect> tempList = new List<ActingInsect>();
            foreach (var worker in workers)
            {
                tempList.Add(worker);
            }

            foreach (var warrior in warriors)
            {
                tempList.Add(warrior);
            }
            foreach (var special in specials)
            {
                tempList.Add(special);
            }

            this.insects = tempList;
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
                              $"\t\t\tМожеть создать ещё {queen.getQueenAmount()} королев\n" +
                              $"\t\t\tЦикл роста личинок равен {queen.timeForNewInsect} дням\n\n" +
                              $"\tКоличество ресурсов: {data.resoursesAmount}"
                              );
        }

        private void getData()
        
        {
            int workersAmount = 0;
            int warriorsAmount = 0;
            int specialAmount = 0;
            foreach (var inscet in insects)
            {
                switch (inscet.getType())
                {
                    case Types.worker:
                        workersAmount++;
                        break;
                    case Types.warrior:
                        warriorsAmount++;
                        break;
                    case Types.special:
                        specialAmount++;
                        break;
                }
            }
            data = new ColonyDataModel(name, 
                insects.Count,
                workersAmount, 
                warriorsAmount,
                specialAmount,
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

        public List<ActingInsect> getInsects()
        {
            return insects;
        }

        public void newInsects(LifeCycle life)
        {
            for (int i = 0; i < eggs; i++)
            {
                switch (GetRandom.randomInt(0, 8))
                {
                    case <3:
                        switch (GetRandom.randomInt(0, 2))
                        {
                            case 0:
                                ModifiersModel workerBasicModel = WorkersCreator.createModifiers
                                    (this, false);
                                Worker basicWorker = WorkersCreator.createWorker(this, workerBasicModel);
                                insects.Add(basicWorker);
                                break;
                            case 1:
                                ModifiersModel workerAdvancedModel = WorkersCreator.createModifiers
                                    (this, true);
                                Worker advancedWorker = WorkersCreator.createWorker(this, workerAdvancedModel);
                                insects.Add(advancedWorker);
                                break;
                        }
                        break;
                    case <5:
                        switch (GetRandom.randomInt(0, 2))
                        {
                            case 0:
                                ModifiersModel warriorBasicModel = WarriorsCreator.createModifiers
                                    (this, false);
                                insects.Add(WarriorsCreator.createWarrior(this, warriorBasicModel));
                                break;
                            case 1:
                                ModifiersModel warriorAdvancedModel = WarriorsCreator.createModifiers
                                    (this, true);
                                insects.Add(WarriorsCreator.createWarrior(this, warriorAdvancedModel));
                                break;
                        }
                        break;
                    case <6:
                        insects.Add(SpecialCreator.createSpecial(this));
                        break;
                    case 7:
                        if (queen.getQueenAmount() > 0)
                        {
                            Queen newQueen = QueensCreator.createQueen(this);
                            switch (GetRandom.randomInt(0, 2))
                            {
                                case 0:
                                    Colony newColony = new Colony(this.name);
                                    newColony.setupColony(newQueen, 
                                        new List<Worker>(), new List<Warrior>(), new List<Special>());
                                    life.addColony(newColony);
                                    break;
                                case 1:
                                    break;
                            }
                            queen.decreaseQueenAmount();
                        }
                        break;
                }
            }
        }

        public void deleteInsect(ActingInsect insect)
        {
            insects.Remove(insect);
        }

        public void addResources(int branches, int leafs, int dewdrops, int stones)
        {
            resources[Resources.branch] += branches;
            resources[Resources.leaf] += leafs;
            resources[Resources.dewDrop] += dewdrops;
            resources[Resources.stone] += stones;
        }
    }
}