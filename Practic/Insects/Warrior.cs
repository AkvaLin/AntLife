using System;
using Practic.Modifiers;

namespace Practic.Insects
{
    public class Warrior: ActingInsect
    {
        public int? targetsAmount;
        public int? bitesAmount;

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
        }
        
        void action(ActingInsect insect, int damageTo)
        {
        }
        
        public override void AboutMe()
        {
            base.AboutMe();
            Console.WriteLine($"Задача воина - сражаться. " +
                              $"Я способен атаковать сразу {targetsAmount} целец, " +
                              $"За одну атаку я делаю количество укусов равное {bitesAmount}");
        }
    }
}