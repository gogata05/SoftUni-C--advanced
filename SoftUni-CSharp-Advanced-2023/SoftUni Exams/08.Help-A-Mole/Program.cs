using System;
namespace TestHelp_A_Mole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int sizeMatrix = int.Parse(Console.ReadLine()); //5
            char[,] matrixChar = new char[sizeMatrix, sizeMatrix]; //empty
            //curRow,curCol,oldRow,oldCol,mirror1Row,mirror1Col,mirror2Row,mirror2Col,isFirstMirrorFound
            int points = 0;
            bool hasWon = false;
            int curRow = 0;
            int curCol = 0;

            int oldRow = 0;
            int oldCol = 0;

            bool isFirstMirrorFound = false;
            int mirror1Row = 0;
            int mirror1Col = 0;

            int mirror2Row = 0;
            int mirror2Col = 0;
            for (int row = 0; row < sizeMatrix; row++)
            {
                string dataRowMatrix = Console.ReadLine();
                for (int col = 0; col < sizeMatrix; col++)
                {
                    matrixChar[row, col] = dataRowMatrix[col];
                    if (matrixChar[row, col] == 'M')
                    {
                        curRow = row;//1
                        curCol = col;//2
                    }
                    else if (matrixChar[row, col] == 'S')
                    {
                        if (!isFirstMirrorFound)
                        {
                            isFirstMirrorFound = true;
                            mirror1Row = row;
                            mirror1Col = col;
                        }
                        else
                        {
                            mirror2Row = row;
                            mirror2Col = col;
                        }
                    }
                }
            }
            string command = Console.ReadLine().ToLower();
            while (command != "end")
            {
                matrixChar[curRow, curCol] = '-';//empty
                oldRow = curRow;
                oldCol = curCol;
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

                if (curRow < 0 || curCol < 0 || matrixChar.GetLength(0) <= curRow ||
                    matrixChar.GetLength(1) <= curCol) //if we are out end of loop
                {
                    Console.WriteLine("Don't try to escape the playing field!");
                    curRow = oldRow;
                    curCol = oldCol;
                    matrixChar[curRow, curCol] = 'M';
                    command = Console.ReadLine().ToLower();
                    continue;
                }
                string currentChar = matrixChar[curRow, curCol].ToString();

                if (matrixChar[curRow, curCol] == 'S')//jump
                {
                    matrixChar[curRow, curCol] = '-';
                    if (curRow == mirror1Row && curCol == mirror1Col)
                    {
                        curRow = mirror2Row;
                        curCol = mirror2Col;
                    }
                    else
                    {
                        curRow = mirror1Row;
                        curCol = mirror1Col;
                    }
                    points -= 3;//?
                }
                else if (char.IsDigit(matrixChar[curRow, curCol]))//digit
                {
                    points += matrixChar[curRow, curCol] - '0';//?
                    //if not int parse
                    if (points >= 25)
                    {
                        hasWon = true;
                        break;
                    }
                }

                matrixChar[curRow, curCol] = 'M';//?
                command = Console.ReadLine().ToLower();
            }
            //-MSdigit - empty - mole - mirror - pointsSum
            if (hasWon)
            {
                matrixChar[curRow, curCol] = 'M';
                Console.WriteLine("Yay! The Mole survived another game!");
                Console.WriteLine($"The Mole managed to survive with a total of {points} points.");
            }
            else
            {
                Console.WriteLine("Too bad! The Mole lost this battle!");
                Console.WriteLine($"The Mole lost the game with a total of {points} points.");
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
