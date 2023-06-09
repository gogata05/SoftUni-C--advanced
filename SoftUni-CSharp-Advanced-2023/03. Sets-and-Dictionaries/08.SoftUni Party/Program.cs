HashSet<string> hashSetVip = new() { };
HashSet<string> hashSetRegular = new() { };
string command = Console.ReadLine();
while (command!= "PARTY")
{
    if (!string.IsNullOrEmpty(command) && char.IsDigit(command[0]))
    {
        hashSetVip.Add(command);
    }
    else
    {
        hashSetRegular.Add(command);
    }
    command = Console.ReadLine();
}
command = Console.ReadLine();
while (command!="END")
{
    if (!string.IsNullOrEmpty(command) && char.IsDigit(command[0]))
    {
        hashSetVip.Remove(command);
    }
    else
    {
        hashSetRegular.Remove(command);
    }
    command = Console.ReadLine();
}
int count = hashSetVip.Count + hashSetRegular.Count;
Console.WriteLine(count);
if (hashSetVip.Count!=0)
{
    Console.WriteLine(string.Join(Environment.NewLine, hashSetVip));
}

if (hashSetRegular.Count!=0)
{
    Console.WriteLine(string.Join(Environment.NewLine, hashSetRegular));
}
