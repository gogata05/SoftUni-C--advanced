using System;
using Tuple;
string[] personArray = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries);
string[] drinkArray = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries);
string[] numbersArray = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

CustomTuple<string, string> nameAddress =
    new($"{personArray[0]} {personArray[1]}", personArray[2]);
CustomTuple<string, int> nameBeer =
    new(drinkArray[0], int.Parse(drinkArray[1]));
CustomTuple<int, double> numbers =
    new(int.Parse(numbersArray[0]), double.Parse(numbersArray[1]));

Console.WriteLine(nameAddress);
Console.WriteLine(nameBeer);
Console.WriteLine(numbers);