using System;
using System.Collections.Generic;
using System.Linq;

namespace TestScheduling
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<int> stackNumTasks = new Stack<int>(Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));

            Queue<int> queueNumThreads = new Queue<int>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));

            int taskToBeKilled = int.Parse(Console.ReadLine());
            int value = 0;

            while (stackNumTasks.Any() && queueNumThreads.Any())
            {
                if (stackNumTasks.Peek() == taskToBeKilled)
                {
                    value = queueNumThreads.Peek();
                    break;
                }
                if (queueNumThreads.Peek() >= stackNumTasks.Peek())
                {
                    queueNumThreads.Dequeue();
                    stackNumTasks.Pop();
                }
                else
                {
                    queueNumThreads.Dequeue();
                }
            }

            Console.WriteLine($"Thread with value {value} killed task {taskToBeKilled}");//?

            if (queueNumThreads.Any())
            {
                Console.WriteLine(string.Join(" ", queueNumThreads));
            }

        }
    }
}