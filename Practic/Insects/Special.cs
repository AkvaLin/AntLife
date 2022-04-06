using Practic.Interfaces;
using Practic.Modifiers;

namespace Practic.Insects
{
    public class Special: ActingInsect, IWarrior, IWorker
    {
        private string name;
        private bool isCivilian;
        private bool canBeAttacked;
        private SpecialsModifiersModel modifiersModel;
        public int? targetsAmount { get; set; }
        public int? bitesAmount { get; set; }
        public Resources[]? resources { get; set; }
        public int? resourcesAmount { get; set; }
        public bool? resourceCollectionType { get; set; }

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
            this.canBeAttacked = model.takeDamageMod == SpecialsModifiers.invulnerable ? false : true;
            this.resources = model.specialMod == SpecialsModifiers.experienced ? new Resources[]{Resources.branch, Resources.leaf, Resources.stone, Resources.dewDrop} : resources;
        }
        
        public void attack(ActingInsect insect)
        {
        }
        public void collectResource(Heap heap)
        {
        }

        public void action()
        {
            
        }
    }
}