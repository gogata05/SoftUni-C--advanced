using System;
namespace TestWallDestroyer
{
    internal class Program
    {
        static void Main(string[] args)
        {

            int sizeMatrix = int.Parse(Console.ReadLine()); //5
            char[,] matrixChar = new char[sizeMatrix, sizeMatrix];
            bool isElectrucuded = false;
            int curRow = -1;
            int curCol = -1;

            int oldRow = -1;
            int oldCol = -1;

            for (int row = 0; row < sizeMatrix; row++)
            {
                string dataRowMatrix = Console.ReadLine();
                for (int col = 0; col < sizeMatrix; col++)
                {
                    matrixChar[row, col] = dataRowMatrix[col];
                    if (matrixChar[row, col] == 'V')
                    {
                        curRow = row;
                        curCol = col;
                    }
                }
            }
            string command = Console.ReadLine().ToLower();
            int holes = 1;
            int rods = 0;
            while (command != "end")
            {
                matrixChar[curRow, curCol] = '*';
                oldRow = curRow;//0
                oldCol = curCol;//2
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
                    matrixChar.GetLength(1) <= curCol) //if we are out end of loop
                {
                    curRow = oldRow;
                    curCol = oldCol;
                    matrixChar[curRow, curCol] = 'V';
                    command = Console.ReadLine().ToLower();
                    continue;
                }
                if (matrixChar[curRow, curCol] == 'R')
                {
                    Console.WriteLine("Vanko hit a rod!");
                    rods++;
                    curRow = oldRow;
                    curCol = oldCol;
                }
                else if (matrixChar[curRow, curCol] == '*')
                {
                    Console.WriteLine($"The wall is already destroyed at position [{curRow}, {curCol}]!");
                }
                else if (matrixChar[curRow, curCol] == 'C')
                {
                    matrixChar[curRow, curCol] = 'E';
                    isElectrucuded = true;
                    break;
                }
                else if (matrixChar[curRow, curCol] == '-')
                {
                    matrixChar[curRow, curCol] = '*';
                    holes++;
                }
                //-VRC* - empty - vanko - rods(dont make move) - cabel(end program) - trail
                matrixChar[curRow, curCol] = 'V';
                command = Console.ReadLine().ToLower();
            }

            if (!isElectrucuded)
            {
                Console.WriteLine($"Vanko managed to make {holes} hole(s) and he hit only {rods} rod(s).");
                matrixChar[curRow, curCol] = 'V';
            }
            else
            {
                holes++;
                Console.WriteLine($"Vanko got electrocuted, but he managed to make {holes} hole(s).");
            }

            PrintMatrix(matrixChar, e => Console.Write(e));
            static void PrintMatrix<T>(T[,] matrixChar, Action<T> printer)
            {
                for (int row = 0; row < matrixChar.GetLength(0); row++)
                {
                    for (int col = 0; col < matrixChar.GetLength(1); col++)
                    {
                        printer(matrixChar[row, col]);
                    }
                    Console.WriteLine();
                }
            }
        }
    }
}
