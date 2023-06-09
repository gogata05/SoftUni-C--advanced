using System;

namespace _02.Survivor
{
    public class Program
    {
        static void Main(string[] args)
        {
            int rowsJagged = int.Parse(Console.ReadLine());
            char[][] jaggedChar = new char[rowsJagged][];

            for (int row = 0; row < jaggedChar.GetLength(0); row++)
            {
                char[] dataJaggedRow = Console.ReadLine().Replace(" ", "").ToCharArray();
                jaggedChar[row] = dataJaggedRow;
            }

            string command = Console.ReadLine().ToLower();
            int collectedTokens = 0;
            int opponentTokens = 0;

            while (command != "gong")
            {
                string[] commandArray = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                if (commandArray.Length == 3)
                {
                    int row = int.Parse(commandArray[1]);
                    int col = int.Parse(commandArray[2]);
                    if (row >= 0 && row < jaggedChar.GetLength(0) && col >= 0 && col < jaggedChar[row].Length)
                    {
                        if (jaggedChar[row][col] == 'T')
                        {
                            collectedTokens += 1;
                            jaggedChar[row][col] = '-';
                        }
                    }
                }
                else
                {

                    int row = int.Parse(commandArray[1]);
                    int col = int.Parse(commandArray[2]);
                    string direction = commandArray[3];
                    if (row >= 0 && row < jaggedChar.GetLength(0) && col >= 0 && col < jaggedChar[row].Length)
                    {
                        if (jaggedChar[row][col] == 'T')
                        {
                            opponentTokens += 1;
                            jaggedChar[row][col] = '-';
                        }
                        switch (direction)
                        {
                            case "up":

                                for (int i = 1; i <= 3; i++)
                                {
                                    int movement = row - i;

                                    if (movement >= 0 && movement < jaggedChar.GetLength(0) && col >= 0 && col < jaggedChar[movement].Length)
                                    {
                                        if (jaggedChar[movement][col] == 'T')
                                        {
                                            opponentTokens += 1;
                                            jaggedChar[movement][col] = '-';
                                        }
                                    }
                                    else
                                    {
                                        break;
                                    }
                                }
                                break;
                            case "down":
                                for (int i = 1; i <= 3; i++)
                                {
                                    int movement = row + i;

                                    if (movement >= 0 && movement < jaggedChar.GetLength(0) && col >= 0 && col < jaggedChar[movement].Length)
                                    {
                                        if (jaggedChar[movement][col] == 'T')
                                        {
                                            opponentTokens += 1;
                                            jaggedChar[movement][col] = '-';
                                        }
                                    }
                                    else
                                    {
                                        break;
                                    }
                                }
                                break;
                            case "left":
                                for (int i = 1; i <= 3; i++)
                                {
                                    int movement = col - i;
                                    if (row >= 0 && row < jaggedChar.GetLength(0) && movement >= 0 && movement < jaggedChar[row].Length)
                                    {
                                        if (jaggedChar[row][movement] == 'T')
                                        {
                                            opponentTokens += 1;
                                            jaggedChar[row][movement] = '-';
                                        }
                                    }
                                    else
                                    {
                                        break;
                                    }
                                }
                                break;
                            case "right":
                                for (int i = 1; i <= 3; i++)
                                {
                                    int movement = col + i;

                                    if (row >= 0 && row < jaggedChar.GetLength(0) && movement >= 0 && movement < jaggedChar[row].Length)
                                    {
                                        if (jaggedChar[row][movement] == 'T')
                                        {
                                            opponentTokens += 1;
                                            jaggedChar[row][movement] = '-';
                                        }
                                    }
                                    else
                                    {
                                        break;
                                    }
                                }
                                break;
                        }
                    }
                }
                command = Console.ReadLine().ToLower();
            }

            // PrintMatrix
            foreach (char[] line in jaggedChar)
            {
                string currentLine = string.Join(' ', line);
                Console.WriteLine(currentLine);
            }

            Console.WriteLine($"Collected tokens: {collectedTokens}");
            Console.WriteLine($"Opponent's tokens: {opponentTokens}");
        }
    }
}
