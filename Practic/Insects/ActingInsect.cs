using System;
using System.Collections.Generic;
using Practic.Modifiers;

namespace Practic.Insects
{
    public abstract class ActingInsect: Insect
    {
        protected int turnCounter;
        protected bool isLegend = false;
        protected bool isSprinter = false;
        protected bool alive = true;
        protected bool canAttack = false;
        public void AboutQueen()
        {
            Queen queen = colony.getQueen();
            int[] queenData = queen.getQueenData();

            Console.WriteLine($"Королева {queen.name}\n" +
                              "Статус королевы:\n" + 
                              $"\tЗдовроье: {queenData[0]}\n" +
                              $"\tЗащита: {queenData[1]}\n" +
                              $"\tУрон: {queenData[2]}\n" +
                              $"\t\tМожеть создать {queen.getQueenAmount()} королев\n" +
                              $"\t\tЦикл роста личинок равен {queen.timeForNewInsect} дням\n\n");
        }

        public void removeInsect()
        {
            colony.deleteInsect(this);
        }

        public void increaseProtection()
        {
            if (getModifiers().specialWarriorsModifiers == SpecialWarriorsModifiers.heavy)
            {
                health *= 2;
                protection *= 2;
            }
        }
        
        public virtual void action(Heap? heap, ActingInsect? target, bool hasLegend){}

        public int getTurnCounter()
        {
            return turnCounter;
        }

        public bool getIsLegend()
        {
            return isLegend;
        }

        public bool isAlive()
        {
            return alive;
        }

        public void killInsect()
        {
            alive = false;
            removeInsect();
        }

        public virtual int getBitesAmount()
        {
            return 0;
        }

        public virtual Dictionary<Resources, int> getResources()
        {
            return new Dictionary<Resources, int>();
        }

        public bool getCanAttack()
        {
            return canAttack;
        }
    }
}