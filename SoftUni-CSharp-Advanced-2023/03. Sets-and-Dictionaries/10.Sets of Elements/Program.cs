HashSet<int> set1 = new() { };
HashSet<int> set2 = new() { };
int[] splitArray = Console.ReadLine().Split().Select(int.Parse).ToArray();
for (int i = 0; i < splitArray[0]; i++)
{
    set1.Add(int.Parse(Console.ReadLine()));
}

for (int i = 0; i < splitArray[1]; i++)
{
    set2.Add(int.Parse(Console.ReadLine()));
}

set1.IntersectWith(set2);
Console.WriteLine(string.Join(" ", set1));