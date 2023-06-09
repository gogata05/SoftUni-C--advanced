using System;
class Program
{
    static void Main()
    {
        int sizeMatrix = int.Parse(Console.ReadLine()); // 5
        char[,] matrixChar = new char[sizeMatrix, sizeMatrix];

        for (int i = 0; i < sizeMatrix; i++)
        {
            string input = Console.ReadLine().Replace(" ", "");
            for (int j = 0; j < sizeMatrix; j++)
            {
                matrixChar[i, j] = input[j];
            }
        }
        int black = 0;
        int summer = 0;
        int white = 0;
        int boarCount = 0;
        string command = Console.ReadLine();
        while (command != "Stop the hunt")
        {
            string[] commandArray = command.Split(' ');
            string act = commandArray[0];
            int rowCommand = int.Parse(commandArray[1]);
            int colCommand = int.Parse(commandArray[2]);
            if (act == "Collect")
            {
                if (matrixChar[rowCommand, colCommand] != '-')
                {
                    char truffle = matrixChar[rowCommand, colCommand];//B,S,W
                    if (truffle == 'B')
                        black++;
                    else if (truffle == 'S')
                        summer++;
                    else if (truffle == 'W')
                        white++;

                    matrixChar[rowCommand, colCommand] = '-';
                }
            }
            else if (act == "Wild_Boar")
            {
                string directionCommand = commandArray[3];//up,down,left,right
                int steps = 0;
                int curRow = 0;
                int curCol = 0;
                switch (directionCommand)
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

                while (rowCommand >= 0 && rowCommand < matrixChar.GetLength(0) && colCommand >= 0 && colCommand < matrixChar.GetLength(1))
                {
                    if (steps % 2 == 0 && matrixChar[rowCommand, colCommand] != '-')//even and index its not '-'
                    {
                        boarCount++;
                        matrixChar[rowCommand, colCommand] = '-';
                    }
                    rowCommand += curRow;
                    colCommand += curCol;
                    steps++;
                }
            }
            command = Console.ReadLine();
        }

        Console.WriteLine($"Peter manages to harvest {black} black, {summer} summer, and {white} white truffles.");
        Console.WriteLine($"The wild boar has eaten {boarCount} truffles.");

        PrintMatrix(matrixChar, e => Console.Write(e+" "));
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
