using System;
using System.Collections.Generic;
using System.Linq;

namespace TestBlacksmith
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<int> queueNumSteel = new Queue<int>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));//40 50 70 120 10 20 
            Stack<int> stackNumCarbon = new Stack<int>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));

            Dictionary<int, string> dictionaryList = new Dictionary<int, string>()
            {
                {70,"Gladius"},
                {80,"Shamshir"},
                {90,"Katana"},
                {110,"Sabre"},
                {150,"Broadsword"}
            };
            Dictionary<string, int> dictionaryToPrint = new Dictionary<string, int>() { };
            int count = 0;
            while (queueNumSteel.Any() && stackNumCarbon.Any())
            {
                int sum = queueNumSteel.Peek() + stackNumCarbon.Peek();//90=40+50
                if (dictionaryList.ContainsKey(sum))
                {
                    if (!dictionaryToPrint.ContainsKey(dictionaryList[sum]))
                    {
                        dictionaryToPrint.Add(dictionaryList[sum], 0);
                    }
                    dictionaryToPrint[dictionaryList[sum]]++;
                    queueNumSteel.Dequeue();
                    stackNumCarbon.Pop();
                    count++;
                }
                else
                {
                    queueNumSteel.Dequeue();
                    int increase = stackNumCarbon.Pop() + 5;
                    stackNumCarbon.Push(increase);
                }
            }

            if (count != 0)
            {
                Console.WriteLine($"You have forged {count} swords.");
            }
            else
            {
                Console.WriteLine("You did not have enough resources to forge a sword.");
            }

            if (queueNumSteel.Count == 0)
            {
                Console.WriteLine("Steel left: none");
            }
            else
            {
                Console.WriteLine($"Steel left: " + string.Join(", ", queueNumSteel));
            }

            if (stackNumCarbon.Count == 0)
            {
                Console.WriteLine("Carbon left: none");
            }
            else
            {
                Console.WriteLine($"Carbon left: " + string.Join(", ", stackNumCarbon));
            }

            foreach (var item in dictionaryToPrint.OrderBy(x => x.Key))
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }
        }
    }
}
