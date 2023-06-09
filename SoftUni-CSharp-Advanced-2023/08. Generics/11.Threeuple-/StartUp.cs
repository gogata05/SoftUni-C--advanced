using System;
using ThreeupleType;
string[] personArray = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries);
string[] drinkArray = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries);
string[] bankArray = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

Threeuple<string, string, string> person =
    new($"{personArray[0]} {personArray[1]}", personArray[2], string.Join(" ", personArray[3..]));
Threeuple<string, int, bool> drinks =
    new(drinkArray[0], int.Parse(drinkArray[1]), drinkArray[2] == "drunk");
Threeuple<string, double, string> bank =
    new(bankArray[0], double.Parse(bankArray[1]), bankArray[2]);

Console.WriteLine(person);
Console.WriteLine(drinks);
Console.WriteLine(bank);