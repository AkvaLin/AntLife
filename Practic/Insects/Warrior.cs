using Practic.Interfaces;

namespace Practic.Insects
{
    public class Warrior: ActingInsect, IWarrior
    {
        public int? targetsAmount { get; set; }
        public int? bitesAmount { get; set; }
        
        static void attack(ActingInsect insect)
        {
        }
    }
}