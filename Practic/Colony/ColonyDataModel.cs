namespace Practic.Colony
{
    public struct ColonyDataModel
    {
        public readonly ColonyColors name;
        public readonly int antsAmount;
        public readonly int workersAmount;
        public readonly int warriorsAmount;
        public readonly int specialAmount;
        public readonly string queenName;
        public readonly int resoursesAmount;

        public ColonyDataModel(ColonyColors name, 
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