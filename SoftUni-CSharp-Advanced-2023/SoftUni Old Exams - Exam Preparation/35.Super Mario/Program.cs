using System;
//-MBP - empty - mario(-1 per move) - enemy(if hit -2 live) - princess(win the games ,remove M,P from matrix)
class Program
{
    static void Main(string[] args)
    {
        int lives = int.Parse(Console.ReadLine());//100
        int sizeMatrix = int.Parse(Console.ReadLine());//5 jagged
        char[][] matrixChar = new char[sizeMatrix][];//jagged cuz there is a jagged input in judge
        int[] curPosition = new int[2];//index possition M
        for (int i = 0; i < sizeMatrix; i++)
        {
            string matrixDataRow = Console.ReadLine();
            matrixChar[i] = matrixDataRow.ToCharArray();
            if (matrixDataRow.Contains('M'))//if empty
            {
                curPosition[0] = i;
                curPosition[1] = matrixDataRow.IndexOf('M');
            }
        }
        while (true)//command could be W,S,A,D//up,down,left,right
        {
            string[] commandArray = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string act = commandArray[0];//W,S,A,D
            int spawnRow = int.Parse(commandArray[1]);
            int spawnCol = int.Parse(commandArray[2]);
            matrixChar[spawnRow][spawnCol] = 'B';
            int[] newPos = new int[2] { curPosition[0], curPosition[1] };
            switch (act)
            {
                case "W": newPos[0]--; break;//up
                case "S": newPos[0]++; break;//down
                case "A": newPos[1]--; break;//left
                case "D": newPos[1]++; break;//right
            }
            lives--;
            if (newPos[0] < 0 || newPos[0] >= sizeMatrix || newPos[1] < 0 || newPos[1] >= matrixChar[newPos[0]].Length)
            {
                newPos[0] = curPosition[0];
                newPos[1] = curPosition[1];
            }
            if (matrixChar[newPos[0]][newPos[1]] == 'B')
            {
                lives -= 2;
            }
            if (matrixChar[newPos[0]][newPos[1]] == 'P' || lives <= 0)
            {
                matrixChar[curPosition[0]][curPosition[1]] = '-';
                if (lives > 0)
                {
                    matrixChar[newPos[0]][newPos[1]] = '-';
                    Console.WriteLine($"Mario has successfully saved the princess! Lives left: {lives}");
                }
                else
                {
                    matrixChar[newPos[0]][newPos[1]] = 'X';
                    Console.WriteLine($"Mario died at {newPos[0]};{newPos[1]}.");
                }
                break;
            }
            else
            {
                matrixChar[curPosition[0]][curPosition[1]] = '-';
                matrixChar[newPos[0]][newPos[1]] = 'M';
                curPosition = newPos;
            }
        }
        for (int i = 0; i < sizeMatrix; i++)
        {
            Console.WriteLine(new string(matrixChar[i]));
        }
    }
}
