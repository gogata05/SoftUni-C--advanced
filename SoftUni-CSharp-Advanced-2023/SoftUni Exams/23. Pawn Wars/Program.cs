using System;
//-WB - empty - white pawn - dark pawn
//random start position and each move +1 forward//1st queen wins or if who capture opponents pawn 1st
namespace PawnWars
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int sizeMatrix = 8;
            char[,] matrixCharChessBoard = new char[sizeMatrix, sizeMatrix];//8/8
            int whiteRow = 0;
            int whiteCol = 0;
            int blackRow = 0;
            int blackCol = 0;
            for (int row = 0; row < sizeMatrix; row++)
            {
                string matrixRowDataArray = Console.ReadLine();
                //------b- 
                //-------- 
                //-------- 
                //-------- 
                //-------- 
                //-w------ 
                //-------- 
                //-------- 
                for (int col = 0; col < sizeMatrix; col++)
                {
                    matrixCharChessBoard[row, col] = matrixRowDataArray[col];
                    if (matrixRowDataArray[col] == 'w')
                    {
                        whiteRow = row;
                        whiteCol = col;
                    }
                    if (matrixRowDataArray[col] == 'b')
                    {
                        blackRow = row;
                        blackCol = col;
                    }
                }
            }
            bool whiteTurn = true;
            while (true)
            {
                if (whiteTurn)
                {
                    if (whiteRow == 0)
                    {
                        Console.WriteLine($"Game over! White pawn is promoted to a queen at {(char)(97 + whiteCol)}8.");

                        return;
                    }
                    if (IsInRange(whiteRow - 1, whiteCol - 1, matrixCharChessBoard) && matrixCharChessBoard[whiteRow - 1, whiteCol - 1] == 'b')
                    {
                        whiteRow--;
                        whiteCol--;
                        Console.WriteLine($"Game over! White capture on {(char)(97 + whiteCol)}{8 - whiteRow}.");
                        return;
                    }
                    if (IsInRange(whiteRow - 1, whiteCol + 1, matrixCharChessBoard) && matrixCharChessBoard[whiteRow - 1, whiteCol + 1] == 'b')
                    {
                        whiteRow--;
                        whiteCol++;
                        Console.WriteLine($"Game over! White capture on {(char)(97 + whiteCol)}{8 - whiteRow}.");
                        return;
                    }
                    whiteRow--;
                    matrixCharChessBoard[whiteRow, whiteCol] = 'w';
                }
                else
                {
                    if (blackRow == 7)
                    {
                        Console.WriteLine($"Game over! Black pawn is promoted to a queen at {(char)(97 + blackCol)}1.");
                        return;
                    }
                    if (IsInRange(blackRow + 1, blackCol - 1, matrixCharChessBoard) && matrixCharChessBoard[blackRow + 1, blackCol - 1] == 'w')
                    {
                        blackRow++;
                        blackCol--;
                        Console.WriteLine($"Game over! Black capture on {(char)(97 + blackCol)}{8 - blackRow}.");
                        return;
                    }
                    if (IsInRange(blackRow + 1, blackCol + 1, matrixCharChessBoard) && matrixCharChessBoard[blackRow + 1, blackCol + 1] == 'w')
                    {
                        blackRow++;
                        blackCol++;
                        Console.WriteLine($"Game over! Black capture on {(char)(97 + blackCol)}{8 - blackRow}.");
                        return;
                    }
                    blackRow++;
                    matrixCharChessBoard[blackRow, blackCol] = 'b';
                }
                whiteTurn = !whiteTurn;
            }
        }
        static bool IsInRange(int row, int col, char[,] matrix)
        => row >= 0
           && row < matrix.GetLength(0)
           && col >= 0
           && col < matrix.GetLength(1);
    }
}
