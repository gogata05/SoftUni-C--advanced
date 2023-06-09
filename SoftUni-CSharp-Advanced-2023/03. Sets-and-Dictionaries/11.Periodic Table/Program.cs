SortedSet<string> set = new() { };
int n = int.Parse(Console.ReadLine());
for (int i = 0; i < n; i++)
{
    string[] inputArray = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
    set.UnionWith(inputArray); // change set    
}
Console.WriteLine(string.Join(" ", set));