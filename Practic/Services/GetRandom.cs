using System;

namespace Practic
{
    public class GetRandom
    {
        private static Random random = new Random();

        public static int randomInt(int from, int to)
        {
            return random.Next(from, to);
        }
    }
}