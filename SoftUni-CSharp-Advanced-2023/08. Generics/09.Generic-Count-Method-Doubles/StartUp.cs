using GenericMethodCountDouble;
using System;
Box<double> box = new();//list
int n = int.Parse(Console.ReadLine());
for (int i = 0; i < n; i++)
{
    double input = double.Parse(Console.ReadLine());

    box.Add(input);
}

double itemCompare = double.Parse(Console.ReadLine());
Console.WriteLine(box.Count(itemCompare));