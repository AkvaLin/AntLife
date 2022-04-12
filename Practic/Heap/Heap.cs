namespace Practic
{
    public struct Heap
    {
        private int? branchAmount;
        private int? leafAmount;
        private int? dewdropAmount;
        private int? stoneAmount;

        public Heap(int? branchAmount = default, int? leafAmount = default, int? dewdropAmount = default, int? stoneAmount = default)
        {
            this.branchAmount = branchAmount;
            this.leafAmount = leafAmount;
            this.dewdropAmount = dewdropAmount;
            this.stoneAmount = stoneAmount;
        }
    }
}