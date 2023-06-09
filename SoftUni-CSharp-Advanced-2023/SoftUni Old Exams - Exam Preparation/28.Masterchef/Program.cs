using System;
using System.Collections.Generic;
using System.Linq;
namespace TestMasterchef
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<int> queueNumIngredients = new Queue<int>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));//10 10 12 8 10 12

            Stack<int> stackNumFreshness = new Stack<int>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));//25 15 50 25 25 15 

            Dictionary<int, string> dictionaryList = new Dictionary<int, string>()
            {
                {150,"Dipping sauce"},
                {250,"Green salad"},
                {300,"Chocolate cake"},
                {400,"Lobster"}
            };
            Dictionary<string, int> dictionaryToPrint = new Dictionary<string, int>() { };
            int count = 0;
            while (queueNumIngredients.Any() && stackNumFreshness.Any())
            {
                if (queueNumIngredients.Peek() == 0)
                {
                    queueNumIngredients.Dequeue();
                    continue;
                }
                int multiply = queueNumIngredients.Peek() * stackNumFreshness.Peek();
                if (dictionaryList.ContainsKey(multiply))
                {
                    if (!dictionaryToPrint.ContainsKey(dictionaryList[multiply]))
                    {
                        dictionaryToPrint.Add(dictionaryList[multiply], 0); //?
                    }

                    dictionaryToPrint[dictionaryList[multiply]]++;
                    queueNumIngredients.Dequeue();
                    stackNumFreshness.Pop();
                    count++;
                }
                else
                {
                    stackNumFreshness.Pop();
                    int remove = queueNumIngredients.Dequeue() + 5;
                    queueNumIngredients.Enqueue(remove);
                }
            }

            if (count >= 4 && dictionaryToPrint.Count == 4)
            {
                Console.WriteLine("Applause! The judges are fascinated by your dishes!");
            }
            else
            {
                Console.WriteLine("You were voted off. Better luck next year.");
            }


            if (queueNumIngredients.Any())
            {
                int ingredientsSum = 0;
                if (queueNumIngredients.Count >= 2)
                {
                    foreach (int element in queueNumIngredients)
                    {
                        ingredientsSum += element;
                    }
                }
                else if (queueNumIngredients.Count == 1)
                {
                    ingredientsSum += queueNumIngredients.Dequeue();
                }

                Console.WriteLine($"Ingredients left: {ingredientsSum}");
            }

            if (dictionaryToPrint.Any())
            {
                foreach (var item in dictionaryToPrint.OrderBy(x => x.Key))
                {
                    Console.WriteLine($"# {item.Key} --> {item.Value}");
                }
            }


        }
    }
}
