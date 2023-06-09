using System;
using System.Collections.Generic;
using System.Linq;
List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();

numbers = numbers.OrderByDescending(x => x).Take(3).ToList();

Console.WriteLine(string.Join(" ", numbers));

//int[] numbers = Console.ReadLine()​.Split().Select(int.Parse).OrderByDescending(n => n)​​​.ToArray();​
//int count = numbers.Length >= 3 ? 3 : numbers.Length;​
//for (int i = 0; i < count; i++)​
//Console.Write($"{numbers[i]} ");​
