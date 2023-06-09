using System;
namespace TestSnake
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int sizeMatrix = int.Parse(Console.ReadLine()); //5
            char[,] matrixChar = new char[sizeMatrix, sizeMatrix]; //empty
            //curRow,curCol,oldRow,oldCol,mirror1Row,mirror1Col,mirror2Row,mirror2Col,isFirstMirrorFound
            bool isSnakeOut = false;
            int curRow = 0;
            int curCol = 0;

            bool isFirstMirrorFound = false;
            int mirror1Row = 0;
            int mirror1Col = 0;

            int mirror2Row = 0;
            int mirror2Col = 0;

            int food = 0;//?
            for (int row = 0; row < sizeMatrix; row++)
            {
                string dataRowMatrix = Console.ReadLine();
                for (int col = 0; col < sizeMatrix; col++)
                {
                    matrixChar[row, col] = dataRowMatrix[col];
                    if (matrixChar[row, col] == 'S')
                    {
                        curRow = row;
                        curCol = col;
                    }
                    else if (matrixChar[row, col] == 'B')
                    {
                        if (!isFirstMirrorFound)
                        {
                            mirror1Row = row;
                            mirror1Col = col;
                            isFirstMirrorFound = true;
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
            while (true)
            {
                matrixChar[curRow, curCol] = '.';//trail
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
                    isSnakeOut = true;
                    break;
                }
                char current = matrixChar[curRow, curCol];
                if (matrixChar[curRow, curCol] == '*')
                {
                    food++;
                    matrixChar[curRow, curCol] = 'S';
                    if (food >= 10)
                    {
                        break;
                    }
                }
                else if (matrixChar[curRow, curCol] == 'B')
                {
                    matrixChar[curRow, curCol] = '.';//trail
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
                }
                matrixChar[curRow, curCol] = 'S';
                command = Console.ReadLine().ToLower();
                // string currentChar = matrixChar[curRow, curCol].ToString();
            }
            //-S*B. - empty - snake - foodSum(++) - mirror - trail(.)
            if (isSnakeOut)
            {
                Console.WriteLine("Game over!");
            }
            else
            {
                Console.WriteLine("You won! You fed the snake.");
            }
            Console.WriteLine($"Food eaten: {food}");

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
