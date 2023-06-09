//5
//01
//. . . . . 
//. . . T . 
//. . . . . 
//. T . . . 
//. . F . .
//down 
//right 
//right 
//right 
//down 
//right 
//up 
//down 
//right 
//up 
//End
using System;
namespace TestRallyRacing
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int sizeMatrix = int.Parse(Console.ReadLine()); //5
            string carNumber = Console.ReadLine();//01
            char[,] matrixChar = new char[sizeMatrix, sizeMatrix]; //empty
            int totalKm = 0;
            int curRow = 0;//always start from 0,0
            int curCol = 0;

            bool isRaceFinished = false;
            bool isFirstMirrorFound = false;
            int mirror1Row = 0;
            int mirror1Col = 0;

            int mirror2Row = 0;
            int mirror2Col = 0;

            string[] input = Console.ReadLine().Split(", ");
            //curRow,curCol,oldRow,oldCol,mirror1Row,mirror1Col,mirror2Row,mirror2Col,isFirstMirrorFound
            for (int row = 0; row < sizeMatrix; row++)
            {
                string[] arrayDataRow = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);//for matrix with empty spaces
                string dataRowMatrix = string.Concat(arrayDataRow);//for matrix with empty spaces
                for (int col = 0; col < sizeMatrix; col++)
                {
                    matrixChar[row, col] = dataRowMatrix[col];
                    if (matrixChar[row, col] == 'T')
                    {
                        if (!isFirstMirrorFound)//?
                        {
                            isFirstMirrorFound = true;
                            mirror1Row = row;//1
                            mirror1Col = col;//3
                        }
                        else
                        {
                            mirror2Row = row;//3
                            mirror2Col = col;//1
                        }
                    }
                }
            }
            matrixChar[curRow, curCol] = 'C';
            string command = Console.ReadLine().ToLower();
            while (command != "end")
            {
                matrixChar[curRow, curCol] = '.';//last position
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
                string currentChar = matrixChar[curRow, curCol].ToString();
                //.CTF = empty - car - mirror - finish
                if (matrixChar[curRow, curCol] == '.')
                {
                    totalKm += 10;
                }
                else if (matrixChar[curRow, curCol] == 'F')
                {
                    totalKm += 10;
                    isRaceFinished = true;
                    matrixChar[curRow, curCol] = 'C';
                    break;
                }
                else if (matrixChar[curRow, curCol] == 'T')
                {
                    matrixChar[curRow, curCol] = '.';
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
                    matrixChar[curRow, curCol] = '.';
                    totalKm += 30;
                }
                matrixChar[curRow, curCol] = 'C';
                command = Console.ReadLine().ToLower();
            }

            if (isRaceFinished)
            {
                Console.WriteLine($"Racing car {carNumber} finished the stage!");
            }
            else
            {
                Console.WriteLine($"Racing car {carNumber} DNF.");
            }
            Console.WriteLine($"Distance covered {totalKm} km.");

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











