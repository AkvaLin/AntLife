using System;

namespace Practic.Insects
{
    public class Queen: Insect
    {
        public readonly string name;
        public readonly int newQueenAmount;
        public readonly int timeForNewInsect;

        public Queen(string name, int newQueenAmount, int timeForNewInsect)
        {
            this.name = name;
            this.newQueenAmount = newQueenAmount;
            this.timeForNewInsect = timeForNewInsect;
        }

        public void setupQueen(Colony.Colony colony, int health, int protection, int damage)
        {
            this.type = Types.queen;
            this.colony = colony;
            this.health = health;
            this.protection = protection;
            this.damage = damage;
        }

        public int[] getQueenData()
        {
            int[] data = new int[]{this.health, this.protection, this.damage ?? 0};
            return data;
        }

        public override void AboutMe()
        {
            Console.WriteLine($"Меня зовут {name}");
            base.AboutMe();
            Console.WriteLine($"Так как я королева, то могу откладывать личинки, " +
                              $"{timeForNewInsect} - именно столько дней необходимо подождаь, " +
                              $"чтобы выросла новая личинка. " +
                              $"Также королевы способны воспроизвести только ограниченное количество новых королев." +
                              $"Например, я - {newQueenAmount}");
        }
    }
}