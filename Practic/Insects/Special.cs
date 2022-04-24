using System;
using System.Collections.Generic;
using Practic.Modifiers;

namespace Practic.Insects
{
    public sealed class Special: ActingInsect
    {
        private string name;
        private bool isCivilian;
        private SpecialsModifiersModel modifiersModel;
        private int? targetsAmount;
        private int? bitesAmount;
        private Resources[]? resources;
        private int? resourcesAmount;
        private bool? resourceCollectionType;
        private Dictionary<Resources, int> temporaryResources = new Dictionary<Resources, int>()
        {
            {Resources.branch, 0},
            {Resources.leaf, 0},
            {Resources.dewDrop,0},
            {Resources.stone,0},
        };

        public void setupSpecial(SpecialsModifiersModel model, string name, 
            Colony.Colony colony, int health, int protection, int? damage,
            int? targetsAmount, int? bitesAmount, Resources[]? resources, int? resourcesAmount, bool? resourceCollectionType)
        {
            this.name = name;
            this.modifiersModel = model;
            this.colony = colony;
            this.health = health;
            this.protection = protection;
            this.damage = damage;
            this.type = Types.special;
            this.targetsAmount = targetsAmount;
            this.bitesAmount = bitesAmount;
            this.resources = resources;
            this.resourcesAmount = resourcesAmount;
            this.resourceCollectionType = resourceCollectionType;
            this.isCivilian = model.resourcesMod == SpecialsModifiers.hardworking;
            this.canBeAttacked = model.takeDamageMod != SpecialsModifiers.invulnerable;
            this.resources = model.specialMod == SpecialsModifiers.experienced ? 
                new Resources[]{Resources.branch, Resources.leaf, Resources.stone, Resources.dewDrop} : resources;
            this.turnCounter = targetsAmount ?? 1;
            this.isLegend = modifiersModel.specialMod == SpecialsModifiers.legend;
            this.isSprinter = modifiersModel.specialMod == SpecialsModifiers.sprinter;
            this.canAttack = modifiersModel.attackMod == SpecialsModifiers.agressive;
        }

        private void attack(Heap heap, ActingInsect? target, bool hasLegend)
        {
            if (target != null)
            {
                if (!hasLegend)
                {
                    increaseProtection();
                    target.increaseProtection();
                }

                if (target.getCanBeAttacked() && target.getCanAttack())
                {
                    while (health > 0 && target.getHealth() > 0)
                    {
                        if (GetRandom.randomInt(0, 11) > target.getProtection()) target.takeDamage(damage * bitesAmount ?? 0);
                        if (GetRandom.randomInt(0,11) > protection) takeDamage(target.getDamage() * target.getBitesAmount());
                    }
                    if (health == 0) killInsect();
                    if (target.getModifiers().specialWarriorsModifiers == SpecialWarriorsModifiers.vindictive &&
                        target.getHealth() == 0)
                    {
                        killInsect();
                        target.killInsect();
                    }
                    else if (target.getHealth() == 0)
                    {
                        target.killInsect();
                    }
                }

                else if (target.getType() == Types.worker || 
                         target.getType() == Types.special && 
                         !target.getCanBeAttacked() &&
                         hasLegend || 
                         !target.getCanAttack() && 
                         target.getType() == Types.special && 
                         target.getCanAttack())
                {
                    if (!isSprinter)
                    {
                        Dictionary<Resources, int> tempRes = target.getResources();
                        foreach (var resource in tempRes)
                        {
                            heap.resources[resource.Key] += resource.Value;
                        }
                    }
                    else
                    {
                        Dictionary<Resources, int> tempRes = target.getResources();
                        target.getColony().addResources(tempRes[Resources.branch], tempRes[Resources.leaf], 
                            tempRes[Resources.dewDrop], tempRes[Resources.stone]);
                    }
                    target.killInsect();
                }
            }
        }
        private void collectResource(Heap heap)
        {
            if (resourceCollectionType ?? false)
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
            else
            {
                int tempResourcesAmount = resourcesAmount ?? 0;
                for (int i = 0; i < tempResourcesAmount; i++)
                {
                    if (heap.resources[resources[i]] == tempResourcesAmount)
                    {
                        temporaryResources[resources[i]] = temporaryResources[resources[i]] + resourcesAmount ?? 0;
                        heap.resources[resources[i]] = heap.resources[resources[i]] - resourcesAmount ?? 0;
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

        public override void action(Heap? heap, ActingInsect? target, bool hasLegend)
        {
            if (isCivilian)
            {
                collectResource(heap ?? new Heap());
            }
            else
            {
                attack(heap, target, hasLegend);
            }
        }
        
        public override void AboutMe()
        {
            Console.WriteLine($"Я {name}");
            base.AboutMe();
            if (isCivilian)
            {
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
            else
            {
                Console.WriteLine($"Задача воина - сражаться. " +
                                  $"Я способен атаковать сразу {targetsAmount} целец, " +
                                  $"За одну атаку я делаю количество укусов равное {bitesAmount}");
            }

            if (modifiersModel.takeDamageMod == SpecialsModifiers.invulnerable)
            {
                Console.WriteLine("Интересный факт: я неуязвимый))0)");
            }

            switch (modifiersModel.specialMod)
            {
                case SpecialsModifiers.sprinter:
                    Console.WriteLine("Я все делаю для колонии. Даже если получу критическое ранение, " +
                                      "то все равно доставлю ресурсы");
                    break;
                case SpecialsModifiers.legend:
                    Console.WriteLine("Кто-то меня любит, кто-то ненавидит," +
                                      " а все из-за моей возможности отменять все модификаторы, " +
                                      "как врагов, так и союзные");
                    break;
            }
        }
        public override int getBitesAmount()
        {
            return bitesAmount ?? 1;
        }

        public override Dictionary<Resources, int> getResources()
        {
            return temporaryResources;
        }
    }
}