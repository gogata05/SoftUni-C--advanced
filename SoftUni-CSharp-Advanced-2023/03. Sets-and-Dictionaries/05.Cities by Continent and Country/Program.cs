using System;
using System.Collections.Generic;
Dictionary<string, Dictionary<string, List<string>>> dictionary = new();
int n = int.Parse(Console.ReadLine());
for (int i = 0; i < n; i++)
{
    string[] input = Console.ReadLine().Split();
    string continent = input[0];
    string country = input[1];
    string city = input[2];

    if (!dictionary.ContainsKey(continent))
    {
        dictionary.Add(continent, new());
    }

    if (!dictionary[continent].ContainsKey(country))
    {
        dictionary[continent].Add(country, new());
    }

    dictionary[continent][country].Add(city);
}
foreach (var continent in dictionary)
{
    Console.WriteLine($"{continent.Key}:");
    foreach (var country in continent.Value)
    {
        Console.WriteLine($"  {country.Key} -> {string.Join(", ", country.Value)}");
    }
}