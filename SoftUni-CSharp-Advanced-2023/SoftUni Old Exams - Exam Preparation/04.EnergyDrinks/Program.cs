using System;
using System.Collections.Generic;
using System.Linq;

namespace Test04
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Queue<int> queueNumCaffeinе = new Queue<int>(Console.ReadLine().Split(", ",StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));//34, 2, 3
            //Stack<int> stackNumDrink = new Stack<int>(Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));



            Stack<int> stackNumCaffeinе = new Stack<int>(Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
            Queue<int> queueNumDrink = new Queue<int>(Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
            int caffeinTotal = 0;
            while (queueNumDrink.Count != 0 && stackNumCaffeinе.Count != 0)
            {
                int currentCoffeinInDrink = stackNumCaffeinе.Peek() * queueNumDrink.Peek();
                //40, 100, 250
                if (caffeinTotal + currentCoffeinInDrink <= 300)
                {
                    stackNumCaffeinе.Pop();
                    queueNumDrink.Dequeue();
                    caffeinTotal += currentCoffeinInDrink;
                }
                else
                {
                    stackNumCaffeinе.Pop();
                    int remove = queueNumDrink.Dequeue();
                    queueNumDrink.Enqueue(remove);//?
                    if (caffeinTotal <= 30)
                    {
                        caffeinTotal = 0;
                    }
                    else
                    {
                        caffeinTotal -= 30;
                    }
                }
            }

            if (queueNumDrink.Count == 0)
            {
                Console.WriteLine($"At least Stamat wasn't exceeding the maximum caffeine.");
            }
            else
            {

                Console.WriteLine($"Drinks left: {string.Join(", ", queueNumDrink)}");

            }

            Console.WriteLine($"Stamat is going to sleep with {caffeinTotal} mg caffeine.");
        }
    }
}
