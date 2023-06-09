using BoxOfInteger;
using System;
Box<int> box = new();//list
int n = int.Parse(Console.ReadLine());

for (int i = 0; i < n; i++)
{
    int item = int.Parse(Console.ReadLine());
    box.Add(item);
}
Console.WriteLine(box.ToString());