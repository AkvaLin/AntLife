using System;
using Practic.Modifiers;

namespace Practic.Insects
{
    public class Insect
    {
        protected string type;
        protected int health;
        protected int protection;
        protected int? damage;
        protected ModifiersModel modifiers;
        protected Colony.Colony colony;

        protected void AboutMe()
        {
            Console.WriteLine($"Мой тип: {type}");
            Console.WriteLine($"Моя колония: {colony}");
            Console.WriteLine($"Здоровье: {health}; Защита {protection}");
            
            if (damage != null)
            {
                Console.WriteLine($"Урон: {damage}");
            }

            Console.WriteLine($"Модификаторы: "); // доделать
        }
    }
}