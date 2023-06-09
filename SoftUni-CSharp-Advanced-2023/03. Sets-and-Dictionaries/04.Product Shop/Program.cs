using System;
using System.Collections.Generic;
using System.Linq;
Dictionary<string, Dictionary<string, double>> dictionary = new();
string input = Console.ReadLine();
while (input != "Revision")
{
    string[] inputArray = input.Split(", ");
    string shop = inputArray[0];
    string product = inputArray[1];
    double price = double.Parse(inputArray[2]);
    if (!dictionary.ContainsKey(shop))
    {
        dictionary.Add(shop, new());
    }
    if (!dictionary[shop].ContainsKey(product))
    {
        dictionary[shop].Add(product, 0);
    }
    dictionary[shop][product] = price;
    input = Console.ReadLine();
}
dictionary = dictionary.OrderBy(s => s.Key).ToDictionary(s => s.Key, s => s.Value);
foreach (var shop in dictionary)
{
    Console.WriteLine($"{shop.Key}->");
    foreach (var product in shop.Value)
    {
        Console.WriteLine($"Product: {product.Key}, Price: {product.Value}");
    }
}
