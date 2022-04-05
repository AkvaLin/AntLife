using Practic.Interfaces;

namespace Practic.Insects
{
    public class Special: ActingInsect, IWarrior, IWorker
    {
        private string name;
        private bool isWorker;
        public int? targetsAmount { get; set; }
        public int? bitesAmount { get; set; }
        public string[]? resources { get; set; }
        public int? resourcesAmount { get; set; }
        public bool? resourceCollectionType { get; set; }
        
        static void attack(ActingInsect insect)
        {
        }
        static void collectResource(Heap heap)
        {
        }
    }
}