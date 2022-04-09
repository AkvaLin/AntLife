using System;
using Practic.Modifiers;

namespace Practic.Insects
{
    public class Worker: ActingInsect
    {
        private bool isAdvanced;
        private Resources[] resources;
        private int? resourcesAmount;
        private bool? resourceCollectionType;  // true - &, false - ||

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

        public void setupResourcesSettings()
        {
            switch (colony.name)
            {
                case ColonyColors.black:
                    if (isAdvanced)
                    {
                        resources = new Resources[] {Resources.leaf, Resources.stone};
                        resourceCollectionType = false;
                    }
                    else
                    {
                        resources = new Resources[] {Resources.dewDrop, Resources.stone};
                        resourceCollectionType = false;
                    }
                    break;
                case ColonyColors.green:
                    if (isAdvanced)
                    {
                        resources = new Resources[] {Resources.dewDrop, Resources.branch};
                        resourceCollectionType = false;
                    }
                    else
                    {
                        resources = new Resources[] {Resources.branch, Resources.branch};
                        resourceCollectionType = false;
                    }
                    break;
                case ColonyColors.red:
                    if (isAdvanced)
                    {
                        resources = new Resources[] {Resources.branch, Resources.stone};
                        resourceCollectionType = true;
                    }
                    else
                    {
                        resources = new Resources[] {Resources.dewDrop, Resources.dewDrop};
                        resourceCollectionType = false;
                    }
                    break;
            }
        }

        public void setupAdvanced(bool isAdvanced)
        {
            this.isAdvanced = isAdvanced;
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