using System;
namespace TestArmory
{
    internal class Program
    {
        static void Main(string[] args)
        {

            int sizeMatrix = int.Parse(Console.ReadLine());//4
            char[,] matrixChar = new char[sizeMatrix, sizeMatrix]; //empty
            bool isOficerOut = false;
            int sumSwords = 0;

            int curRow = 0;
            int curCol = 0;

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
                    if (matrixChar[row, col] == 'A')
                    {
                        curRow = row;
                        curCol = col;
                    }
                    else if (matrixChar[row, col] == 'M')
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
                matrixChar[curRow, curCol] = '-';//last
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
                    isOficerOut = true;
                    break;
                }
                if (matrixChar[curRow, curCol] == 'M')
                {
                    matrixChar[curRow, curCol] = '-';//current
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
                else if (Char.IsDigit(matrixChar[curRow, curCol]))
                {
                    string current = matrixChar[curRow, curCol].ToString();
                    sumSwords += int.Parse(current);
                    if (sumSwords >= 65)
                    {
                        matrixChar[curRow, curCol] = 'A';
                        break;
                    }
                }

                matrixChar[curRow, curCol] = 'A';
                command = Console.ReadLine().ToLower();
            }
            //-А digit M - empty - armyOficer - swordSum - 2 side mirror(jump)
            if (isOficerOut)
            {
                Console.WriteLine("I do not need more swords!");
            }
            else
            {
                Console.WriteLine("Very nice swords, I will come back for more!");
            }
            Console.WriteLine($"The king paid {sumSwords} gold coins.");

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
