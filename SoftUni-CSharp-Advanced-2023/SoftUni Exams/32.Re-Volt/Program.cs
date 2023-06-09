using System;
using System.ComponentModel.Design;

namespace TestRe_Volt
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int sizeMatrix = int.Parse(Console.ReadLine());//4
            int n = int.Parse(Console.ReadLine());
            char[,] matrixChar = new char[sizeMatrix, sizeMatrix]; //empty
            //curRow,curCol,oldRow,oldCol,mirror1Row,mirror1Col,mirror2Row,mirror2Col,isFirstMirrorFound
            bool isFinished = false;
            int curRow = 0;
            int curCol = 0;

            int oldRow = 0;
            int oldCol = 0;
            for (int row = 0; row < sizeMatrix; row++)
            {
                string dataRowMatrix = Console.ReadLine();
                for (int col = 0; col < sizeMatrix; col++)
                {
                    matrixChar[row, col] = dataRowMatrix[col];
                    if (matrixChar[row, col] == 'f')//1,1
                    {
                        curRow = row;
                        curCol = col;
                    }
                }
            }
            for (int i = 0; i < n; i++)
            {
                string command = Console.ReadLine();
                matrixChar[curRow, curCol] = '-';//last index
                oldRow = curRow;//1
                oldCol = curCol;//1
                switch (command)
                {
                    case "up":
                        curRow = (curRow - 1 + matrixChar.GetLength(0)) % matrixChar.GetLength(0);
                        break;
                    case "down":
                        curRow = (curRow + 1) % matrixChar.GetLength(0);
                        break;
                    case "left":
                        curCol = (curCol - 1 + matrixChar.GetLength(1)) % matrixChar.GetLength(1);
                        break;
                    case "right":
                        curCol = (curCol + 1) % matrixChar.GetLength(1);
                        break;
                }

                //if (curRow < 0 || curCol < 0 || matrixChar.GetLength(0) <= curRow ||
                //    matrixChar.GetLength(1) <= curCol) //if we are out end of loop
                ////other side?
                //{
                //    //curRow = oldRow; 
                //    //curCol = oldCol;
                //}
                string currentChar = matrixChar[curRow, curCol].ToString();
                if (matrixChar[curRow, curCol] == 'F')
                {
                    isFinished = true;
                    break;
                }
                else if (matrixChar[curRow, curCol] == 'B')//if outside//other side?
                {
                    oldRow = curRow;
                    oldCol = curCol;
                    switch (command)
                    {
                        case "up":
                            curRow = (curRow - 1 + matrixChar.GetLength(0)) % matrixChar.GetLength(0);
                            break;
                        case "down":
                            curRow = (curRow + 1) % matrixChar.GetLength(0);
                            break;
                        case "left":
                            curCol = (curCol - 1 + matrixChar.GetLength(1)) % matrixChar.GetLength(1);
                            break;
                        case "right":
                            curCol = (curCol + 1) % matrixChar.GetLength(1);
                            break;
                    }
                    if (matrixChar[curRow, curCol] == 'F')
                    {
                        isFinished = true;
                        break;
                    }
                }
                else if (matrixChar[curRow, curCol] == 'T')
                {
                    curRow = oldRow;
                    curCol = oldCol;
                }

                matrixChar[curRow, curCol] = 'f';
            }
            //-fFBT - empty - player - finish(end) - bonus(+1 move same direction) - traps(old pos)
            if (isFinished)
            {
                matrixChar[curRow, curCol] = 'f';
                Console.WriteLine("Player won!");
            }
            else
            {
                Console.WriteLine("Player lost!");
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
