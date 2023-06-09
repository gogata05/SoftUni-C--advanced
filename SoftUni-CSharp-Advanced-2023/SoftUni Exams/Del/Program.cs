       //all 8 adjacent elements:
       //up/down/left/right
       //up left/up right/down left/down right
       //up
if (IsInRange(matrix, row - 1, col))
{
    if (matrix[row - 1, col] == "<")
    {
        //firstPlayer--;
    }
    else if (matrix[row - 1, col] == ">")
    {
        //secondPlayer--;
    }
    //matrix[row - 1, col] = "X";
}
//down
if (IsInRange(matrix, row + 1, col))
{
    if (matrix[row + 1, col] == "<")
    {
        //firstPlayer--;
    }
    else if (matrix[row + 1, col] == ">")
    {
        //secondPlayer--;
    }
    //matrix[row + 1, col] = "X";
}
//left
if (IsInRange(matrix, row, col - 1))
{
    if (matrix[row, col - 1] == "<")
    {
        //firstPlayer--;
    }
    else if (matrix[row, col - 1] == ">")
    {
        //secondPlayer--;
    }
    //matrix[row, col - 1] = "X";
}
//right
if (IsInRange(matrix, row, col + 1))
{
    if (matrix[row, col + 1] == "<")
    {
        //firstPlayer--;
    }
    else if (matrix[row, col + 1] == ">")
    {
        //secondPlayer--;
    }
    //matrix[row, col + 1] = "X";
}
//up left//up right//down left//down right
//up left
if (IsInRange(matrix, row - 1, col - 1))
{
    if (matrix[row - 1, col - 1] == "<")
    {
        //firstPlayer--;
    }
    else if (matrix[row - 1, col - 1] == ">")
    {
        //secondPlayer--;
    }
    //matrix[row - 1, col - 1] = "X";
}
//up right
if (IsInRange(matrix, row - 1, col + 1))
{
    if (matrix[row - 1, col + 1] == "<")
    {
        //firstPlayer--;
    }
    else if (matrix[row - 1, col + 1] == ">")
    {
        //secondPlayer--;
    }
    //matrix[row - 1, col + 1] = "X";
}
//down left
if (IsInRange(matrix, row + 1, col - 1))
{
    if (matrix[row + 1, col - 1] == "<")
    {
        //firstPlayer--;
    }
    else if (matrix[row + 1, col - 1] == ">")
    {
        //secondPlayer--;
    }
    //matrix[row + 1, col - 1] = "X";
}
//down right
if (IsInRange(matrix, row + 1, col + 1))
{
    if (matrix[row + 1, col + 1] == "<")
    {
        //firstPlayer--;
    }
    else if (matrix[row + 1, col + 1] == ">")
    {
       //secondPlayer--;
    }
    //matrix[row + 1, col + 1] = "X";
}

private static bool IsInRange(string[,] matrix, int row, int col)//isInRange method outside of the main
    => row >= 0 && row < matrix.GetLength(0) && col >= 0 && col < matrix.GetLength(1);
