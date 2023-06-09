using System;
using System.Collections.Generic;
using System.Linq;
Queue<string> arraySongs = new(Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries));
while (arraySongs.Any())
{
    string[] commandArray = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
    string command = commandArray[0];
    switch (command)
    {
        case "Play":
            arraySongs.Dequeue();
            break;
        case "Add":
            string song = string.Join(" ", commandArray.Skip(1));
            if (arraySongs.Contains(song))
            {
                Console.WriteLine($"{song} is already contained!");
            }
            else
            {
                arraySongs.Enqueue(song);
            }
            break;
        case "Show":
            Console.WriteLine(string.Join(", ", arraySongs));
            break;
    }
}
Console.WriteLine("No more songs!");