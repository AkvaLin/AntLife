using System.Collections.Generic;

namespace Practic
{
    public class SpecialEvent
    {
        public static void action(List<Colony.Colony> colonies)
        {
            for (int i = 0; i < colonies.Count; i++)
            {
                colonies[i].clearSpecials();
            }
        }
    }
}