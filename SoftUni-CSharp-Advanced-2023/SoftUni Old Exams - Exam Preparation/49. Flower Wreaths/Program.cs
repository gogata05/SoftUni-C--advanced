using System;
using System.Collections.Generic;
using System.Linq;

namespace TestFlowerWreaths
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<int> stackNumLilies = new Stack<int>(Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));//10, 15, 2, 7, 9, 13 

            Queue<int> queueNumRoses = new Queue<int>(Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));//2, 10, 8, 12, 0, 5

            int count = 0;
            int flowersLeft = 0;

            while (stackNumLilies.Any() && queueNumRoses.Any())
            {
                int sum = stackNumLilies.Peek() + queueNumRoses.Peek();
                if (sum == 15)
                {
                    stackNumLilies.Pop();
                    queueNumRoses.Dequeue();
                    count++;
                }
                else if (sum > 15)
                {
                    int decrease = stackNumLilies.Pop() - 2;
                    stackNumLilies.Push(decrease);
                }
                else
                {
                    flowersLeft += stackNumLilies.Pop();
                    flowersLeft += queueNumRoses.Dequeue();
                }
            }

            if (flowersLeft != 0)
            {
                int storedFlowers = flowersLeft / 15;
                count += storedFlowers;
            }

            if (count >= 5)
            {
                Console.WriteLine($"You made it, you are going to the competition with {count} wreaths!");
            }
            else
            {
                int difference = 5 - count;
                Console.WriteLine($"You didn't make it, you need {difference} wreaths more!");
            }
        }
    }
}