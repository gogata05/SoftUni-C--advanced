using System;
namespace TestBee
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int sizeMatrix = int.Parse(Console.ReadLine()); //5
            char[,] matrixChar = new char[sizeMatrix, sizeMatrix]; //empty
            //curRow,curCol,oldRow,oldCol,mirror1Row,mirror1Col,mirror2Row,mirror2Col,isFirstMirrorFound
            int flowerCount = 0;
            int curRow = 0;
            int curCol = 0;

            int bonusRow = 0;
            int bonusCol = 0;
            for (int row = 0; row < sizeMatrix; row++)
            {
                string dataRowMatrix = Console.ReadLine();
                for (int col = 0; col < sizeMatrix; col++)
                {
                    matrixChar[row, col] = dataRowMatrix[col];
                    if (matrixChar[row, col] == 'B')
                    {
                        curRow = row;
                        curCol = col;
                    }
                    else if (matrixChar[row, col] == 'O')
                    {
                        bonusRow = row;
                        bonusCol = col;
                    }
                }
            }
            string command = Console.ReadLine().ToLower();
            while (command != "end")
            {
                matrixChar[curRow, curCol] = '.';
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
                    Console.WriteLine("The bee got lost!");
                    break;
                }
                string currentChar = matrixChar[curRow, curCol].ToString();
                if (matrixChar[curRow, curCol] == 'O')
                {
                    matrixChar[curRow, curCol] = '.';
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
                    if (matrixChar[curRow, curCol] == 'f')
                    {
                        flowerCount++;
                    }
                }
                else if (matrixChar[curRow, curCol] == 'f')
                {
                    flowerCount++;
                }
                matrixChar[curRow, curCol] = 'B';
                command = Console.ReadLine().ToLower();
            }
            //.BFO - empty - bee - flower(count++) - bonus(jump again same way)
            if (flowerCount >= 5)
            {
                Console.WriteLine($"Great job, the bee managed to pollinate {flowerCount} flowers!");
            }
            else
            {
                int difference = 5 - flowerCount;
                Console.WriteLine($"The bee couldn't pollinate the flowers, she needed {difference} flowers more");
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
