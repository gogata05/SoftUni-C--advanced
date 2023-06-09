using System;
using System.Collections.Generic;
using System.Data;

namespace _02_Re_Volt
{
    class Program
    {
        static char[,] matrix;

        static int rowCheck;
        static int colCheck;

        static bool isWon;
        static void Main(string[] args)
        {
            int sizeN = int.Parse(Console.ReadLine());
            int countOfCommands = int.Parse(Console.ReadLine());

            matrix = new char[sizeN, sizeN];
            rowCheck = 0;
            colCheck = 0;

            isWon = false;

            MatrixCreate();

            for (int i = 0; i < countOfCommands; i++)
            {
                string command = Console.ReadLine();
                matrix[rowCheck, colCheck] = '-';

                if (command == "up")
                {
                    MoveUp();
                }

                else if (command == "down")
                {
                    MoveDown();
                }

                else if (command == "left")
                {
                    MoveLeft();
                }

                else if (command == "right")
                {
                    MoveRight();
                }
                matrix[rowCheck, colCheck] = 'f';
                if (isWon)
                {
                    Console.WriteLine("Player won!");
                    MatrixPrint();
                    return;
                }
            }
            Console.WriteLine("Player lost!");
            MatrixPrint();
        }

        static void MatrixCreate()
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string currentRow = Console.ReadLine();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = currentRow[col];
                    if (matrix[row, col] == 'f')
                    {
                        rowCheck = row;
                        colCheck = col;
                    }
                }
            }
        }
        static void MoveUp()
        {
            if (rowCheck - 1 < 0)
            {
                rowCheck = matrix.GetLength(0) - 1;
            }
            else
            {
                rowCheck = rowCheck - 1;
            }

            while (matrix[rowCheck, colCheck] != '-' && matrix[rowCheck, colCheck] != 'F')
            {
                if (matrix[rowCheck, colCheck] == 'T')
                {
                    rowCheck++;
                }
                else if (matrix[rowCheck, colCheck] == 'B')
                {
                    rowCheck--;
                }

                if (rowCheck < 0)
                {
                    rowCheck = matrix.GetLength(0) - 1;
                }
            }
            if (matrix[rowCheck, colCheck] == 'F')
            {
                isWon = true;
            }

        }

        static void MoveDown()
        {

            if (rowCheck + 1 > matrix.GetLength(0))
            {
                rowCheck = 0;
            }
            else
            {
                rowCheck = rowCheck + 1;
            }
            while (matrix[rowCheck, colCheck] != '-' && matrix[rowCheck, colCheck] != 'F')
            {
                if (matrix[rowCheck, colCheck] == 'T')
                {
                    rowCheck--;
                }
                else if (matrix[rowCheck, colCheck] == 'B')
                {
                    rowCheck++;
                }

                if (rowCheck > matrix.GetLength(0) - 1)
                {
                    rowCheck = 0;
                }
            }
            if (matrix[rowCheck, colCheck] == 'F')
            {
                isWon = true;
            }


        }


        static void MoveLeft()
        {
            if (colCheck - 1 < 0)
            {
                colCheck = matrix.GetLength(1) - 1;
            }
            else
            {
                colCheck = colCheck - 1;
            }

            while (matrix[rowCheck, colCheck] != '-' && matrix[rowCheck, colCheck] != 'F')
            {
                if (matrix[rowCheck, colCheck] == 'T')
                {
                    colCheck++;
                }
                else if (matrix[rowCheck, colCheck] == 'B')
                {
                    colCheck--;
                }

                if (colCheck < 0)
                {
                    colCheck = matrix.GetLength(1) - 1;
                }
            }
            if (matrix[rowCheck, colCheck] == 'F')
            {
                isWon = true;
            }


        }
        static void MoveRight()
        {
            if (colCheck + 1 > matrix.GetLength(1) - 1)
            {
                colCheck = 0;
            }
            else
            {
                colCheck = colCheck + 1;
            }

            while (matrix[rowCheck, colCheck] != '-' && matrix[rowCheck, colCheck] != 'F')
            {
                if (matrix[rowCheck, colCheck] == 'T')
                {
                    colCheck--;
                }
                else if (matrix[rowCheck, colCheck] == 'B')
                {
                    colCheck++;
                }

                if (colCheck > matrix.GetLength(1) - 1)
                {
                    colCheck = 0;
                }
            }
            if (matrix[rowCheck, colCheck] == 'F')
            {
                isWon = true;
            }

        }
        static void MatrixPrint()
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col]);
                }
                Console.WriteLine();
            }
        }

    }
}