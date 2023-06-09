int n = int.Parse(Console.ReadLine());
HashSet<string> hashSetText = new() { };
for (int i = 0; i < n; i++)
{
    hashSetText.Add(Console.ReadLine());
}

Console.WriteLine(string.Join(Environment.NewLine, hashSetText));