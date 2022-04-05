using Practic.Interfaces;

namespace Practic.Insects
{
    public class Worker: ActingInsect, IWorker
    {
        public string[]? resources { get; set; }
        public int? resourcesAmount { get; set; }
        public bool? resourceCollectionType { get; set; }
        
        static void collectResource(Heap heap)
        {
        }
    }
}