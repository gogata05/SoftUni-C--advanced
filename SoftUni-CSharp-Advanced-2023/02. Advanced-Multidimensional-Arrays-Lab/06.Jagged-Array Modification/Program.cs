using System;
using System.Linq;
int rows = int.Parse(Console.ReadLine());
int[][] jaggedArray = new int[rows][];
for (int row = 0; row < rows; row++)
{
    jaggedArray[row] = Console.ReadLine().Split().Select(int.Parse).ToArray();
}
string command = Console.ReadLine().ToLower();
while (command != "end")
{
    string[] commandArray = command.Split();
    int row = int.Parse(commandArray[1]);
    int col = int.Parse(commandArray[2]);
    int value = int.Parse(commandArray[3]);
    if (row < 0 || col < 0 || row >= jaggedArray.Length || col >= jaggedArray[row].Length)
    {
        Console.WriteLine("Invalid coordinates");
    }
    else
    {
        if (commandArray[0] == "add")
        {
            jaggedArray[row][col] += value;
        }
        else
        {
            jaggedArray[row][col] -= value;
        }
    }
    command = Console.ReadLine().ToLower();
}
for (int row = 0; row < jaggedArray.Length; row++)
{
    for (int col = 0; col < jaggedArray[row].Length; col++)
    {
        Console.Write($"{jaggedArray[row][col]} ");
    }
    Console.WriteLine();
}



