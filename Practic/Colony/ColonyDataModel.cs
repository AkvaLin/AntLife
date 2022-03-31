namespace Practic.Colony
{
    public struct ColonyDataModel
    {
        public readonly string name;
        public readonly int antsAmount;
        public readonly int workersAmount;
        public readonly int warriorsAmount;
        public readonly int specialAmount;
        public readonly string queenName;
        public readonly int resoursesAmount;

        public ColonyDataModel(string name, 
            int antsAmount, int workersAmount, int warriorsAmount, int specialAmount,
            string queenName, int resoursesAmount)
        {
            this.name = name;
            this.antsAmount = antsAmount;
            this.workersAmount = workersAmount;
            this.warriorsAmount = warriorsAmount;
            this.specialAmount = specialAmount;
            this.queenName = queenName;
            this.resoursesAmount = resoursesAmount;
        }
    }
}