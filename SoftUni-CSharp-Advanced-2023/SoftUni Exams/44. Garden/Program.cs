using System;
namespace Garden
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] sizeMatrixArray = Console.ReadLine().Split(" ");//5 5 
            //5 5 
            //1 1 
            //3 3 
            //Bloom Bloom Plow 
            int n = int.Parse(sizeMatrixArray[0].ToString());
            int m = int.Parse(sizeMatrixArray[1].ToString());
            int[,] matrixInt = new int[n, m];
            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < m; col++)
                {
                    matrixInt[row, col] = 0;
                }
            }
            string command = Console.ReadLine();
            while (command != "Bloom Bloom Plow")//Input can be wrong!
            {
                string[] commandArray = command.Split();
                int boomRow = int.Parse(commandArray[0].ToString());
                int boomCol = int.Parse(commandArray[1].ToString());

                if (boomRow < n && boomCol < m)//5 5
                {
                    for (int i = 0; i < n; i++)
                    {
                        matrixInt[i, boomCol]++;
                    }
                    for (int i = 0; i < m; i++)
                    {
                        if (i != boomCol)
                        {
                            matrixInt[boomRow, i]++;
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Invalid coordinates.");
                }
                command = Console.ReadLine();
            }
            PrintMatrix(matrixInt, e => Console.Write(e+" "));
            static void PrintMatrix<T>(T[,] matrixInt, Action<T> printer)
            {
                for (int row = 0; row < matrixInt.GetLength(0); row++)
                {
                    for (int col = 0; col < matrixInt.GetLength(1); col++)
                    {
                        printer(matrixInt[row, col]);
                    }

                    Console.WriteLine();
                }
            }
        }
        //0 1 0 1 0 
        //1 1 1 2 1 
        //0 1 0 1 0 
        //1 2 1 1 1 
        //0 1 0 1 0//everything is 0,we boom on 1.1 and everything on up,down,left,right goes +1,we boom on 3.3 and everything on up,down,left,right goes +1
    }
}