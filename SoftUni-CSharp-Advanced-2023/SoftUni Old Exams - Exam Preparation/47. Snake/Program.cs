using System;
//-S*B. - empty - snake - food(count) - 2 side lair(jump) - trail(change - with .)
using System.Linq;
class Program
{
    static char[][] matrixChar;
    static int snakeRow;
    static int snakeCol;
    static int foodQuantity = 0;
    static void Main(string[] args)
    {
        int sizeMatrix = int.Parse(Console.ReadLine());//6 size
        matrixChar = new char[sizeMatrix][];//jagged? //can it work with just with matrixChar?
        for (int row = 0; row < sizeMatrix; row++)
        {
            matrixChar[row] = Console.ReadLine().ToCharArray();
            if (matrixChar[row].Contains('S'))
            {
                snakeRow = row;
                snakeCol = Array.IndexOf(matrixChar[row], 'S');
                //-----S
                //----B-
                //------
                //------
                //--B---
                //--*---
            }
        }
        while (foodQuantity < 10)
        {
            string command = Console.ReadLine();
            matrixChar[snakeRow][snakeCol] = '.';
            switch (command)
            {
                case "up":
                    snakeRow--;
                    break;
                case "down":
                    snakeRow++;
                    break;
                case "left":
                    snakeCol--;
                    break;
                case "right":
                    snakeCol++;
                    break;
            }
            if (!IsValidCell(snakeRow, snakeCol, matrixChar))
            {
                Console.WriteLine("Game over!");
                Console.WriteLine($"Food eaten: {foodQuantity}");
                PrintMatrix();
                return;
            }
            if (matrixChar[snakeRow][snakeCol] == '*')
            {
                foodQuantity++;
            }
            if (matrixChar[snakeRow][snakeCol] == 'B')
            {
                matrixChar[snakeRow][snakeCol] = '.';
                for (int row = 0; row < matrixChar.Length; row++)
                {
                    if (matrixChar[row].Contains('B'))
                    {
                        snakeRow = row;
                        snakeCol = Array.IndexOf(matrixChar[row], 'B');
                        matrixChar[snakeRow][snakeCol] = '.';
                        break;
                    }
                }
            }
            matrixChar[snakeRow][snakeCol] = 'S';
        }
        Console.WriteLine("You won! You fed the snake.");
        Console.WriteLine($"Food eaten: {foodQuantity}");
        PrintMatrix();
    }
    static bool IsValidCell(int row, int col, char[][] matrix)
    {
        return row >= 0 && row < matrix.Length && col >= 0 && col < matrix[row].Length;
    }
    static void PrintMatrix()
    {
        for (int row = 0; row < matrixChar.Length; row++)
        {
            Console.WriteLine(new string(matrixChar[row]));
        }
    }
}
