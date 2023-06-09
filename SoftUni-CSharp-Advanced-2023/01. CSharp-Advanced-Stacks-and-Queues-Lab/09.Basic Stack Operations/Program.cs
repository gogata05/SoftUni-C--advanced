using System;
using System.Collections.Generic;
using System.Linq;
int[] arrayElements = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
int[] arrayNumbers = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
int elementsToPush = arrayElements[0];//5
int elementsToPop = arrayElements[1];//2
int specialNumber = arrayElements[2];//13
Stack<int> stack = new();

for (int i = 0; i < elementsToPush; i++)
{
    stack.Push(arrayNumbers[i]);
}
for (int i = 0; i < elementsToPop; i++)
{
    stack.Pop();
}
if (stack.Contains(specialNumber))
{
    Console.WriteLine("true");
}
else
{
    if (stack.Any())
    {
        Console.WriteLine(stack.Min());
    }
    else
    {
        Console.WriteLine(0);
    }
}