HashSet<string> hashSetText = new() { };
string command = Console.ReadLine();//to lower?
while (command!="END")
{
    string[] commandArray = command.Split(", ");
    string act = commandArray[0];
    string carNumber = commandArray[1];
    if (act=="IN")
    {
        hashSetText.Add(carNumber);
    }

    if (act == "OUT")
    {
        hashSetText.Remove(carNumber);
    }
    command = Console.ReadLine();
}

if (hashSetText.Count==0)
{
    Console.WriteLine($"Parking Lot is Empty");
}
else
{
    Console.WriteLine(string.Join(Environment.NewLine, hashSetText));
}
