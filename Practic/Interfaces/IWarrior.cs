using Practic.Insects;

namespace Practic.Interfaces
{
    public interface IWarrior
    {
        int? targetsAmount { get; set; }
        int? bitesAmount { get; set; }
        
        static void attack(ActingInsect insect)
        {
        }
    }
}