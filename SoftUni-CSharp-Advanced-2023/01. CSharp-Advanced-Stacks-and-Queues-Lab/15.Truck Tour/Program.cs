using System;
using System.Collections.Generic;
using System.Linq;

const int litersPerKilometer = 1;
int count = int.Parse(Console.ReadLine());
Queue<int[]> pumps = new();
int startIndex = 0;
for (int i = 0; i < count; i++)
{
    int[] pumpTokens = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
    pumps.Enqueue(pumpTokens);
}
while (true)
{
    bool isComplete = true;
    int totalLiters = 0;

    foreach (var pump in pumps)
    {
        int liters = pump[0];
        int distance = pump[1];
        totalLiters += liters;
        if (totalLiters - distance * litersPerKilometer < 0)
        {
            startIndex++;
            int[] currentPump = pumps.Dequeue();
            pumps.Enqueue(currentPump);
            isComplete = false;
            break;
        }
        totalLiters -= distance * litersPerKilometer;
    }
    if (isComplete)
    {
        Console.WriteLine(startIndex);
        break;
    }
}