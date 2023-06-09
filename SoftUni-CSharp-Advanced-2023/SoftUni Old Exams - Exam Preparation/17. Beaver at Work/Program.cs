using System;
using System.Collections.Generic;
//-BF - empty - beaver - fish - 
namespace _02._Beaver_at_Work
{
    class Program
    {
        static void Main(string[] args)
        {
            int sizeMatrix = int.Parse(Console.ReadLine());
            string[,] matrixStringChar = new string[sizeMatrix, sizeMatrix];
            List<string> ListWoodCollected = new List<string>();
            int beaverRow = 0;
            int beaverCol = 0;
            int woodLeft = 0;
            for (int rows = 0; rows < matrixStringChar.GetLength(0); rows++)
            {
                string[] colDataArray = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                for (int cols = 0; cols < matrixStringChar.GetLength(1); cols++)
                {
                    matrixStringChar[rows, cols] = colDataArray[cols];
                    if (matrixStringChar[rows, cols] == "B")
                    {
                        beaverRow = rows;
                        beaverCol = cols;
                    }
                    if (matrixStringChar[rows, cols] != "B" && matrixStringChar[rows, cols] != "F" && matrixStringChar[rows, cols] != "-")
                    {
                        woodLeft++;
                    }
                }
            }
            while (true)
            {
                string input = Console.ReadLine();
                matrixStringChar[beaverRow, beaverCol] = "-";
                if (input == "end")
                { matrixStringChar[beaverRow, beaverCol] = "B"; break; }
                else if (input == "up")
                {
                    beaverRow--;
                    if (beaverRow >= 0)
                    {
                        if (matrixStringChar[beaverRow, beaverCol] == "F")
                        {
                            matrixStringChar[beaverRow, beaverCol] = "-";
                            beaverRow = sizeMatrix - 1;
                            if (matrixStringChar[beaverRow, beaverCol] == "F")
                            {
                                matrixStringChar[beaverRow, beaverCol] = "-";
                                beaverRow = 0;
                            }
                            if (matrixStringChar[beaverRow, beaverCol] == "F")
                            {
                                matrixStringChar[beaverRow, beaverCol] = "-";
                                beaverRow = sizeMatrix - 1;
                            }
                        }
                        else if (matrixStringChar[beaverRow, beaverCol] == "-")
                        { continue; }
                        else
                        {
                            ListWoodCollected.Add(matrixStringChar[beaverRow, beaverCol]);
                            woodLeft--;
                        }
                    }
                    else
                    {
                        ListWoodCollected.RemoveAt(ListWoodCollected.Count - 1);
                        beaverRow++;
                    }
                }
                else if (input == "down")
                {
                    beaverRow++;
                    if (beaverRow < sizeMatrix)
                    {
                        if (matrixStringChar[beaverRow, beaverCol] == "F")
                        {
                            matrixStringChar[beaverRow, beaverCol] = "-";
                            beaverRow = 0;
                            if (matrixStringChar[beaverRow, beaverCol] == "F")
                            {
                                matrixStringChar[beaverRow, beaverCol] = "-";
                                beaverRow = sizeMatrix - 1;
                            }
                            if (matrixStringChar[beaverRow, beaverCol] == "F")
                            {
                                matrixStringChar[beaverRow, beaverCol] = "-";
                                beaverRow = 0;
                            }
                        }
                        else if (matrixStringChar[beaverRow, beaverCol] == "-")
                        { continue; }
                        else
                        {
                            ListWoodCollected.Add(matrixStringChar[beaverRow, beaverCol]);
                            woodLeft--;
                        }
                    }
                    else
                    {
                        ListWoodCollected.RemoveAt(ListWoodCollected.Count - 1);
                        beaverRow--;
                    }
                }
                else if (input == "right")
                {
                    beaverCol++;
                    if (beaverCol < sizeMatrix)
                    {
                        if (matrixStringChar[beaverRow, beaverCol] == "F")
                        {
                            matrixStringChar[beaverRow, beaverCol] = "-";
                            beaverCol = 0;
                            if (matrixStringChar[beaverRow, beaverCol] == "F")
                            {
                                matrixStringChar[beaverRow, beaverCol] = "-";
                                beaverCol = sizeMatrix - 1;
                            }
                            if (matrixStringChar[beaverRow, beaverCol] == "F")
                            {
                                matrixStringChar[beaverRow, beaverCol] = "-";
                                beaverCol = 0;
                            }
                        }
                        else if (matrixStringChar[beaverRow, beaverCol] == "-")
                        { continue; }
                        else
                        {
                            ListWoodCollected.Add(matrixStringChar[beaverRow, beaverCol]);
                            woodLeft--;
                        }
                    }
                    else
                    {
                        ListWoodCollected.RemoveAt(ListWoodCollected.Count - 1);
                        beaverCol--;
                    }
                }
                else if (input == "left")
                {
                    beaverCol--;
                    if (beaverCol >= 0)
                    {
                        if (matrixStringChar[beaverRow, beaverCol] == "F")
                        {
                            matrixStringChar[beaverRow, beaverCol] = "-";
                            beaverCol = sizeMatrix - 1;
                            if (matrixStringChar[beaverRow, beaverCol] == "F")
                            {
                                matrixStringChar[beaverRow, beaverCol] = "-";
                                beaverCol = 0;
                            }
                            if (matrixStringChar[beaverRow, beaverCol] == "F")
                            {
                                matrixStringChar[beaverRow, beaverCol] = "-";
                                beaverCol = sizeMatrix - 1;
                            }
                        }
                        else if (matrixStringChar[beaverRow, beaverCol] == "-")
                        { continue; }
                        else
                        {
                            ListWoodCollected.Add(matrixStringChar[beaverRow, beaverCol]);
                            woodLeft--;
                        }
                    }
                    else
                    {
                        ListWoodCollected.RemoveAt(ListWoodCollected.Count - 1);
                        beaverCol++;
                    }
                }
                if (woodLeft == 0)
                { matrixStringChar[beaverRow, beaverCol] = "B"; break; }
            }
            if (woodLeft > 0)
            {
                Console.WriteLine($"The Beaver failed to collect every wood branch. There are {woodLeft} branches left.");
            }
            else
            {
                Console.WriteLine($"The Beaver successfully collect {ListWoodCollected.Count} wood branches: {string.Join(", ", ListWoodCollected)}.");
            }
            for (int rows = 0; rows < sizeMatrix; rows++)
            {
                for (int cols = 0; cols < sizeMatrix; cols++)
                {
                    Console.Write($"{string.Join(' ', matrixStringChar[rows, cols])}");
                }
                Console.WriteLine();
            }
        }
    }
}
