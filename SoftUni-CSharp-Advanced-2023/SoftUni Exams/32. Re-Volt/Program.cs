using System;
//-fFBT - empty - player - finish(end program) - bonus(+1 move same direction) - traps(-1 move opposite direction)
namespace ReVolt
{
    class Program
    {
        static void Main(string[] args)
        {
            bool hasWin = false;
            int curRow = 0;
            int curCol = 0;
            int sizeMatrix = int.Parse(Console.ReadLine());//5
            int n = int.Parse(Console.ReadLine());//5
            char[][] matrixChar = new char[sizeMatrix][];//jagged
            for (int row = 0; row < sizeMatrix; row++)
            {
                string matrixRowData = Console.ReadLine();
                matrixChar[row] = new char[matrixRowData.Length];
                for (int col = 0; col < matrixChar[row].Length; col++)
                {
                    matrixChar[row][col] = matrixRowData[col];
                    if (matrixChar[row][col] == 'f')
                    {
                        curRow = row;
                        curCol = col;
                    }
                }
            }
            matrixChar[curRow][curCol] = '-';
            for (int index = 0; index < n; index++)
            {
                string command = Console.ReadLine();
                //down 
                //right 
                //down
                MovePlayer(matrixChar, curRow, curCol, command);
                if (hasWin == true)
                { break; }
            }
            void MovePlayer(char[][] matrixHere, int x, int y, string move)
            {
                if (move == "down")
                {
                    bool isInside = CheckInField(matrixHere, x + 1, y);
                    curRow = isInside == true ? curRow + 1 : 0;
                    if (matrixHere[curRow][curCol] == 'B')
                    {
                        MovePlayer(matrixChar, curRow, curCol, "down");
                    }
                    else if (matrixHere[curRow][curCol] == 'T')
                    {
                        MovePlayer(matrixChar, curRow, curCol, "up");
                    }
                    else if (matrixHere[curRow][curCol] == 'F')
                    {
                        Console.WriteLine("Player won!");
                        hasWin = true;
                    }
                }
                else if (move == "up")
                {
                    bool isInside = CheckInField(matrixHere, x - 1, y);
                    curRow = isInside == true ? curRow - 1 : matrixHere.Length - 1;
                    if (matrixHere[curRow][curCol] == 'B')
                    {
                        MovePlayer(matrixChar, curRow, curCol, "up");
                    }
                    else if (matrixHere[curRow][curCol] == 'T')
                    {
                        MovePlayer(matrixChar, curRow, curCol, "down");
                    }
                    else if (matrixHere[curRow][curCol] == 'F')
                    {
                        Console.WriteLine("Player won!");
                        hasWin = true;
                    }
                }
                else if (move == "left")
                {
                    bool isInside = CheckInField(matrixHere, x, y - 1);
                    curCol = isInside == true ? curCol - 1 : matrixHere.Length - 1;
                    if (matrixHere[curRow][curCol] == 'B')
                    {
                        MovePlayer(matrixChar, curRow, curCol, "left");
                    }
                    else if (matrixHere[curRow][curCol] == 'T')
                    {
                        MovePlayer(matrixChar, curRow, curCol, "right");
                    }
                    else if (matrixHere[curRow][curCol] == 'F')
                    {
                        Console.WriteLine("Player won!");
                        hasWin = true;
                    }
                }
                else if (move == "right")
                {
                    bool isInside = CheckInField(matrixHere, x, y + 1);
                    curCol = isInside == true ? curCol + 1 : 0;
                    if (matrixHere[curRow][curCol] == 'B')
                    {
                        MovePlayer(matrixChar, curRow, curCol, "right");
                    }
                    else if (matrixHere[curRow][curCol] == 'T')
                    {
                        MovePlayer(matrixChar, curRow, curCol, "left");
                    }
                    else if (matrixHere[curRow][curCol] == 'F')
                    {
                        Console.WriteLine("Player won!");
                        hasWin = true;
                    }
                }
            }
            static bool CheckInField(char[][] matrix, int x, int y)
            {
                return x >= 0 && y >= 0 && x < matrix.Length && y < matrix.Length;
            }
            matrixChar[curRow][curCol] = 'f';
            if (hasWin == false)
            {
                Console.WriteLine("Player lost!");
            }
            foreach (var row in matrixChar)
            {
                Console.WriteLine(row);
            }
        }
    }
}
//input:
//5 
//5 
//----- 
//-f--- 
//-B--- 
//--T-- 
//-F--- 
//down 
//right 
//down 

//Output:
//Player won! 
//----- 
//----- 
//-B--- 
//--T-- 
//-f--- 

