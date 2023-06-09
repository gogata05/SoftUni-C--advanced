using System;
using System.Collections.Generic;
using System.Linq;

namespace TestBombs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<int> queueNumEffects = new Queue<int>(Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));

            Stack<int> stackNumCasing = new Stack<int>(Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));

            Dictionary<int, string> dictionaryList = new Dictionary<int, string>()
            {
                {40,"Datura Bombs"},
                {60,"Cherry Bombs"},
                {120,"Smoke Decoy Bombs"}
            };
            Dictionary<string, int> dictionaryToPrint = new Dictionary<string, int>()
            {
                {"Datura Bombs",0},
                {"Cherry Bombs",0},
                {"Smoke Decoy Bombs",0}
            };

            while (queueNumEffects.Any() && stackNumCasing.Any())
            {
                if (dictionaryToPrint.ContainsKey("Datura Bombs") && dictionaryToPrint.ContainsKey("Cherry Bombs") && dictionaryToPrint.ContainsKey("Smoke Decoy Bombs"))
                {
                    if (dictionaryToPrint["Datura Bombs"] >= 3 && dictionaryToPrint["Cherry Bombs"] >= 3 && dictionaryToPrint["Smoke Decoy Bombs"] >= 3)
                    {
                        break;
                    }
                }

                int sum = queueNumEffects.Peek() + stackNumCasing.Peek();
                if (dictionaryList.ContainsKey(sum))
                {
                    dictionaryToPrint[dictionaryList[sum]]++;
                    queueNumEffects.Dequeue();
                    stackNumCasing.Pop();
                }
                else
                {
                    int decrease = stackNumCasing.Pop() - 5;
                    stackNumCasing.Push(decrease);
                }
            }


            if ((dictionaryToPrint["Datura Bombs"] >= 3 && dictionaryToPrint["Cherry Bombs"] >= 3 && dictionaryToPrint["Smoke Decoy Bombs"] >= 3))
            {
                Console.WriteLine("Bene! You have successfully filled the bomb pouch!");
            }
            else
            {
                Console.WriteLine("You don't have enough materials to fill the bomb pouch.");
            }

            if (queueNumEffects.Count == 0)
            {
                Console.WriteLine("Bomb Effects: empty");
            }
            else
            {
                Console.WriteLine($"Bomb Effects: " + string.Join(", ", queueNumEffects));
            }

            if (stackNumCasing.Count == 0)
            {
                Console.WriteLine("Bomb Casings: empty");
            }
            else
            {
                Console.WriteLine($"Bomb Casings: " + string.Join(", ", stackNumCasing));
            }

            if (dictionaryToPrint.Any())
            {
                foreach (var item in dictionaryToPrint.OrderBy(x => x.Key))
                {
                    Console.WriteLine($"{item.Key}: {item.Value}");
                }
            }


        }
    }
}
