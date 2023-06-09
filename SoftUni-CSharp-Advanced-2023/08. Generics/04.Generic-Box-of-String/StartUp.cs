using BoxOfString;
using System;
Box<string> box = new();//list
int n = int.Parse(Console.ReadLine());

for (int i = 0; i < n; i++)
{
    string item = Console.ReadLine();
    box.Add(item);
}
Console.WriteLine(box.ToString());

