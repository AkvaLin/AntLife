using System;
using System.Collections.Generic;
using System.Linq;
using Practic.Insects;

namespace Practic.Colony
{
    public class Colony
    {
        public readonly ColonyColors name;
        private Queen queen;
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
    }
}