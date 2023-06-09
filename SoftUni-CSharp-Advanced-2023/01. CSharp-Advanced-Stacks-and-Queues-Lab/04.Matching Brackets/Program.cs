string text = Console.ReadLine();
Stack<int> stackOpenBracket = new();
//5+(6 +2)+((3 -1)-9)
for (int i = 0; i < text.Length; i++)
{
    char check = text[i];
    if (text[i] == '(')
    {
        stackOpenBracket.Push(i);
    }

    if (text[i] == ')')
    {
        int openBracket = stackOpenBracket.Pop();//
        for (int j = openBracket ; j <= i; j++)//2 ,7
        {
            Console.Write(text[j]);
        }

        Console.WriteLine();
    }
}


//                        if (expression[j] == ' ')
//                        {
//                            continue;
//                        }
//                      