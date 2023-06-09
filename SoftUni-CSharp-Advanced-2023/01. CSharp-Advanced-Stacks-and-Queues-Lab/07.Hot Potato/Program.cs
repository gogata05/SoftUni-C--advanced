Queue<string> queue = new(Console.ReadLine().Split());
int n = int.Parse(Console.ReadLine());
int tosses = 1;
//Alva James William 
//2 
while (queue.Count != 1)
{
    string child = queue.Dequeue();
    if (tosses < n)//10<2
    {
        tosses++;
        queue.Enqueue(child);
    }
    else
    {
        Console.WriteLine($"Removed {child}");
        tosses = 1;
    }
}

Console.WriteLine($"Last is {queue.Dequeue()}");
