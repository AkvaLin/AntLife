using System.Collections.Generic;
using Practic.Insects;
using Practic.Modifiers;

namespace Practic.Creators
{
    public class WorkersCreator
    {
        private static ModifiersModel createModifiers(Colony.Colony colony, bool isAdvanced)
        {
            ModifiersModel modifiers;
            
            switch (colony.name)
            {
                case ColonyColors.black:
                    modifiers = new ModifiersModel(isAdvanced ? BasicModifiers.senior : BasicModifiers.advanced,
                        isAdvanced ? SpecialWorkersModifiers.sprinter : null,
                        null);
                    break;
                case ColonyColors.red:
                    modifiers = new ModifiersModel(isAdvanced ? BasicModifiers.elite : BasicModifiers.senior,
                        isAdvanced ? SpecialWorkersModifiers.experienced : null,
                        null);
                    break;
                case ColonyColors.green:
                    modifiers = new ModifiersModel(BasicModifiers.advanced, 
                        isAdvanced ? SpecialWorkersModifiers.forgetful : null, 
                        null);
                    break;
                default:
                    modifiers = new ModifiersModel();
                    break;
            }
            return modifiers;
        }

        public static Worker createWorker(Colony.Colony colony, ModifiersModel modifiers)
        {
            Worker worker = new Worker();

            switch (modifiers.basicModifier)
            {
                case BasicModifiers.usual:
                    worker.setupWorker(colony, 1, 0, modifiers, 1);
                    break;
                case BasicModifiers.senior:
                    worker.setupWorker(colony, 2, 1, modifiers, 1);
                    break;
                case BasicModifiers.legendary:
                    worker.setupWorker(colony, 10, 6, modifiers, 3);
                    break;
                case BasicModifiers.elite:
                    worker.setupWorker(colony, 8, 4, modifiers, 2);
                    break;
                case BasicModifiers.advanced:
                    worker.setupWorker(colony, 6, 2, modifiers, 2);
                    break;
            }

            return worker;
        }
        public static List<Worker> CreateWorkers(Colony.Colony colony)
        {
            List<Worker> workers = new List<Worker>();
            int amountOfBasic;
            int amountOfAdvanced;
            
            switch (colony.name)
            {
                case ColonyColors.black:
                    amountOfBasic = GetRandom.randomInt(0, 14);
                    amountOfAdvanced = 14 - amountOfBasic;
                    for (int i = 0; i < amountOfBasic; i++)
                    {
                        Worker worker = createWorker(colony, createModifiers(colony, false));
                        worker.setupResourcesSettings(new Resources[] {Resources.dewDrop, Resources.stone},
                            false);
                        workers.Add(worker);
                    }
                    for (int i = 0; i < amountOfAdvanced; i++)
                    {
                        Worker worker = createWorker(colony, createModifiers(colony, true));
                        worker.setupResourcesSettings(new Resources[] {Resources.leaf, Resources.stone},
                            false);
                        workers.Add(worker);
                    }
                    break;
                case ColonyColors.green:
                    amountOfBasic = GetRandom.randomInt(0, 14);
                    amountOfAdvanced = 14 - amountOfBasic;
                    for (int i = 0; i < amountOfBasic; i++)
                    {
                        Worker worker = createWorker(colony, createModifiers(colony, false));
                        worker.setupResourcesSettings(new Resources[] {Resources.branch, Resources.branch},
                            false);
                        workers.Add(worker);
                    }
                    for (int i = 0; i < amountOfAdvanced; i++)
                    {
                        Worker worker = createWorker(colony, createModifiers(colony, true));
                        worker.setupResourcesSettings(new Resources[] {Resources.dewDrop, Resources.branch}, 
                            false);
                        workers.Add(worker);
                    }
                    break;
                case ColonyColors.red:
                    amountOfBasic = GetRandom.randomInt(0, 14);
                    amountOfAdvanced = 14 - amountOfBasic;
                    for (int i = 0; i < amountOfBasic; i++)
                    {
                        Worker worker = createWorker(colony, createModifiers(colony, false));
                        worker.setupResourcesSettings(new Resources[] {Resources.dewDrop, Resources.dewDrop},
                            false);
                        workers.Add(worker);
                    }
                    for (int i = 0; i < amountOfAdvanced; i++)
                    {
                        Worker worker = createWorker(colony, createModifiers(colony, true));
                        worker.setupResourcesSettings(new Resources[] {Resources.branch, Resources.stone}, 
                            true);
                        workers.Add(worker);
                    }
                    break;
            }
            return workers;
        }
    }
}