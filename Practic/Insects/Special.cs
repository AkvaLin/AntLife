using System;
using Practic.Modifiers;

namespace Practic.Insects
{
    public class Special: ActingInsect
    {
        private string name;
        private bool isCivilian;
        private bool canBeAttacked;
        private SpecialsModifiersModel modifiersModel;
        private int? targetsAmount;
        private int? bitesAmount;
        private Resources[]? resources;
        private int? resourcesAmount;
        private bool? resourceCollectionType;

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
        }

        void attack(ActingInsect insect)
        {
        }
        void collectResource(Heap heap)
        {
        }

        public void action()
        {
            
        }
        
        public override void AboutMe()
        {
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
    }
}