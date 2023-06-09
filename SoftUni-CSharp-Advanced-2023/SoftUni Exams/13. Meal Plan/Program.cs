using System;
using System.Collections.Generic;
using System.Linq;
class Program
{
    static void Main(string[] args)
    {
        Dictionary<string, int> mealsCalories = new Dictionary<string, int>
        {
            ["salad"] = 350,
            ["soup"] = 490,
            ["pasta"] = 680,
            ["steak"] = 790
        };
        Queue<string> meals = new Queue<string>(Console.ReadLine().Split());
        Stack<int> dailyCalories = new Stack<int>(Console.ReadLine().Split().Select(int.Parse));
        int mealsCount = 0;
        while (meals.Any() && dailyCalories.Any())
        {
            string currentMeal = meals.Dequeue();
            mealsCount++;
            int mealCalories = mealsCalories[currentMeal];
            int topCalories = dailyCalories.Peek();
            topCalories -= mealCalories;
            dailyCalories.Pop();
            dailyCalories.Push(topCalories);
            if (topCalories < 0)
            {
                int remainingCalories = Math.Abs(topCalories);
                dailyCalories.Pop();
                if (dailyCalories.Any())
                {
                    topCalories = dailyCalories.Peek();
                    topCalories -= remainingCalories;
                    dailyCalories.Pop();
                    dailyCalories.Push(topCalories);
                }
            }
            else if (topCalories == 0)
            {
                dailyCalories.Pop();
            }
        }
        if (!meals.Any())
        {
            Console.WriteLine($"John had {mealsCount} meals.");
            Console.WriteLine($"For the next few days, he can eat {string.Join(", ", dailyCalories)} calories.");
        }
        else
        {
            Console.WriteLine($"John ate enough, he had {mealsCount} meals.");
            Console.WriteLine($"Meals left: {string.Join(", ", meals)}.");
        }
    }
}