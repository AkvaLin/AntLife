using System.Collections.Generic;

namespace Practic
{
    public static class Shuffle
    {
        public static void shuffle<T>(this IList<T> list)  
        {  
            int n = list.Count;  
            while (n > 1) {  
                n--;  
                int k = GetRandom.randomInt(0, n + 1);  
                T value = list[k];  
                list[k] = list[n];  
                list[n] = value;  
            }  
        }
    }
}