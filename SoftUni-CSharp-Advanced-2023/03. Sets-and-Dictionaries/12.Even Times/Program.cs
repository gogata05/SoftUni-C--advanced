using System;
using System.Collections.Generic;
using System.Linq;

Dictionary<int, int> dictionary = new();

int n = int.Parse(Console.ReadLine());

for (int i = 0; i < n; i++)
{
    int number = int.Parse(Console.ReadLine());

    if (!dictionary.ContainsKey(number))
    {
        dictionary.Add(number, 0);
    }

    dictionary[number]++;
}

Console.WriteLine(dictionary.Single(n => n.Value % 2 == 0).Key);
