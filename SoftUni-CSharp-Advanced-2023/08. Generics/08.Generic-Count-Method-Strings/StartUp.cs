using GenericMethodCountStrings;
using System;
Box<string> box = new();//list
int n = int.Parse(Console.ReadLine());
for (int i = 0; i < n; i++)
{
    string input = Console.ReadLine();

    box.Add(input);
}

string itemCompare = Console.ReadLine();
Console.WriteLine(box.Count(itemCompare));