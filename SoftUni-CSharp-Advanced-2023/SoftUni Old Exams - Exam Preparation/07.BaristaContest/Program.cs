using System;
using System.Collections.Generic;
using System.Linq;
namespace Test07
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<int> queueNum = new Queue<int>(Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));//20, 35, 100, 27, 56, 30, 30

            Stack<int> stackNum = new Stack<int>(Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));//45, 20, 144, 173, 100, 40, 30

            Dictionary<int, string> dictionaryList = new Dictionary<int, string>()
            {
                {50,"Cortado"},
                {75 , "Espresso"},
                {100 , "Capuccino"},
                {150 , "Americano"},
                {200 , "Latte"}
            };

            Dictionary<string, int> dictionaryToPrint = new Dictionary<string, int>() { };

            while (queueNum.Any() && stackNum.Any())
            {
                int sum = queueNum.Peek() + stackNum.Peek();
                if (dictionaryList.ContainsKey(sum))//?
                {
                    if (!dictionaryToPrint.ContainsKey(dictionaryList[sum]))
                    {
                        dictionaryToPrint.Add(dictionaryList[sum], 0);
                    }
                    dictionaryToPrint[dictionaryList[sum]]++;//?
                    queueNum.Dequeue();
                    stackNum.Pop();
                }
                else
                {
                    queueNum.Dequeue();
                    int remove = stackNum.Pop();
                    remove -= 5;
                    stackNum.Push(remove);
                }
            }

            if (queueNum.Count == 0 && stackNum.Count == 0)
            {
                Console.WriteLine($"Nina is going to win! She used all the coffee and milk!");
            }
            else
            {
                Console.WriteLine($"Nina needs to exercise more! She didn't use all the coffee and milk!");
            }

            if (queueNum.Count == 0)
            {
                Console.WriteLine($"Coffee left: none");
            }
            else
            {
                Console.WriteLine($"Coffee left: " + string.Join(", ", queueNum));
            }

            if (stackNum.Count == 0)
            {
                Console.WriteLine($"Milk left: none");
            }
            else
            {
                Console.WriteLine($"Milk left: " + string.Join(", ", stackNum));
            }

            foreach (var item in dictionaryToPrint.OrderBy(x => x.Value).ThenByDescending(y => y.Key))
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }
        }
    }
}
