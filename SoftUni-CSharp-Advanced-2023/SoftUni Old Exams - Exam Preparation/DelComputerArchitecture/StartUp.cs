using System;

namespace ComputerArchitecture
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            CPU cpu = new CPU("dell", 8, 3);
            Console.WriteLine(cpu);

        }
    }
}
