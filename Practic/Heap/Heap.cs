using System.Collections.Generic;

namespace Practic
{
    public class Heap
    {
        public Dictionary<Resources, int> resources;

        public Heap(int branchAmount = default, int leafAmount = default,
            int dewdropAmount = default, int stoneAmount = default)
        {
            resources = new Dictionary<Resources, int>() 
            {
                {Resources.branch, branchAmount},
                {Resources.leaf, leafAmount},
                {Resources.dewDrop,dewdropAmount},
                {Resources.stone,stoneAmount},
            };
        }
    }
}