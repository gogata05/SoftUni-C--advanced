int size = int.Parse(Console.ReadLine());
int rows = size;
int cols = size;
int[,] matrix = new int[rows, cols];

for (int row = 0; row < rows; row++)
{
    int[] data = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
    for (int col = 0; col < cols; col++)
    {
        matrix[row, col] = data[col];
    }
}
int sum = 0;
for (int i = rows - 1; i >= 0; i--)
{
    sum += (matrix[i, i]);
}
Console.WriteLine(sum);