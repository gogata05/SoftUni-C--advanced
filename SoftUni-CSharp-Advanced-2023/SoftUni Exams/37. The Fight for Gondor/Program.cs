using System;
using System.Linq;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        int waves = int.Parse(Console.ReadLine());
        Queue<int> plates = new Queue<int>(Console.ReadLine()
            .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse));

        for (int wave = 1; wave <= waves; wave++)
        {
            Stack<int> orcs = new Stack<int>(Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));

            if (wave % 3 == 0)
            {
                plates.Enqueue(int.Parse(Console.ReadLine()));
            }

            while (orcs.Count > 0 && plates.Count > 0)
            {
                int orc = orcs.Pop();
                int plate = plates.Peek();

                if (orc > plate)
                {
                    orcs.Push(orc - plate);
                    plates.Dequeue();
                }
                else if (plate > orc)
                {
                    plates.Enqueue(plates.Dequeue() - orc);
                }
                else
                {
                    plates.Dequeue();
                }
            }

            if (plates.Count == 0)
            {
                Console.WriteLine("The orcs successfully destroyed the Gondor's defense.");
                Console.WriteLine($"Orcs left: {string.Join(", ", orcs)}");
                return;
            }
        }

        Console.WriteLine("The people successfully repulsed the orc's attack.");
        Console.WriteLine($"Plates left: {string.Join(", ", plates)}");
    }
}