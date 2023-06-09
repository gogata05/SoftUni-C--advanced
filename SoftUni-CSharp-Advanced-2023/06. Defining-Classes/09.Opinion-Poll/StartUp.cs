using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses;

public class StartUp
{
    static void Main(string[] args)
    {
        List<Person> peopleOver30 = new();

        int n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            string[] inputArray = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            Person person = new(inputArray[0], int.Parse(inputArray[1]));

            if (person.Age > 30)
            {
                peopleOver30.Add(person);
            }
        }

        foreach (var person in peopleOver30.OrderBy(p => p.Name))
        {
            Console.WriteLine($"{person.Name} - {person.Age}");
        }
    }
}