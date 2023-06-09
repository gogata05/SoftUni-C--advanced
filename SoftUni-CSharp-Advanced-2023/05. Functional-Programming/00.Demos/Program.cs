using System;

Action<string> printName = (x) => Console.WriteLine(x);
//Action<string> printName = PrintName;

static void PrintName(string name)
{
    Console.WriteLine(name);
}

printName("Steven Gerrard");
PrintName("Jurgen Klopp");

Func<int, int, int> sumNumbers = (x, y) => x + y;
//Func<int, int, int> sumNumbers = SumNumbers;

static int SumNumbers(int n1, int n2)
{
    return n1 + n2;
}

Console.WriteLine(sumNumbers(5, 5));//10
Console.WriteLine(SumNumbers(1, 5));

Predicate<int> isEven = number => number % 2 == 0;
//Predicate<int> isEven = IsEven;
//Filter filter = number => number % 2 == 0;

static bool IsEven(int number)
{
    return number % 2 == 0;
}

Console.WriteLine(isEven(4));
Console.WriteLine(IsEven(4));

delegate bool Filter(int number);
