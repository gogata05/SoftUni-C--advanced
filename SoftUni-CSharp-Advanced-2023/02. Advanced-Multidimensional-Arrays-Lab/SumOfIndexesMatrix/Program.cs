using System;
int rows = int.Parse(Console.ReadLine());//3
int cols = int.Parse(Console.ReadLine());//3
int[,] matrix = new int[rows, cols];
// 0 1 2
// 1 2 3
// 2 3 4
for (int row = 0; row < rows; row++)
{
    for (int col = 0; col < cols; col++)
    {
        matrix[row, col] = row + col;
    }
}
for (int row = 0; row < rows; row++)
{
    for (int col = 0; col < cols; col++)
    {
        if (matrix[row, col] < 10)
        {
            Console.Write(" ");
        }
        Console.Write($"{matrix[row, col]} ");
    }
    Console.WriteLine();
}


