using System;
using System.Collections.Generic;
using System.Text;

namespace ComputerArchitecture
{
    public class Computer
    {
        //ctor
        public Computer(string model, int capacity)
        {
            Model = model;
            Capacity = capacity;
            Multiprocessor = new List<CPU>();
        }
        //prop
        public string Model { get; set; }
        public int Capacity { get; set; }
        public List<CPU> Multiprocessor { get; set; }
        public int Count{get {return Multiprocessor.Count;}}

        public void Add(CPU cpu)
        {
            if (Multiprocessor.Count < Capacity)
            {
                Multiprocessor.Add(cpu);
            }
        }
        public bool Remove(string brand)
        {
            CPU cpuToRemove = Multiprocessor.Find(x => x.Brand == brand);
            if (cpuToRemove != null)
            {
                Multiprocessor.Remove(cpuToRemove);
                return true;
            }
            return false;
        }

        public CPU MostPowerful()
        {
            if (Multiprocessor.Count==0)
            {
                return null;
            }
            CPU mostPowerful = Multiprocessor[0];
            foreach (var cpu in Multiprocessor)
            {
                if (cpu.Frequencyrand > mostPowerful.Frequencyrand)
                {
                    mostPowerful = cpu;
                }
            }
            return mostPowerful;
        }

        public CPU GetCPU(string brand)
        {
            return Multiprocessor.Find(x => x.Brand == brand);
        }
        //CPUs in the Computer {model}: 
        //{CPU1
        //{CPU2
       

        public string Report(string name)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"CPUs in the Computer {Model}:");
            foreach (var cpu in Multiprocessor)
            {
                sb.AppendLine(cpu.ToString());
            }
            return sb.ToString().Trim();
        }
    }
}
