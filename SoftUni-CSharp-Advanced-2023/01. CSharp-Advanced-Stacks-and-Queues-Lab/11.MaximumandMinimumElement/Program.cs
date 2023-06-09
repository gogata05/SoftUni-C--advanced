using System;
using System.Collections.Generic;
using System.Linq;

int count = int.Parse(Console.ReadLine());

Stack<int> stack = new();

for (int i = 0; i < count; i++)
{
    string[] commandArray = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
    int command = int.Parse(commandArray[0]);

    switch (command)
    {
        case 1:
            int number = int.Parse(commandArray[1]);
            stack.Push(number);
            break;
        case 2:
            stack.Pop();
            break;
        case 3:
            if (stack.Any())
            {
                Console.WriteLine(stack.Max());
            }
            break;
        case 4:
            if (stack.Any())
            {
                Console.WriteLine(stack.Min());
            }
            break;
    }
}

Console.WriteLine(string.Join(", ", stack));