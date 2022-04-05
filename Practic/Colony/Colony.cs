using System;
using System.Collections.Generic;
using System.Linq;
using Practic.Insects;

namespace Practic.Colony
{
    public class Colony
    {
        private ColonyColors name;
        public readonly Queen queen;
        private List<Worker> workers;
        private List<Warrior> warriors;
        private List<Special> special;
        private ColonyDataModel data;

        private Dictionary<string, int> resources = new Dictionary<string, int>()
        {
            {"Веточка", 0},
            {"Листик", 0},
            {"Росинка",0},
            {"Камушек",0},
        };

        public Colony(ColonyColors name, Queen queen, List<Worker> workers, List<Warrior> warriors, List<Special> special)
        {
            this.name = name;
            this.queen = queen;
            this.workers = workers;
            this.warriors = warriors;
            this.special = special;
        }

        private void aboutColony(ColonyDataModel data)
        {
            Console.WriteLine($"Колония <{data.name}>\n\n" +
                              $"Общая численность муравьёв: {data.antsAmount}\n" +
                              $"\tЧисленность рабочих: {data.workersAmount}\n" +
                              $"\tЧисленность воинов: {data.warriorsAmount}\n" +
                              $"\tЧисленность специальных насекомых: {data.specialAmount}\n" +
                              $"Королева {data.queenName}\n" +
                              $"Статус королевы\n" +  // Доделать
                              $"Количество ресурсов: {data.resoursesAmount}"
                              );
        }

        private void getData()
        {
            data = new ColonyDataModel(name, 
                workers.Count + warriors.Count + special.Count,
                workers.Count, 
                warriors.Count,
                special.Count,
                queen.name,
                resources.Values.Sum()
                );
        }

        public void getInfoAboutColony()
        {
            getData();
            aboutColony(this.data);
        }
    }
}