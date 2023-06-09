using System;

namespace Date_Modifier; // because of class name collision

public class StartUp
{
    static void Main(string[] args)
    {
        string input1 = Console.ReadLine();
        string input2 = Console.ReadLine();

        int dayDiff = DateModifier.GetDifferenceInDays(input1, input2);

        Console.WriteLine(dayDiff);
    }
}