using System;
using System.Collections.Generic;
using System.Linq;

namespace TestBakerShop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 16.8 32.4 19.5 25 
            // 15 30 45.5 48.6 25.2 
            double[] waterArray = Console.ReadLine().Split(" ").Select(double.Parse).ToArray();
            double[] flourArray = Console.ReadLine().Split(" ").Select(double.Parse).ToArray();

            Queue<double> queueNumWater = new Queue<double>(waterArray);
            Stack<double> stackNumFlour = new Stack<double>(flourArray);

            Dictionary<double, string> dictionaryList = new Dictionary<double, string>()
            {
                {50,"Croissant"},
                {40,"Muffin"},
                {30,"Baguette"},
                {20,"Bagel"}
            };
            Dictionary<string, int> dictionaryToPrint = new Dictionary<string, int>();

            while (queueNumWater.Any() && stackNumFlour.Any())
            {
                double sum = queueNumWater.Peek() + stackNumFlour.Peek(); // 42 = 16.8 + 25.2
                double procentWater = (queueNumWater.Peek() * 100) / sum;

                if (dictionaryList.ContainsKey(procentWater)) // 40
                {
                    if (!dictionaryToPrint.ContainsKey(dictionaryList[procentWater]))
                    {
                        dictionaryToPrint.Add(dictionaryList[procentWater], 0);
                    }

                    dictionaryToPrint[dictionaryList[procentWater]]++;
                    queueNumWater.Dequeue();
                    stackNumFlour.Pop();
                }
                else
                {
                    if (!dictionaryToPrint.ContainsKey("Croissant"))
                    {
                        dictionaryToPrint.Add("Croissant", 0);
                    }

                    dictionaryToPrint["Croissant"]++;
                    double water = queueNumWater.Dequeue();
                    double flour = stackNumFlour.Pop();
                    double left = water - flour;
                    left = Math.Abs(left);
                    stackNumFlour.Push(left);
                }
            }

            foreach (var item in dictionaryToPrint.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }

            if (queueNumWater.Count == 0)
            {
                Console.WriteLine("Water left: None");
            }
            else
            {
                Console.WriteLine("Water left: " + string.Join(", ", queueNumWater));
            }

            if (stackNumFlour.Count == 0)
            {
                Console.WriteLine("Flour left: None");
            }
            else
            {
                Console.WriteLine("Flour left: " + string.Join(", ", stackNumFlour));
            }
        }
    }
}
