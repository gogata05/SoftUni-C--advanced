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

        static int checkRowT;
        static int checkColT;

        static bool isTrue;
        static void Main(string[] args)
        {
            int sizeN = int.Parse(Console.ReadLine());
            int countOfCommands = int.Parse(Console.ReadLine());

            matrix = new char[sizeN, sizeN];
            rowCheck = 0;
            colCheck = 0;

            checkRowT = 0;
            checkColT = 0;

            isTrue = false;

            MatrixCreate();

            for (int i = 0; i < countOfCommands; i++)
            {
                string command = Console.ReadLine();

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
                if (isTrue)
                {
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
            checkRowT = rowCheck;
            checkColT = colCheck;

            if (rowCheck - 1 < 0)
            {
                rowCheck = matrix.GetLength(0) - 1;
            }
            else
            {
                rowCheck = rowCheck - 1;
            }

            if (matrix[rowCheck, colCheck] != 'T')
            {

                matrix[checkRowT, checkColT] = '-';
                if (matrix[rowCheck, colCheck] == 'B')
                {
                    if (rowCheck - 1 < 0)
                    {
                        rowCheck = matrix.GetLength(0) - 1;
                    }
                    else
                    {
                        rowCheck = rowCheck - 1;
                    }

                }

                if (matrix[rowCheck, colCheck] == 'F')
                {
                    matrix[rowCheck, colCheck] = 'f';
                    Console.WriteLine("Player won!");
                    isTrue = true;
                }
                matrix[rowCheck, colCheck] = 'f';
            }
            else
            {
                rowCheck = checkRowT;
                colCheck = checkColT;
            }
        }

        static void MoveDown()
        {
            checkRowT = rowCheck;
            checkColT = colCheck;

            if (rowCheck + 1 > matrix.GetLength(0))
            {
                rowCheck = 0;
            }
            else
            {
                rowCheck = rowCheck + 1;
            }

            if (matrix[rowCheck, colCheck] != 'T')
            {
                matrix[checkRowT, checkColT] = '-';

                if (matrix[rowCheck, colCheck] == 'B')
                {
                    if (rowCheck + 1 > matrix.GetLength(0))
                    {
                        rowCheck = 0;
                    }
                    else
                    {
                        rowCheck = rowCheck + 1;
                    }


                }

                if (matrix[rowCheck, colCheck] == 'F')
                {
                    matrix[rowCheck, colCheck] = 'f';
                    Console.WriteLine("Player won!");
                    isTrue = true;
                }
                matrix[rowCheck, colCheck] = 'f';
            }
            else
            {
                rowCheck = checkRowT;
                colCheck = checkColT;
            }
        }


        static void MoveLeft()
        {

            checkRowT = rowCheck;
            checkColT = colCheck;

            if (colCheck - 1 < 0)
            {
                colCheck = matrix.GetLength(1) - 1;
            }
            else
            {
                colCheck = colCheck - 1;
            }

            if (matrix[rowCheck, colCheck] != 'T')
            {
                matrix[checkRowT, checkColT] = '-';
                if (matrix[rowCheck, colCheck] == 'B')
                {
                    if (colCheck - 1 < 0)
                    {
                        colCheck = matrix.GetLength(1) - 1;
                    }
                    else
                    {
                        colCheck = colCheck - 1;
                    }

                }

                if (matrix[rowCheck, colCheck] == 'F')
                {
                    matrix[rowCheck, colCheck] = 'f';
                    Console.WriteLine("Player won!");
                    isTrue = true;
                }
                matrix[rowCheck, colCheck] = 'f';
            }
            else
            {
                rowCheck = checkRowT;
                colCheck = checkColT;
            }
        }
        static void MoveRight()
        {

            checkRowT = rowCheck;
            checkColT = colCheck;

            if (colCheck + 1 > matrix.GetLength(1) - 1)
            {
                colCheck = 0;
            }
            else
            {
                colCheck = colCheck + 1;
            }

            if (matrix[rowCheck, colCheck] != 'T')
            {
                matrix[checkRowT, checkColT] = '-';
                if (matrix[rowCheck, colCheck] == 'B')
                {
                    if (colCheck + 1 > matrix.GetLength(1) - 1)
                    {
                        colCheck = 0;
                    }
                    else
                    {
                        colCheck = colCheck + 1;
                    }

                }


                if (matrix[rowCheck, colCheck] == 'F')
                {
                    matrix[rowCheck, colCheck] = 'f';
                    Console.WriteLine("Player won!");
                    isTrue = true;
                }
                matrix[rowCheck, colCheck] = 'f';
            }
            else
            {
                rowCheck = checkRowT;
                colCheck = checkColT;
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