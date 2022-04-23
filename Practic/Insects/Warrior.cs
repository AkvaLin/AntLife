using System;
using System.Collections.Generic;
using Practic.Modifiers;

namespace Practic.Insects
{
    public sealed class Warrior: ActingInsect
    {
        private int? targetsAmount;
        private int? bitesAmount;

        public void setupWarrior(Colony.Colony colony, int health, int protection, int damage,
            ModifiersModel modifiers, int targetsAmount, int bitesAmount)
        {
            this.colony = colony;
            this.health = health;
            this.protection = protection;
            this.damage = damage;
            this.modifiers = modifiers;
            this.type = Types.warrior;
            this.targetsAmount = targetsAmount;
            this.bitesAmount = bitesAmount;
            this.turnCounter = targetsAmount;
            this.canAttack = true;
        }

        public override void action(Heap? heap, ActingInsect? target, bool hasLegend)
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
        
        public override void AboutMe()
        {
            base.AboutMe();
            Console.WriteLine($"Задача воина - сражаться. " +
                              $"Я способен атаковать сразу {targetsAmount} целец, " +
                              $"За одну атаку я делаю количество укусов равное {bitesAmount}");
        }

        public override int getBitesAmount()
        {
            return bitesAmount ?? 1;
        }
    }
}