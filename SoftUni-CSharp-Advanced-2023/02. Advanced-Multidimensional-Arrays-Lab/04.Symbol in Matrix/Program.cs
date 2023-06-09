int sizes = int.Parse(Console.ReadLine());
int rows = sizes;
int cols = sizes;
char[,] matrix = new char[rows, cols];
for (int row = 0; row < rows; row++)
{
    char[] charArray = Console.ReadLine().ToCharArray();

    for (int col = 0; col < cols; col++)
    {
        matrix[row, col] = charArray[col];
    }
}
char target = char.Parse(Console.ReadLine());

bool foundBool = false;
for (int i = 0; i < matrix.GetLength(0); i++)
{
    for (int j = 0; j < matrix.GetLength(1); j++)
    {
        if (matrix[i, j] == target)
        {
            Console.WriteLine($"({i}, {j})");
            foundBool = true;
            break;
        }
    }

    if (foundBool) break;
}
if (!foundBool) Console.WriteLine($"{target} does not occur in the matrix");


