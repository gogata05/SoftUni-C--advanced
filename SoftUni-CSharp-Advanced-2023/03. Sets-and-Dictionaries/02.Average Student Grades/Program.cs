using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
Dictionary<string, List<decimal>> dictionary = new();
int n = int.Parse(Console.ReadLine());
for (int i = 0; i < n; i++)
{
    string[] inputArray = Console.ReadLine().Split();
    string studentName = inputArray[0];
    decimal grade = decimal.Parse(inputArray[1]);

    if (!dictionary.ContainsKey(studentName))
    {
        dictionary.Add(studentName, new());
    }
    dictionary[studentName].Add(grade);
}
foreach (var studentGrade in dictionary)
{
    //Console.WriteLine($"{studentGrade.Key} -> {string.Join(" ", studentGrade.Value.Select(x => $"{x:f2}").ToList())} (avg: {studentGrade.Value.Average():f2})");
    Console.Write($"{studentGrade.Key} -> ");
    foreach (var grade in studentGrade.Value)
    {
        Console.Write($"{grade:f2} ");
    }
    Console.WriteLine($"(avg: {studentGrade.Value.Average():f2})");
}
