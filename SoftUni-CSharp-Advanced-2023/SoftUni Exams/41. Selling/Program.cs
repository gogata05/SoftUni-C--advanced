using System;
//-Sdigit0 - empty - me - sumPriceDigit - mirror
namespace TestSelling
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int sizeMatrix = int.Parse(Console.ReadLine());//5
            char[,] matrixChar = new char[sizeMatrix, sizeMatrix];//5
            int moneyTotal = 0;
            int currentRow = 0;
            int currentCol = 0;

            bool isFirstMirrorFound = false;
            int mirror1Row = -1;
            int mirror1Col = -1;

            int mirror2Row = -1;
            int mirror2Col = -1;
            for (int row = 0; row < sizeMatrix; row++)
            {
                string dataRowMatrix = Console.ReadLine();
                for (int col = 0; col < sizeMatrix; col++)
                {
                    matrixChar[row, col] = dataRowMatrix[col];
                    if (matrixChar[row, col] == 'S')
                    {
                        currentRow = row;
                        currentCol = col;
                    }
                    else if (matrixChar[row, col] == 'O')//mirror
                    {
                        if (!isFirstMirrorFound)//?
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
            string command = Console.ReadLine();
            while (moneyTotal < 50)
            {
                matrixChar[currentRow, currentCol] = '-';
                //last index to be '-'
                switch (command)
                {
                    case "up":
                        currentRow--;
                        break;
                    case "down":
                        currentRow++;
                        break;
                    case "left":
                        currentCol--;
                        break;
                    case "right":
                        currentCol++;
                        break;
                }

                if (currentRow < 0 || currentCol < 0 || matrixChar.GetLength(0) <= currentRow || matrixChar.GetLength(1) <= currentCol)//if we are out end of loop
                {
                    Console.WriteLine("Bad news, you are out of the bakery.");
                    break;
                }

                if (matrixChar[currentRow, currentCol] == 'O')
                {
                    if (currentRow == mirror1Row && currentCol == mirror1Col)//1st mirror//?
                    {
                        matrixChar[currentRow, currentCol] = '-';
                        currentRow = mirror2Row;
                        currentCol = mirror2Col;
                    }
                    else
                    {
                        currentRow = mirror1Row;
                        currentCol = mirror1Col;
                    }
                }
                else if (char.IsDigit(matrixChar[currentRow, currentCol]))
                {
                    int value = int.Parse(matrixChar[currentRow, currentCol].ToString());//57/9
                    moneyTotal += value;
                }
                matrixChar[currentRow, currentCol] = 'S';
                if (moneyTotal >= 50)
                {
                    break;
                }
                command = Console.ReadLine();
            }
            if (moneyTotal >= 50)
            {
                Console.WriteLine("Good news! You succeeded in collecting enough money!");
            }
            Console.WriteLine($"Money: {moneyTotal}");
            PrintMatrix(matrixChar, x => Console.Write(x));
            static void PrintMatrix<T>(T[,] matrix, Action<T> printer)
            {
                for (int row = 0; row < matrix.GetLength(0); row++)
                {
                    for (int col = 0; col < matrix.GetLength(1); col++)
                    {
                        printer(matrix[row, col]);
                    }
                    Console.WriteLine();
                }
            }
        }
    }
}
