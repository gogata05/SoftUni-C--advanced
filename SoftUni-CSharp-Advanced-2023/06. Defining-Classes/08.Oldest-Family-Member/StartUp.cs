using System;

namespace DefiningClasses;

public class StartUp
{
    static void Main(string[] args)
    {
        Family listFamily = new();//Name Age

        int n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            string[] inputArray = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);//Peter//3

            Person personNA = new(inputArray[0], int.Parse(inputArray[1]));//Name,Age

            listFamily.AddMember(personNA);
        }

        Person oldest = listFamily.GetOldestMember();//anni 5

        Console.WriteLine($"{oldest.Name} {oldest.Age}");
    }
}