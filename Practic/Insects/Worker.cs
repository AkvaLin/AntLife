using System;
using System.Collections.Generic;
using Practic.Modifiers;

namespace Practic.Insects
{
    public sealed class Worker: ActingInsect
    {
        private bool isAdvanced;
        private Resources[] resources;
        private int resourcesAmount;
        private bool? resourceCollectionType;  // true - &, false - ||
        private Dictionary<Resources, int> temporaryResources = new Dictionary<Resources, int>()
        {
            {Resources.branch, 0},
            {Resources.leaf, 0},
            {Resources.dewDrop,0},
            {Resources.stone,0},
        };

        public void setupWorker(Colony.Colony colony, int health, int protection, ModifiersModel modifiers, 
            int resourcesAmount)
        {
            this.type = Types.worker;
            this.health = health;
            this.protection = protection;
            this.modifiers = modifiers;
            this.colony = colony;
            this.resourcesAmount = resourcesAmount;
            this.turnCounter = 1;
            if (modifiers.specialWorkersModifiers == SpecialWorkersModifiers.experienced)
            {
                resources = new Resources[] {Resources.leaf, Resources.stone, Resources.branch, Resources.dewDrop};
                if (isAdvanced & colony.name == ColonyColors.red)
                {
                    resourceCollectionType = true;
                }
                else
                {
                    resourceCollectionType = false;
                }
            }
            else
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
        }

        public void setupAdvanced(bool isAdvanced)
        {
            this.isAdvanced = isAdvanced;
        }

        public override void action(Heap? heap, ActingInsect? target, bool hasLegend)
        {
            int flag = 1;
            if (getModifiers().specialWorkersModifiers == SpecialWorkersModifiers.forgetful)
            {
                flag = GetRandom.randomInt(0, 3);
            }
            if ((resourceCollectionType ?? false) && flag != 0)
            {
                for (int i = 0; i < resourcesAmount; i++)
                {
                    if (heap.resources[resources[i]] != 0)
                    {
                        temporaryResources[resources[i]]++;
                        heap.resources[resources[i]]--;
                    }
                }
            }
            else if ((!resourceCollectionType ?? false) && flag != 0)
            {
                int tempResourcesAmount = resourcesAmount;
                for (int i = 0; i < tempResourcesAmount; i++)
                {
                    if (heap.resources[resources[i]] == tempResourcesAmount)
                    {
                        temporaryResources[resources[i]] += resourcesAmount;
                        heap.resources[resources[i]] -= resourcesAmount;
                        break;
                    }
                    if (heap.resources[resources[i]] != 0)
                    {
                        temporaryResources[resources[i]]++;
                        heap.resources[resources[i]]--;
                        tempResourcesAmount--;
                    }
                }
            }

            turnCounter = 0;
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

        public override Dictionary<Resources, int> getResources()
        {
            return temporaryResources;
        }
    }
}