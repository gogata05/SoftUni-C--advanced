
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SkiRental
{
    
    public class SkiRental
    {
        private List<Ski> data;

        public SkiRental(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.data = new List<Ski>();
        }

        public string Name { get; set; }

        public int Capacity { get; set; }

        public void Add(Ski ski)
        {
            if (this.data.Count < this.Capacity)
            {
                this.data.Add(ski);
            }
        }

        public bool Remove(string manufacturer, string model)
        {
            Ski ski = this.data.FirstOrDefault(s => s.Manufacturer == manufacturer && s.Model == model);
            if (ski != null)
            {
                this.data.Remove(ski);
                return true;
            }

            return false;
        }

        public Ski GetNewestSki()
        {
            return this.data.OrderByDescending(s => s.Year).FirstOrDefault();
        }

        public Ski GetSki(string manufacturer, string model)
        {
            return this.data.FirstOrDefault(s => s.Manufacturer == manufacturer && s.Model == model);
        }

        public int Count
        {
            get { return this.data.Count; }
        }

        public string GetStatistics()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"The skis stored in {this.Name}:");
            foreach (var ski in this.data)
            {
                sb.AppendLine(ski.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}