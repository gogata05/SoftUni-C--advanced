using System;
using System.Drawing;

namespace TestBlind_Man_sBuff
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] sizeMatrixArray = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);//5//8
            int rows = int.Parse(sizeMatrixArray[0]);//5
            int cols = int.Parse(sizeMatrixArray[1]);//8
            char[,] matrixChar = new char[rows, cols];
            int countMoves = 0;
            int countTochedOpponents = 0;
            int countOpponents = 0;

            int curRow = -1;
            int curCol = -1;

            int oldRow = -1;
            int oldCol = -1;
            for (int row = 0; row < rows; row++)
            {
                string[] array = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);//for matrix with empty spaces
                string text = string.Concat(array);//for matrix with empty spaces
                for (int col = 0; col < cols; col++)
                {
                    matrixChar[row, col] = text[col];
                    if (matrixChar[row, col] == 'B')//blindMan
                    {
                        curRow = row;
                        curCol = col;
                    }
                    else if (matrixChar[row, col] == 'P')
                    {
                        countOpponents++;
                    }
                }
            }
            string command = Console.ReadLine();
            while (command != "Finish")
            {
                oldRow = curRow;
                oldCol = curCol;
                matrixChar[curRow, curCol] = '-';//last move
                switch (command)
                {
                    case "up":
                        curRow--;
                        break;
                    case "down":
                        curRow++;
                        break;
                    case "left":
                        curCol--;
                        break;
                    case "right":
                        curCol++;
                        break;
                }
                string currentChar = matrixChar[curRow, curCol].ToString();
                if (curRow < 0 || curCol < 0 || matrixChar.GetLength(0) <= curRow ||
                    matrixChar.GetLength(1) <= curCol || matrixChar[curRow, curCol] == 'O') //if we are out end of loop
                {
                    curRow = oldRow;
                    curCol = oldCol;
                    matrixChar[curRow, curCol] = 'B';
                    command = Console.ReadLine();
                    continue;
                }

                if (matrixChar[curRow, curCol] == 'P')
                {
                    countTochedOpponents++;
                }
                //- B O P - empty - blindMan - Opsticales - players
                countMoves++;
                matrixChar[curRow, curCol] = 'B';//new move
                if (countTochedOpponents == countOpponents)
                {
                    break;
                }
                command = Console.ReadLine();
            }
            Console.WriteLine("Game over!");
            Console.WriteLine($"Touched opponents: {countTochedOpponents} Moves made: {countMoves}");
        }
    }
}
