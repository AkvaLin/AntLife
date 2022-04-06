using Practic.Interfaces;
using Practic.Modifiers;

namespace Practic.Insects
{
    public class Worker: ActingInsect, IWorker
    {
        public Resources[] resources { get; set; }
        public int? resourcesAmount { get; set; }
        public bool? resourceCollectionType { get; set; }  // true - &, false - ||

        public void setupWorker(Colony.Colony colony, int health, int protection, ModifiersModel modifiers, 
            int? resourcesAmount)
        {
        this.type = Types.worker;
        this.health = health;
        this.protection = protection;
        this.modifiers = modifiers;
        this.colony = colony;
        this.resourcesAmount = resourcesAmount;
        }

        public void setupResourcesSettings(Resources[] resources, bool? resourceCollectionType)
        {
            this.resources = resources;
            this.resourceCollectionType = resourceCollectionType;
        }
        
        public void collectResource(Heap heap)
        {
        }
    }
}