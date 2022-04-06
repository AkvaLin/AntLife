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
    }
}