using System;
using System.Collections.Generic;
using System.Text;

namespace ComputerArchitecture
{
    public class CPU
    {
        //Ctor
        public CPU(string brand, int cores, double frequency)
        {
            Brand = brand;
            Cores = cores;
            Frequency = frequency;
        }
        //prop
        public string Brand { get; set; }
        public int Cores { get; set; }
        public double Frequency { get; set; }

        //"{brand} CPU: 
        //Cores: {cores}
        // Frequency: {frequency} GHz" 
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{Brand} CPU:");
            sb.AppendLine($"Cores: {Cores}");
            sb.AppendLine($"Frequency: {Frequency:f1} GHz");
            return sb.ToString().TrimEnd();
        }
    }
}
