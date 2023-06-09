using System;
using System.Linq;
// n * n
//coordinates - 0 1, -1 -1
//matrix
     //first player++;
//second player++;

//forech coordinates
// if in range
   //if >
       //if player -=1; X
   //else if <
      //second player -=1; X
//else if #
      // X up/down/left/right // left/up right/down left/down right/up
      //up/down if > || < firstPlayer/secondPlayer --;
//no coordinates || firstPlayer/secondPlayer == 0
namespace Warship
{
    class Program
    {
        static void Main(string[] args)
        {
            int sizeMatrix = int.Parse(Console.ReadLine());
            char[,] matrixChar = new char[sizeMatrix, sizeMatrix];
            string[] attackCommands = Console.ReadLine().Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);
            for (int row = 0; row < matrixChar.GetLength(0); row++)
            {
                string matrixRowData = Console.ReadLine();
                char[] matrixRowDataSplited = matrixRowData.Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(char.Parse).ToArray();
                for (int col = 0; col < matrixChar.GetLength(1); col++)
                {
                    matrixChar[row, col] = matrixRowDataSplited[col];
                    //make matricChar[row, col] =='<';
                }
            }
            int playerOneDestroyedShips = 0;
            int playerTwoDestroyedShips = 0;
            int playerOne = 0;
            int playerTwo = 0;
            int counter = 0;
            for (int i = 0; i < attackCommands.Length; i += 2)
            {
                int currRow = int.Parse(attackCommands[i]);
                int currCol = int.Parse(attackCommands[i + 1]);
                counter++;
                if (isInRange(matrixChar, currRow, currCol) && matrixChar[currRow, currCol] == '<')
                {
                    matrixChar[currRow, currCol] = 'X';
                    playerOneDestroyedShips++;
                }
                else if (isInRange(matrixChar, currRow, currCol) && matrixChar[currRow, currCol] == '>')
                {
                    matrixChar[currRow, currCol] = 'X';
                    playerTwoDestroyedShips++;
                }
                else if (isInRange(matrixChar, currRow, currCol) && matrixChar[currRow, currCol] == '#')
                {
                    matrixChar[currRow, currCol] = 'X';
                    if (isInRange(matrixChar, currRow - 1, currCol))
                    {
                        AttackShips(matrixChar, ref playerOneDestroyedShips, ref playerTwoDestroyedShips, currRow - 1, currCol);
                    }
                    if (isInRange(matrixChar, currRow - 1, currCol - 1))
                    {
                        AttackShips(matrixChar, ref playerOneDestroyedShips, ref playerTwoDestroyedShips, currRow - 1, currCol - 1);
                    }
                    if (isInRange(matrixChar, currRow - 1, currCol + 1))
                    {
                        AttackShips(matrixChar, ref playerOneDestroyedShips, ref playerTwoDestroyedShips, currRow - 1, currCol + 1);
                    }
                    if (isInRange(matrixChar, currRow, currCol - 1))
                    {
                        AttackShips(matrixChar, ref playerOneDestroyedShips, ref playerTwoDestroyedShips, currRow, currCol - 1);
                    }
                    if (isInRange(matrixChar, currRow, currCol + 1))
                    {
                        AttackShips(matrixChar, ref playerOneDestroyedShips, ref playerTwoDestroyedShips, currRow, currCol + 1);
                    }
                    if (isInRange(matrixChar, currRow + 1, currCol))
                    {
                        AttackShips(matrixChar, ref playerOneDestroyedShips, ref playerTwoDestroyedShips, currRow + 1, currCol);
                    }
                    if (isInRange(matrixChar, currRow + 1, currCol - 1))
                    {
                        AttackShips(matrixChar, ref playerOneDestroyedShips, ref playerTwoDestroyedShips, currRow + 1, currCol - 1);
                    }
                    if (isInRange(matrixChar, currRow + 1, currCol + 1))
                    {
                        AttackShips(matrixChar, ref playerOneDestroyedShips, ref playerTwoDestroyedShips, currRow + 1, currCol + 1);
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
        private static void AttackShips(char[,] matrix, ref int playerOneDestroyedShips, ref int playerTwoDestroyedShips, int currRow, int currCol)
        {
            if (matrix[currRow, currCol] == '<')
            {
                playerOneDestroyedShips++;
            }
            else if (matrix[currRow, currCol] == '>')
            {
                playerTwoDestroyedShips++;
            }
            matrix[currRow, currCol] = 'X';
        }
        private static bool isInRange(char[,] matrix, int row, int col)
        {
            return row >= 0 && row < matrix.GetLength(0) &&
                   col >= 0 && col < matrix.GetLength(1);
        }
    }
}
