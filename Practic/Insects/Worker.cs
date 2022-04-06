using System;
using Practic.Modifiers;

namespace Practic.Insects
{
    public class Worker: ActingInsect
    {
        public Resources[] resources;
        public int? resourcesAmount;
        public bool? resourceCollectionType;  // true - &, false - ||

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
        
        public override void AboutMe()
        {
            base.AboutMe();
            Console.WriteLine($"Я простой работяга. Могу перенести {resourcesAmount} ресурса," +
                              $" которые включают в себя:");
            for (int i = 0; i < resources.Length; i++)
            {
                switch (resources[i])
                {
                    case Resources.branch:
                        Console.WriteLine("\tВеточки");
                        break;
                    case Resources.leaf:
                        Console.WriteLine("\tЛистики");
                        break;
                    case Resources.dewDrop:
                        Console.WriteLine("\tРосинки");
                        break;
                    case Resources.stone:
                        Console.WriteLine("\tКамешки");
                        break;
                }
            }
        }
    }
}