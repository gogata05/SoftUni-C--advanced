using System;
using System.Linq;
//-А digit M - empty - armyOficer - swordNum - 2 side mirror(jump)
public class Program
{
    static void Main()
    {
        int sizeMatrix = int.Parse(Console.ReadLine());
        char[][] jaggedeArray = new char[sizeMatrix][];//?

        int curRow = -1;
        int curCol = -1;
        int[] mirrorArray = new int[4];
        int mirrorCount = 0;
        for (int i = 0; i < sizeMatrix; i++)
        {
            jaggedeArray[i] = Console.ReadLine().ToCharArray();
            if (jaggedeArray[i].Contains('A'))
            {
                curRow = i;
                curCol = Array.IndexOf(jaggedeArray[i], 'A');
            }
            if (jaggedeArray[i].Contains('M'))
            {
                mirrorArray[mirrorCount] = i;
                mirrorArray[mirrorCount + 1] = Array.IndexOf(jaggedeArray[i], 'M');
                mirrorCount += 2;
            }
        }
        int totalGold = 0;
        string command = Console.ReadLine();
        while (true)
        {
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

            if (curRow < 0 || curRow >= sizeMatrix || curCol < 0 || curCol >= sizeMatrix)
            {
                Console.WriteLine("I do not need more swords!");
                break;
            }
            else if (char.IsDigit(jaggedeArray[curRow][curCol]))
            {
                totalGold += jaggedeArray[curRow][curCol] - '0';
                jaggedeArray[curRow][curCol] = '-';
            }
            else if (jaggedeArray[curRow][curCol] == 'M')
            {
                jaggedeArray[curRow][curCol] = '-';
                jaggedeArray[mirrorArray[0]][mirrorArray[1]] = '-';
                curRow = mirrorArray[2];
                curCol = mirrorArray[3];
            }

            if (totalGold >= 65)
            {
                Console.WriteLine("Very nice swords, I will come back for more!");
                break;
            }
            command = Console.ReadLine();
        }
        Console.WriteLine($"The king paid {totalGold} gold coins.");
        foreach (var row in jaggedeArray)
        {
            Console.WriteLine(string.Join("", row));
        }
    }
}
