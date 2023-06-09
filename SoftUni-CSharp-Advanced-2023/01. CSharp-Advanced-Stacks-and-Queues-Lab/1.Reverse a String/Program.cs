
//List<char> charList = Console.ReadLine().ToCharArray().ToList();

Stack<char> stackChar = new(Console.ReadLine().ToCharArray());
//foreach (var item in input)//hello
//{
//    stackChar.Push(item);

//}
while (stackChar.Count != 0)
{
    Console.Write(stackChar.Pop());
}
//Console.WriteLine(String.Join("",stackChar));
