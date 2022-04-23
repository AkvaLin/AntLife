using System;
using Practic.Modifiers;

namespace Practic.Insects
{
    public abstract class Insect
    {
        protected Types type;
        protected int health;
        protected int protection;
        protected int? damage;
        protected bool canBeAttacked = true;
        protected ModifiersModel? modifiers;
        protected Colony.Colony colony;

        public virtual void AboutMe()
        {
            Console.Write("Я ");
            switch (type)
            {
                case Types.queen:
                    Console.WriteLine("королева");
                    break;
                case Types.special:
                    Console.WriteLine("особое насекомое");
                    break;
                case Types.warrior:
                    Console.WriteLine("воин");
                    break;
                case Types.worker:
                    Console.WriteLine("рабочий");
                    break;
            }
            Console.WriteLine("\nМои характеристики:\n" +
                              $"\tЗдоровье: {health}\n" +
                              $"\tЗащита: {protection}");
            if (damage != null)
            {
                Console.WriteLine($"\tУрон: {damage}");
            }
            Console.Write("Принадлежу к колонии ");
            switch (colony.name)
            {
                case ColonyColors.green:
                    Console.WriteLine("зеленых\n");
                    break;
                case ColonyColors.red:
                    Console.WriteLine("красных\n");
                    break;
                case ColonyColors.black:
                    Console.WriteLine("черных\n");
                    break;
            }
            if (modifiers != null)
            {
                ModifiersModel model = modifiers ?? new ModifiersModel();
                switch (model.basicModifier)
                {
                    case BasicModifiers.usual:
                        Console.WriteLine("Я отношусь к обычным насекомым");
                        break;
                    case BasicModifiers.senior:
                        Console.WriteLine("Я отношусь к старшим насекомым");
                        break;
                    case BasicModifiers.advanced:
                        Console.WriteLine("Я отношусь к продвинутым насекомым");
                        break;
                    case BasicModifiers.elite:
                        Console.WriteLine("Я отношусь к элитным насекомым");
                        break;
                    case BasicModifiers.legendary:
                        Console.WriteLine("Я отношусь к легендарным насекомым");
                        break;
                }
                switch (model.specialWarriorsModifiers)
                {
                    case SpecialWarriorsModifiers.anomalistic:
                        Console.WriteLine("Правад есть одно но... Я слегка странный и атакую своих вместо врагов :/");
                        break;
                    case SpecialWarriorsModifiers.heavy:
                        Console.WriteLine("Мое здоровье и защита увеличиваются вдвое. " +
                                          "Я являюсь настоящей защитой для своих друзей," +
                                          "ведь враги сфокусированы на мне");
                        break;
                    case SpecialWarriorsModifiers.vindictive:
                        Console.WriteLine("Я крайне мстительный, " +
                                          "обладаю черной магией и способен убить своего убийцу, " +
                                          "даже если он бессмертный");
                        break;
                }
                switch (model.specialWorkersModifiers)
                {
                    case SpecialWorkersModifiers.experienced:
                        Console.WriteLine("Благодаря своему опыту и усердным тренировкам " +
                                          "я способен нести любой ресурс");
                        break;
                    case SpecialWorkersModifiers.forgetful:
                        Console.WriteLine("У меня есть проблемки с памятью. " +
                                          "Из-за этого я могу забыть взять ресурс из кучи :'(");
                        break;
                    case SpecialWorkersModifiers.sprinter:
                        Console.WriteLine("Я настолько быстр, что меня никогда не смогут атаковать первым))");
                        break;
                }
            }
        }
        public Types getType()
        {
            return type;
        }

        public int getDamage()
        {
            return damage ?? 0;
        }

        public ColonyColors getColor()
        {
            return colony.name;
        }

        public ModifiersModel getModifiers()
        {
            return modifiers ?? new ModifiersModel();
        }

        public bool getCanBeAttacked()
        {
            return canBeAttacked;
        }

        public int getHealth()
        {
            return health;
        }

        public void takeDamage(int damage)
        {
            health -= damage;
        }

        public int getProtection()
        {
            return protection;
        }

        public Colony.Colony getColony()
        {
            return colony;
        }
    }
}