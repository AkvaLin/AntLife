using System;

namespace Practic
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Нажмите любую кнопку, чтобы начать");
            Console.ReadKey();
            Console.Clear();
            LifeCycle lifeCycle = new LifeCycle();
            lifeCycle.day();
        }
    }
}