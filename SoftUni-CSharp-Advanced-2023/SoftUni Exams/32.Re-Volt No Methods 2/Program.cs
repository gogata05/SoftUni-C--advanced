using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace LooBox
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());

            int numberOfCommand = int.Parse(Console.ReadLine());

            char[][] matrix = new char[size][];

            int playerRow = 0;
            int playerCol = 0;

            for (int row = 0; row < size; row++)
            {
                string data = Console.ReadLine();

                matrix[row] = new char[data.Length];

                for (int col = 0; col < data.Length; col++)
                {
                    matrix[row][col] = data[col];

                    if (data[col] == 'f')
                    {
                        playerRow = row;
                        playerCol = col;

                    }
                }
            }

            bool wonTheGame = false;

            for (int i = 0; i < numberOfCommand; i++)
            {
                string command = Console.ReadLine();

                matrix[playerRow][playerCol] = '-';

                if (command == "up")
                {
                    if (playerRow - 1 >= 0)
                    {
                        playerRow--;
                    }
                    else
                    {
                        playerRow = matrix.Length - 1;
                    }

                    while (matrix[playerRow][playerCol] != '-' && matrix[playerRow][playerCol] != 'F')
                    {


                        if (matrix[playerRow][playerCol] == 'T')
                        {
                            playerRow++;
                        }
                        else if (matrix[playerRow][playerCol] == 'B')
                        {
                            playerRow--;
                        }

                        if (playerRow < 0)
                        {
                            playerRow = matrix.Length - 1;
                        }

                    }

                    if (matrix[playerRow][playerCol] == 'F')
                    {
                        wonTheGame = true;
                        break;
                    }

                    matrix[playerRow][playerCol] = 'f';

                    //Print(matrix);

                }
                else if (command == "down")
                {
                    if (playerRow + 1 < matrix.Length)
                    {
                        playerRow++;
                    }
                    else
                    {
                        playerRow = 0;
                    }

                    while (matrix[playerRow][playerCol] != '-' && matrix[playerRow][playerCol] != 'F')
                    {

                        if (matrix[playerRow][playerCol] == 'T')
                        {
                            playerRow--;
                        }
                        else if (matrix[playerRow][playerCol] == 'B')
                        {
                            playerRow++;
                        }

                        if (playerRow == matrix.Length)
                        {
                            playerRow = 0;
                        }
                    }

                    if (matrix[playerRow][playerCol] == 'F')
                    {
                        wonTheGame = true;
                        break;
                    }

                    matrix[playerRow][playerCol] = 'f';

                    //Print(matrix);

                }
                else if (command == "right")
                {
                    if (playerCol + 1 < matrix.Length)
                    {
                        playerCol++;
                    }
                    else
                    {
                        playerCol = 0;
                    }

                    while (matrix[playerRow][playerCol] != '-' && matrix[playerRow][playerCol] != 'F')
                    {
                        if (matrix[playerRow][playerCol] == 'T')
                        {
                            playerCol--;
                        }
                        else if (matrix[playerRow][playerCol] == 'B')
                        {
                            playerCol++;
                        }

                        if (playerRow == matrix.Length)
                        {
                            playerRow = 0;
                        }
                    }

                    if (matrix[playerRow][playerCol] == 'F')
                    {
                        wonTheGame = true;
                        break;
                    }

                    matrix[playerRow][playerCol] = 'f';

                    //Print(matrix);

                }
                else if (command == "left")
                {
                    if (playerCol - 1 >= 0)
                    {
                        playerCol--;
                    }
                    else
                    {
                        playerCol = matrix.Length - 1;
                    }

                    while (matrix[playerRow][playerCol] != '-' && matrix[playerRow][playerCol] != 'F')
                    {
                        if (playerCol < 0)
                        {
                            playerCol = matrix.Length - 1;
                        }

                        if (matrix[playerRow][playerCol] == 'T')
                        {
                            playerCol++;
                        }
                        else if (matrix[playerRow][playerCol] == 'B')
                        {
                            playerCol--;
                        }

                        if (playerCol < 0)
                        {
                            playerCol = matrix.Length - 1;
                        }
                    }

                    if (matrix[playerRow][playerCol] == 'F')
                    {
                        wonTheGame = true;
                        break;
                    }

                    matrix[playerRow][playerCol] = 'f';

                    //Print(matrix);
                }
            }

            if (wonTheGame)
            {
                matrix[playerRow][playerCol] = 'f';

                Console.WriteLine($"Player won!");
            }
            else
            {
                Console.WriteLine($"Player lost!");
            }

            Print(matrix);
        }


        private static void Print(char[][] matrix)
        {
            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix[i].Length; j++)
                {
                    Console.Write(matrix[i][j]);
                }

                Console.WriteLine();
            }
        }

    }
}