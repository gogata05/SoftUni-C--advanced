using GenericMethodSwapIntegers;
using System;
using System.Linq;
Box<int> box = new();
int n = int.Parse(Console.ReadLine());
for (int i = 0; i < n; i++)
{
    int input = int.Parse(Console.ReadLine());
    box.Add(input);
}
int[] commandArray = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse).ToArray();

box.Swap(commandArray[0], commandArray[1]);
Console.WriteLine(box.ToString());