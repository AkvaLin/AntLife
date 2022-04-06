using Practic.Interfaces;
using Practic.Modifiers;

namespace Practic.Insects
{
    public class Warrior: ActingInsect, IWarrior
    {
        public int? targetsAmount { get; set; }
        public int? bitesAmount { get; set; }

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
        
        public void attack(ActingInsect insect)
        {
        }
    }
}