using GenericMethodSwapStrings;
using System;
using System.Linq;
Box<string> box = new();//list
int n = int.Parse(Console.ReadLine());
for (int i = 0; i < n; i++)
{
    string input = Console.ReadLine();
    box.Add(input);
}
int[] commandArray = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

box.Swap(commandArray[0], commandArray[1]);
Console.WriteLine(box.ToString());