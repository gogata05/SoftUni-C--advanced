Stack<char> stackChar = new(Console.ReadLine().ToCharArray());
while (stackChar.Count!=0)
{

    Console.Write(stackChar.Pop());
}