using System;
using System.Linq;
string[] sizes = Console.ReadLine().Split(", ");
int rows = int.Parse(sizes[0]);
int cols = int.Parse(sizes[1]);
int[,] matrix = new int[rows, cols];
for (int row = 0; row < rows; row++)
{
    int[] dataArray = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
    for (int col = 0; col < cols; col++)
    {
        matrix[row, col] = dataArray[col];
    }
}
for (int col = 0; col < cols; col++)
{
    int sum = 0;
    for (int row = 0; row < rows; row++)
    {
        sum += matrix[row, col];
        //Console.Write(matrix[row,col] + " ");
    }
    Console.WriteLine(sum);
}
