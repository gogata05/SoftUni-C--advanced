using System;
//-AOM - empty - army(-1 per move) - enemyOrc(if hit -2 live) - mordor(win the games ,remove A,M from matrix)
namespace TheBattleOfTheFiveArmies
{
    class Program
    {
        static void Main(string[] args)
        {
            int lives = int.Parse(Console.ReadLine());//100
            int sizeMatrix = int.Parse(Console.ReadLine());//5
            char[][] jaggedChar = new char[sizeMatrix][];//jagged cuz there is a jagged input in judge
            int curRow = 0;
            int curCol = 0;
            for (int row = 0; row < sizeMatrix; row++)
            {
                char[] dataRowJagged = Console.ReadLine().ToCharArray();
                jaggedChar[row] = dataRowJagged;
                //100 
                //5 
                //--M-- 
                //----- 
                //----- 
                //----- 
                //--A-- 
                //up 3 0 
                //up 3 1 
                //up 3 2 
                //up 3 3
            }

            for (int row = 0; row < sizeMatrix; row++)
            {
                for (int col = 0; col < jaggedChar[row].Length; col++)
                {
                    if (jaggedChar[row][col] == 'A')
                    {
                        curRow = row;
                        curCol = col;
                    }
                }
            }
            while (true)
            {
                string[] commandArray = Console.ReadLine().Split();
                string move = commandArray[0];
                int spawnRow = int.Parse(commandArray[1]);
                int spawnCol = int.Parse(commandArray[2]);



                jaggedChar[spawnRow][spawnCol] = 'O';
                if (move == "up" && curRow - 1 >= 0)
                {
                    jaggedChar[curRow][curCol] = '-';
                    curRow--;
                }
                else if (move == "right" && curCol + 1 < jaggedChar[curRow].Length)
                {
                    jaggedChar[curRow][curCol] = '-';
                    curCol++;
                }
                else if (move == "left" && curCol - 1 >= 0)
                {
                    jaggedChar[curRow][curCol] = '-';
                    curCol--;
                }
                else if (move == "down" && curRow + 1 < sizeMatrix)
                {
                    jaggedChar[curRow][curCol] = '-';
                    curRow++;
                }

                lives--;
                if (lives <= 0)
                {
                    jaggedChar[curRow][curCol] = 'X';
                    Console.WriteLine($"The army was defeated at {curRow};{curCol}.");
                    break;
                }
                if (jaggedChar[curRow][curCol] == 'O')
                {
                    lives -= 2;
                    if (lives <= 0)
                    {
                        jaggedChar[curRow][curCol] = 'X';
                        Console.WriteLine($"The army was defeated at {curRow};{curCol}.");
                        break;
                    }
                }
                else if (jaggedChar[curRow][curCol] == 'M')
                {
                    jaggedChar[curRow][curCol] = '-';
                    Console.WriteLine($"The army managed to free the Middle World! Armor left: {lives}");
                    break;
                }
            }
            for (int i = 0; i < sizeMatrix; i++)
            {
                Console.WriteLine(String.Join("", jaggedChar[i]));
            }
        }
    }
}
