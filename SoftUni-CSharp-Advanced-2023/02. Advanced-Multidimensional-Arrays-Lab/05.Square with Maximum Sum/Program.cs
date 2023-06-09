using System;
using System.Linq;
int[,] matrix = ReadMatrix();
int maxSum = 0;
int maxRow = 0; 
int maxCol = 0;
for (int row = 0; row < matrix.GetLength(0); row++)
{
    for (int col = 0; col < matrix.GetLength(1); col++)
    {
        int currentSum = 0;
        if (row >= matrix.GetLength(0) - 1 || col >= matrix.GetLength(1) -1)
        {
            continue;
        }
        currentSum += matrix[row, col];
        currentSum += matrix[row + 1, col];
        currentSum += matrix[row, col + 1]; 
        currentSum += matrix[row + 1, col + 1];
        if (currentSum > maxSum)
        {
            maxSum = currentSum;
            maxRow = row;
            maxCol = col;
        }
    }
}
Console.WriteLine($"{matrix[maxRow, maxCol]} {matrix[maxRow, maxCol + 1]}");
Console.WriteLine($"{matrix[maxRow + 1, maxCol]} {matrix[maxRow + 1, maxCol + 1]}");
Console.WriteLine(maxSum);

static int[,] ReadMatrix()
{
    string[] sizes = Console.ReadLine().Split(", ");
    int rows = int.Parse(sizes[0]);//3
    int cols = int.Parse(sizes[1]);//6
    int[,] matrix = new int[rows, cols];
    for (int row = 0; row < rows; row++)
    {
        int[] data = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
        for (int col = 0; col < cols; col++)
        {
            matrix[row, col] = data[col];
        }
    }
    return matrix;
}