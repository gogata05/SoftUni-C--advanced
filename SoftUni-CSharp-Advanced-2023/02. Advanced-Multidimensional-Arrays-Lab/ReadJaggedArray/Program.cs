using System;
using System.Linq;
int rows = int.Parse(Console.ReadLine());
int[][] jaggedArray = new int[rows][];

for (int row = 0; row < rows; row++)
{
    jaggedArray[row] = Console.ReadLine().Split().Select(int.Parse).ToArray();
}
for (int row = 0; row < jaggedArray.Length; row++)
{
    for (int col = 0; col < jaggedArray[row].Length; col++)
    {
        Console.Write(jaggedArray[row][col] + " ");
    }
    Console.WriteLine();
}