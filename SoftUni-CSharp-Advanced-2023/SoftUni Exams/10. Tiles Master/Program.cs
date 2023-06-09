using System;
using System.Collections.Generic;
using System.Linq;

namespace Test10
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<int> stackNumWhite = new Stack<int>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));//35 16 30 3 25 9 20 

            Queue<int> queueNumGrey = new Queue<int>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));//20 9 25 3 30 16 35 

            Dictionary<int, string> dictionaryList = new Dictionary<int, string>()
            {
                {40,"Sink"},
                {50,"Oven"},
                {60,"Countertop"},
                {70,"Wall"}
            };
            Dictionary<string, int> dictionaryToPrint = new Dictionary<string, int>() { };
            int floor = 0;
            while (stackNumWhite.Any() && queueNumGrey.Any())
            {
                if (stackNumWhite.Peek() == queueNumGrey.Peek())
                {
                    int sum = stackNumWhite.Peek() + queueNumGrey.Peek();
                    if (dictionaryList.ContainsKey(sum))//40/50/60/70
                    {
                        if (!dictionaryToPrint.ContainsKey(dictionaryList[sum]))
                        {
                            dictionaryToPrint.Add(dictionaryList[sum], 0);
                        }
                        dictionaryToPrint[dictionaryList[sum]]++;
                        queueNumGrey.Dequeue();
                        stackNumWhite.Pop();
                    }
                    else
                    {
                        if (!dictionaryToPrint.ContainsKey("Floor"))
                        {
                            dictionaryToPrint.Add("Floor", 0);
                        }
                        dictionaryToPrint["Floor"]++;
                        queueNumGrey.Dequeue();
                        stackNumWhite.Pop();
                    }
                }
                else
                {
                    int halfWhite = stackNumWhite.Pop() / 2;//?
                    stackNumWhite.Push(halfWhite);
                    int remove = queueNumGrey.Dequeue();
                    queueNumGrey.Enqueue(remove);
                }
            }

            if (stackNumWhite.Count == 0)
            {
                Console.WriteLine("White tiles left: none");
            }
            else
            {
                Console.WriteLine($"White tiles left: " + string.Join(", ", stackNumWhite));
            }

            if (queueNumGrey.Count == 0)
            {
                Console.WriteLine("Grey tiles left: none");
            }
            else
            {
                Console.WriteLine($"Grey tiles left: " + string.Join(", ", queueNumGrey));
            }

            foreach (var item in dictionaryToPrint.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }
        }
    }
}
