using System;
using System.Collections.Generic;
using System.Text;

namespace ComputerArchitecture
{
    public class CPU
    {
        //ctor
        public CPU(string brand, int cores, double frequencyrand)
        {
            this.Brand = brand;
            this.Cores = cores;
            this.Frequencyrand = frequencyrand;
        }
        //prop
        public string Brand { get; set; }
        public int Cores { get; set; }
        public double Frequencyrand { get; set; }
        public override string ToString()//to write in console
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"{Brand} CPU:");
            sb.Append($"Cores: {Cores}");
            sb.Append($"Frequency: {Frequencyrand} GHz");
            return sb.ToString().Trim();
        }
    }
}
