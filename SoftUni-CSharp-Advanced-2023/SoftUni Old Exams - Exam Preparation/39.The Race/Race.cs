using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace TheRace
{
    public class Race
    {
        private readonly List<Racer> data;

        public Race(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            data = new List<Racer>();
        }

        public string Name { get; set; }
        public int Capacity { get; set; }

        public void Add(Racer racer)
        {
            if (data.Count < Capacity)
            {
                data.Add(racer);
            }
        }

        public bool Remove(string name)
        {
            var racer = data.FirstOrDefault(r => r.Name == name);
            if (racer != null)
            {
                data.Remove(racer);
                return true;
            }

            return false;
        }

        public Racer GetOldestRacer()
        {
            return data.OrderByDescending(r => r.Age).FirstOrDefault();
        }

        public Racer GetRacer(string name)
        {
            return data.FirstOrDefault(r => r.Name == name);
        }

        public Racer GetFastestRacer()
        {
            return data.OrderByDescending(r => r.Car.Speed).FirstOrDefault();
        }

        public int Count => data.Count;

        public string Report()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Racers participating at {Name}:");
            foreach (var racer in data)
            {
                sb.AppendLine(racer.ToString());
            }

            return sb.ToString();
        }
    }
}
