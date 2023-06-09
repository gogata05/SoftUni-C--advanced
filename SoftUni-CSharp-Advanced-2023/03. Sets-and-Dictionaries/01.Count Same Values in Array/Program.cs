using System;
using System.Collections.Generic;
using System.Linq;

double[] input = Console.ReadLine().Split().Select(double.Parse).ToArray();

Dictionary<double, int> dictionary = new();

foreach (var number in input)
{
    if (!dictionary.ContainsKey(number))
    {
        dictionary.Add(number, 0);
    }

    dictionary[number]++;
}

foreach (var occurence in dictionary)
{
    Console.WriteLine($"{occurence.Key} - {occurence.Value} times");
}