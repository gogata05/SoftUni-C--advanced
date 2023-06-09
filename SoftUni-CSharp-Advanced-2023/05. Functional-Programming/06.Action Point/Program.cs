using System;

Action<string[]> printAction = (x)
    => Console.WriteLine(string.Join(Environment.NewLine, x));

string[] strings = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

printAction(strings);
