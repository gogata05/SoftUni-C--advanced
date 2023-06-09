using System;
using System.Linq;

int[] sizesArray = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(n => int.Parse(n)).ToArray();
char[,] matrix = new char[sizesArray[0], sizesArray[1]];
for (int row = 0; row < matrix.GetLength(0); row++)
{
    char[] charArray = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(n => char.Parse(n)).ToArray();
    for (int col = 0; col < matrix.GetLength(1); col++)
    {
        matrix[row, col] = charArray[col];
    }
}
int count = 0;
for (int row = 0; row < matrix.GetLength(0) - 1; row++)
{
    for (int col = 0; col < matrix.GetLength(1) - 1; col++)
    {
        if (matrix[row, col] == matrix[row, col + 1]
            && matrix[row, col] == matrix[row + 1, col + 1]
            && matrix[row, col] == matrix[row + 1, col])
        {
            count++;
        }
    }
}
Console.WriteLine(count);