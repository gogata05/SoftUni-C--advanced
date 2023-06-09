string[] sizes = Console.ReadLine().Split(", ");//3 6
int rows = int.Parse(sizes[0]);//3
int cols = int.Parse(sizes[1]);//6
int[,] matrix = new int[rows, cols];
int sum = 0;
for (int row = 0; row < rows; row++)
{
    int[] dataArray = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
    for (int col = 0; col < cols; col++)
    {
        matrix[row, col] = dataArray[col];
        sum += matrix[row, col];
    }
}


Console.WriteLine(rows);
Console.WriteLine(cols);
Console.WriteLine(sum);

void PrintMatrix(int[,] matrix)
{
    //PrintMatrix(matrix);
    for (int row = 0; row < matrix.GetLength(0); row++)
    {
        for (int col = 0; col < matrix.GetLength(1); col++)
        {
            Console.Write(matrix[row, col] + " ");
        }
        Console.WriteLine();
    }
}