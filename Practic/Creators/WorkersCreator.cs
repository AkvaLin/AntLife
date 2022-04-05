using System.Collections.Generic;
using Practic.Insects;

namespace Practic.Creators
{
    public class WorkersCreator
    {
        public static List<Worker> CreateWorkers(ColonyColors colonyColor)
        {
            switch (colonyColor)
            {
                case ColonyColors.black:
                    return new List<Worker>();
                    break;
                case ColonyColors.green:
                    return new List<Worker>();
                    break;
                case ColonyColors.red:
                    return new List<Worker>();
                    break;
                default:
                    return new List<Worker>();
                    break;
            }
        }
    }
}