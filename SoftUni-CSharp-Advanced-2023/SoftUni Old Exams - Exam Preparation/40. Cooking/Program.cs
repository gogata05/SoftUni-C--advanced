using System;
using System.Collections.Generic;
using System.Linq;
namespace TestCooking
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<int> queueNumLiquids = new Queue<int>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));

            Stack<int> stackNumIngredients = new Stack<int>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));

            Dictionary<int, string> dictionaryList = new Dictionary<int, string>()
            {
                {25,"Bread"},
                {50,"Cake"},
                {75,"Pastry"},
                {100,"Fruit Pie"}
            };

            Dictionary<string, int> dictionaryToPrint = new Dictionary<string, int>()
            {
                {"Bread",0},
                {"Cake",0},
                {"Pastry",0},
                {"Fruit Pie",0}
            };

            while (queueNumLiquids.Any() && stackNumIngredients.Any())
            {
                int sum = queueNumLiquids.Peek() + stackNumIngredients.Peek();
                if (dictionaryList.ContainsKey(sum))
                {
                    dictionaryToPrint[dictionaryList[sum]]++;
                    queueNumLiquids.Dequeue();
                    stackNumIngredients.Pop();
                }
                else
                {
                    queueNumLiquids.Dequeue();
                    int remove = stackNumIngredients.Pop() + 3;
                    stackNumIngredients.Push(remove);
                }
            }

            if (dictionaryToPrint["Bread"] != 0 && dictionaryToPrint["Cake"] != 0 && dictionaryToPrint["Pastry"] != 0 && dictionaryToPrint["Fruit Pie"] != 0)
            {
                Console.WriteLine("Wohoo! You succeeded in cooking all the food!");
            }
            else
            {
                Console.WriteLine("Ugh, what a pity! You didn't have enough materials to cook everything.");
            }

            if (queueNumLiquids.Any())
            {
                Console.WriteLine($"Liquids left: " + string.Join(", ", queueNumLiquids));
            }
            else
            {
                Console.WriteLine("Liquids left: none");
            }

            if (stackNumIngredients.Any())
            {
                Console.WriteLine($"Ingredients left: " + string.Join(", ", stackNumIngredients));
            }
            else
            {
                Console.WriteLine("Ingredients left: none");
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
