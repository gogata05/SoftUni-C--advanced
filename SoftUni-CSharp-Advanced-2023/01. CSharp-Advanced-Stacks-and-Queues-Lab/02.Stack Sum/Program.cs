Stack<int> stackNum = new(Console.ReadLine().Split().Select(int.Parse));//1 2 3 4
int sum = 0;
string command = Console.ReadLine().ToLower();//adD 5 6//REmove 3//eNd
while (command != "end")
{
    string[] commandArray = command.Split();//adD 5 6//REmove 3//eNd
    if (commandArray[0] == "add")
    {
        int first = int.Parse(commandArray[1]);
        int second = int.Parse(commandArray[2]);
        stackNum.Push(first);
        stackNum.Push(second);
    }
    if (commandArray[0] == "remove")
    {
        int n = int.Parse(commandArray[1]);
        if (n <= stackNum.Count)
        {
            for (int i = 0; i < n; i++)//untill 0
            {
                stackNum.Pop();
            }
        }
    }
    command = Console.ReadLine().ToLower();
}
//while (stackNum.Count != 0)
//{
//    sum += stackNum.Pop();
//}
//Console.WriteLine($"Sum: {sum}");
sum = stackNum.Sum();
Console.WriteLine($"Sum: {sum} ");
//Console.WriteLine(string.Join(" ", stackNum));