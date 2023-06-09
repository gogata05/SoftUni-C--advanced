using System;
using System.Linq;

int rows = int.Parse(Console.ReadLine());
int[][] jaggedArray = new int[rows][];
for (int row = 0; row < rows; row++)
{
    jaggedArray[row] = Console.ReadLine().Split().Select(int.Parse).ToArray();
}
foreach (int[] array in jaggedArray)
{
    Console.WriteLine(String.Join(" ", array));
}