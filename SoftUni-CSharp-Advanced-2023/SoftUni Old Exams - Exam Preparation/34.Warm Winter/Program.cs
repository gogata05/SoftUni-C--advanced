using System;
using System.Collections.Generic;
using System.Linq;

namespace TestWarmWinter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<int> stackNumHats = new Stack<int>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));

            Queue<int> queueNumScarfs = new Queue<int>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));

            List<int> listNumSets = new List<int>() { };

            while (stackNumHats.Any() && queueNumScarfs.Any())
            {
                int set = stackNumHats.Peek() + queueNumScarfs.Peek();

                if (stackNumHats.Peek() > queueNumScarfs.Peek())
                {
                    listNumSets.Add(set);
                    stackNumHats.Pop();
                    queueNumScarfs.Dequeue();
                }
                else if (stackNumHats.Peek() < queueNumScarfs.Peek())
                {
                    stackNumHats.Pop();
                }
                else if (stackNumHats.Peek() == queueNumScarfs.Peek())
                {
                    queueNumScarfs.Dequeue();
                    int increment = stackNumHats.Pop() + 1;
                    stackNumHats.Push(increment);
                }
            }

            int maxPriceSet = listNumSets.Max();//?
            Console.WriteLine($"The most expensive set is: {maxPriceSet}");

            foreach (var item in listNumSets)
            {
                Console.Write($"{item} ");
            }
        }
    }
}