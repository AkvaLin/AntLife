namespace Practic.Colony
{
    public struct ColonyDataModel
    {
        public readonly ColonyColors name;
        public readonly int antsAmount;
        public readonly int workersAmount;
        public readonly int warriorsAmount;
        public readonly int specialAmount;
        public readonly int resoursesAmount;

        public ColonyDataModel(ColonyColors name, 
            int antsAmount, int workersAmount, int warriorsAmount, int specialAmount, int resoursesAmount)
        {
            this.name = name;
            this.antsAmount = antsAmount;
            this.workersAmount = workersAmount;
            this.warriorsAmount = warriorsAmount;
            this.specialAmount = specialAmount;
            this.resoursesAmount = resoursesAmount;
        }
    }
}