namespace Practic.Interfaces
{
    public interface IWorker
    {
        Resources[]? resources { get; set; }
        int? resourcesAmount { get; set; }
        bool? resourceCollectionType { get; set; }

        static void collectResource(Heap heap)
        {
        }
    }
}