double[] numArray = Console.ReadLine().Split(new string[]{", "},StringSplitOptions.RemoveEmptyEntries)
    .Select(double.Parse).Select(x=>x*1.2).ToArray();
foreach (var item in numArray)
{
    Console.WriteLine($"{item:f2}");
}