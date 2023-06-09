using System;

namespace ReVolt
{
    class Program
    {
        static void Main(string[] args)
        {
            bool hasWin = false;
            int curRow = 0;
            int curCol = 0;
            int sizeMatrix = int.Parse(Console.ReadLine());//5
            int n = int.Parse(Console.ReadLine());//5
            char[,] matrixChar = new char[sizeMatrix, sizeMatrix];
            for (int row = 0; row < sizeMatrix; row++)
            {
                string matrixRowData = Console.ReadLine();
                for (int col = 0; col < sizeMatrix; col++)
                {
                    matrixChar[row, col] = matrixRowData[col];
                    if (matrixChar[row, col] == 'f')
                    {
                        curRow = row;
                        curCol = col;
                    }
                }
            }
            matrixChar[curRow, curCol] = '-';
            for (int index = 0; index < n; index++)
            {
                string command = Console.ReadLine();
                if (command == "down")
                {
                    bool isInside = curRow + 1 >= 0 && curRow + 1 < sizeMatrix;
                    curRow = isInside ? curRow + 1 : 0;
                    if (matrixChar[curRow, curCol] == 'B')
                    {
                        bool isInside2 = curRow + 1 >= 0 && curRow + 1 < sizeMatrix;
                        curRow = isInside2 ? curRow + 1 : 0;
                        if (matrixChar[curRow, curCol] == 'B')
                        {
                            bool isInside3 = curRow - 1 >= 0 && curRow - 1 < sizeMatrix;
                            curRow = isInside3 ? curRow - 1 : sizeMatrix - 1;
                        }
                        else if (matrixChar[curRow, curCol] == 'T')
                        {
                            bool isInside4 = curRow + 1 >= 0 && curRow + 1 < sizeMatrix;
                            curRow = isInside4 ? curRow + 1 : 0;
                        }
                        else if (matrixChar[curRow, curCol] == 'F')
                        {
                            Console.WriteLine("Player won!");
                            hasWin = true;
                        }
                    }
                    else if (matrixChar[curRow, curCol] == 'T')
                    {
                        bool isInside5 = curRow - 1 >= 0 && curRow - 1 < sizeMatrix;
                        curRow = isInside5 ? curRow - 1 : sizeMatrix - 1;
                    }
                    else if (matrixChar[curRow, curCol] == 'F')
                    {
                        Console.WriteLine("Player won!");
                        hasWin = true;
                    }
                }
                else if (command == "up")
                {
                    bool isInside = curRow - 1 >= 0 && curRow - 1 < sizeMatrix;
                    curRow = isInside ? curRow - 1 : sizeMatrix - 1;
                    if (matrixChar[curRow, curCol] == 'B')
                    {
                        bool isInside2 = curRow - 1 >= 0 && curRow - 1 < sizeMatrix;
                        curRow = isInside2 ? curRow - 1 : sizeMatrix - 1;
                        if (matrixChar[curRow, curCol] == 'B')
                        {
                            bool isInside3 = curRow + 1 >= 0 && curRow + 1 < sizeMatrix;
                            curRow = isInside3 ? curRow + 1 : 0;
                        }
                        else if (matrixChar[curRow, curCol] == 'T')
                        {
                            bool isInside4 = curRow - 1 >= 0 && curRow - 1 < sizeMatrix;
                            curRow = isInside4 ? curRow - 1 : sizeMatrix - 1;
                        }
                        else if (matrixChar[curRow, curCol] == 'F')
                        {
                            Console.WriteLine("Player won!");
                            hasWin = true;
                        }
                    }
                    else if (matrixChar[curRow, curCol] == 'T')
                    {
                        bool isInside5 = curRow + 1 >= 0 && curRow + 1 < sizeMatrix;
                        curRow = isInside5 ? curRow + 1 : 0;
                    }
                    else if (matrixChar[curRow, curCol] == 'F')
                    {
                        Console.WriteLine("Player won!");
                        hasWin = true;
                    }
                }
                else if (command == "left")
                {
                    bool isInside = curCol - 1 >= 0 && curCol - 1 < sizeMatrix;
                    curCol = isInside ? curCol - 1 : sizeMatrix - 1;
                    if (matrixChar[curRow, curCol] == 'B')
                    {
                        bool isInside2 = curCol - 1 >= 0 && curCol - 1 < sizeMatrix;
                        curCol = isInside2 ? curCol - 1 : sizeMatrix - 1;
                        if (matrixChar[curRow, curCol] == 'B')
                        {
                            bool isInside3 = curCol + 1 >= 0 && curCol + 1 < sizeMatrix;
                            curCol = isInside3 ? curCol + 1 : 0;
                        }
                        else if (matrixChar[curRow, curCol] == 'T')
                        {
                            bool isInside4 = curCol - 1 >= 0 && curCol - 1 < sizeMatrix;
                            curCol = isInside4 ? curCol - 1 : sizeMatrix - 1;
                        }
                        else if (matrixChar[curRow, curCol] == 'F')
                        {
                            Console.WriteLine("Player won!");
                            hasWin = true;
                        }
                    }
                    else if (matrixChar[curRow, curCol] == 'T')
                    {
                        bool isInside5 = curCol + 1 >= 0 && curCol + 1 < sizeMatrix;
                        curCol = isInside5 ? curCol + 1 : 0;
                    }
                    else if (matrixChar[curRow, curCol] == 'F')
                    {
                        Console.WriteLine("Player won!");
                        hasWin = true;
                    }
                }
                else if (command == "right")
                {
                    bool isInside = curCol + 1 >= 0 && curCol + 1 < sizeMatrix;
                    curCol = isInside ? curCol + 1 : 0;
                    if (matrixChar[curRow, curCol] == 'B')
                    {
                        bool isInside2 = curCol + 1 >= 0 && curCol + 1 < sizeMatrix;
                        curCol = isInside2 ? curCol + 1 : 0;
                        if (matrixChar[curRow, curCol] == 'B')
                        {
                            bool isInside3 = curCol - 1 >= 0 && curCol - 1 < sizeMatrix;
                            curCol = isInside3 ? curCol - 1 : sizeMatrix - 1;
                        }
                        else if (matrixChar[curRow, curCol] == 'T')
                        {
                            bool isInside4 = curCol + 1 >= 0 && curCol + 1 < sizeMatrix;
                            curCol = isInside4 ? curCol + 1 : 0;
                        }
                        else if (matrixChar[curRow, curCol] == 'F')
                        {
                            Console.WriteLine("Player won!");
                            hasWin = true;
                        }
                    }
                    else if (matrixChar[curRow, curCol] == 'T')
                    {
                        bool isInside5 = curCol - 1 >= 0 && curCol - 1 < sizeMatrix;
                        curCol = isInside5 ? curCol - 1 : sizeMatrix - 1;
                    }
                    else if (matrixChar[curRow, curCol] == 'F')
                    {
                        Console.WriteLine("Player won!");
                        hasWin = true;
                    }
                }

                if (hasWin == true)
                {
                    break;
                }
            }

            matrixChar[curRow, curCol] = 'f';

            if (hasWin == false)
            {
                Console.WriteLine("Player lost!");
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
