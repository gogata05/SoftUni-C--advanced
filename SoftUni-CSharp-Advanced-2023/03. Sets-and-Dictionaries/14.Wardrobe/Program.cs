using System;
using System.Collections.Generic;
Dictionary<string, Dictionary<string, int>> dictionary = new();
int n = int.Parse(Console.ReadLine());
for (int i = 0; i < n; i++)
{
    string[] inputArray = Console.ReadLine().Split(new string[] { " -> ", "," }, StringSplitOptions.RemoveEmptyEntries);
    string color = inputArray[0];
    if (!dictionary.ContainsKey(color))
    {
        dictionary[color] = new();
    }
    for (int j = 1; j < inputArray.Length; j++)
    {
        string currentClothing = inputArray[j];
        if (!dictionary[color].ContainsKey(currentClothing))
        {
            dictionary[color].Add(currentClothing, 0);
        }
        dictionary[color][currentClothing]++;
    }
}
string[] findColorCloth = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
foreach (var color in dictionary)
{
    Console.WriteLine($"{color.Key} clothes:");
    foreach (var cloth in color.Value)
    {
        string printItem = $"* {cloth.Key} - {cloth.Value}";
        if (color.Key == findColorCloth[0] && cloth.Key == findColorCloth[1])
        {
            printItem += " (found!)";
        }
        Console.WriteLine(printItem);
    }
}
