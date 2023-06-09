using System;
using System.Linq;
namespace Warship
{
    class Program
    {
        static void Main(string[] args)
        {
            int sizeMatrix = int.Parse(Console.ReadLine());//5
            char[,] matrixChar = new char[sizeMatrix, sizeMatrix];
            string[] indexes = Console.ReadLine().Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);//0 0,-1 -1,2 2,4 4,4 2,3 3,3 6 
            for (int row = 0; row < matrixChar.GetLength(0); row++)
            {
                string matrixRowData = Console.ReadLine();
                char[] matrixRowDataSplited = matrixRowData.Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(char.Parse).ToArray();
                for (int col = 0; col < matrixChar.GetLength(1); col++)
                {
                    matrixChar[row, col] = matrixRowDataSplited[col];
                }
            }
            int playerOneDestroyedShips = 0;
            int playerTwoDestroyedShips = 0;
            int playerOne = 0;
            int playerTwo = 0;
            int counter = 0;
            //*<># - empty - playerOne - playerTwo - mine
            for (int i = 0; i < indexes.Length; i += 2)
            {
                int currRow = int.Parse(indexes[i]);
                int currCol = int.Parse(indexes[i + 1]);
                counter++;
                if (rowInRange(matrixChar, currRow) && colInRange(matrixChar, currCol) && matrixChar[currRow, currCol] == '<')
                {
                    matrixChar[currRow, currCol] = 'X';
                    playerOneDestroyedShips++;
                }
                else if (rowInRange(matrixChar, currRow) && colInRange(matrixChar, currCol) && matrixChar[currRow, currCol] == '>')
                {
                    matrixChar[currRow, currCol] = 'X';
                    playerTwoDestroyedShips++;
                }
                else if (rowInRange(matrixChar, currRow) && colInRange(matrixChar, currCol) && matrixChar[currRow, currCol] == '#')
                {
                    matrixChar[currRow, currCol] = 'X';
                    if (rowInRange(matrixChar, currRow - 1))
                    {
                        if (colInRange(matrixChar, currCol))
                        {
                            if (matrixChar[currRow - 1, currCol] == '<')
                            {
                                playerOneDestroyedShips++;
                            }
                            else if (matrixChar[currRow - 1, currCol] == '>')
                            {
                                playerTwoDestroyedShips++;
                            }
                            matrixChar[currRow - 1, currCol] = 'X';
                        }
                    }
                    if (rowInRange(matrixChar, currRow - 1))
                    {
                        if (colInRange(matrixChar, currCol - 1))
                        {
                            if (matrixChar[currRow - 1, currCol - 1] == '<')
                            {
                                playerOneDestroyedShips++;
                            }
                            else if (matrixChar[currRow - 1, currCol - 1] == '>')
                            {
                                playerTwoDestroyedShips++;
                            }
                            matrixChar[currRow - 1, currCol - 1] = 'X';
                        }
                    }
                    if (rowInRange(matrixChar, currRow - 1))
                    {
                        if (colInRange(matrixChar, currCol + 1))
                        {
                            if (matrixChar[currRow - 1, currCol + 1] == '<')
                            {
                                playerOneDestroyedShips++;
                            }
                            else if (matrixChar[currRow - 1, currCol + 1] == '>')
                            {
                                playerTwoDestroyedShips++;
                            }
                            matrixChar[currRow - 1, currCol + 1] = 'X';
                        }
                    }
                    if (rowInRange(matrixChar, currRow))
                    {
                        if (colInRange(matrixChar, currCol - 1))
                        {
                            if (matrixChar[currRow, currCol - 1] == '<')
                            {
                                playerOneDestroyedShips++;
                            }
                            else if (matrixChar[currRow, currCol - 1] == '>')
                            {
                                playerTwoDestroyedShips++;
                            }
                            matrixChar[currRow, currCol - 1] = 'X';
                        }
                    }
                    if (rowInRange(matrixChar, currRow))
                    {
                        if (colInRange(matrixChar, currCol + 1))
                        {
                            if (matrixChar[currRow, currCol + 1] == '<')
                            {
                                playerOneDestroyedShips++;
                            }
                            else if (matrixChar[currRow, currCol + 1] == '>')
                            {
                                playerTwoDestroyedShips++;
                            }
                            matrixChar[currRow, currCol + 1] = 'X';
                        }
                    }
                    if (rowInRange(matrixChar, currRow + 1))
                    {
                        if (colInRange(matrixChar, currCol))
                        {
                            if (matrixChar[currRow + 1, currCol] == '<')
                            {
                                playerOneDestroyedShips++;
                            }
                            else if (matrixChar[currRow + 1, currCol] == '>')
                            {
                                playerTwoDestroyedShips++;
                            }
                            matrixChar[currRow + 1, currCol] = 'X';
                        }
                    }
                    if (rowInRange(matrixChar, currRow + 1))
                    {
                        if (colInRange(matrixChar, currCol - 1))
                        {
                            if (matrixChar[currRow + 1, currCol - 1] == '<')
                            {
                                playerOneDestroyedShips++;
                            }
                            else if (matrixChar[currRow + 1, currCol - 1] == '>')
                            {
                                playerTwoDestroyedShips++;
                            }
                            matrixChar[currRow + 1, currCol - 1] = 'X';
                        }
                    }
                    if (rowInRange(matrixChar, currRow + 1))
                    {
                        if (colInRange(matrixChar, currCol + 1))
                        {
                            if (matrixChar[currRow + 1, currCol + 1] == '<')
                            {
                                playerOneDestroyedShips++;
                            }
                            else if (matrixChar[currRow + 1, currCol + 1] == '>')
                            {
                                playerTwoDestroyedShips++;
                            }
                            matrixChar[currRow + 1, currCol + 1] = 'X';
                        }
                    }
                }
                playerOne = 0;
                playerTwo = 0;
                for (int row = 0; row < matrixChar.GetLength(0); row++)
                {
                    for (int col = 0; col < matrixChar.GetLength(1); col++)
                    {
                        if (matrixChar[row, col] == '<')
                        {
                            playerOne++;
                        }
                        if (matrixChar[row, col] == '>')
                        {
                            playerTwo++;
                        }
                    }
                }
                if (playerTwo == 0)
                {
                    Console.WriteLine($"Player One has won the game! {playerOneDestroyedShips + playerTwoDestroyedShips} ships have been sunk in the battle.");
                    break;
                }
                if (playerOne == 0)
                {
                    Console.WriteLine($"Player Two has won the game! {playerOneDestroyedShips + playerTwoDestroyedShips} ships have been sunk in the battle.");
                    break;
                }
            }
            if (playerOne > 0 && playerTwo > 0)
            {
                Console.WriteLine($"It's a draw! Player One has {playerOne} ships left. Player Two has {playerTwo} ships left.");
            }
        }

        private static bool rowInRange(char[,] matrix, int row)
        {
            return row >= 0 && row < matrix.GetLength(0);
        }

        private static bool colInRange(char[,] matrix, int col)
        {
            return col >= 0 && col < matrix.GetLength(1);
        }
    }
}

switch (command)
{
    //oldRow = curRow; 
    //oldCol = curCol;
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
// string currentChar = matrixChar[curRow, curCol].ToString();