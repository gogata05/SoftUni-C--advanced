using System;
using System.Collections.Generic;
using System.Linq;

namespace TestLootBox
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<int> queueNumFirst = new Queue<int>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));//10 11 8 13 5 6 

            Stack<int> stackNumSecond = new Stack<int>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));//0 4 7 3 6 23 3

            int sumItems = 0;
            while (queueNumFirst.Any() && stackNumSecond.Any())
            {
                int sum = queueNumFirst.Peek() + stackNumSecond.Peek();
                if (sum % 2 == 0)//?
                {
                    queueNumFirst.Dequeue();
                    stackNumSecond.Pop();
                    sumItems += sum;
                }
                else
                {
                    int move = stackNumSecond.Pop();
                    queueNumFirst.Enqueue(move);
                }
            }

            if (!queueNumFirst.Any())
            {
                Console.WriteLine("First lootbox is empty");
            }
            if (!stackNumSecond.Any())
            {
                Console.WriteLine("Second lootbox is empty");
            }

            if (sumItems >= 100)
            {
                Console.WriteLine($"Your loot was epic! Value: {sumItems}");
            }
            else
            {
                Console.WriteLine($"Your loot was poor... Value: {sumItems}");
            }
        }
    }
}