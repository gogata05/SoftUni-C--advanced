using System;
using System.Collections.Generic;
using System.Text;

namespace TestRenovators
{
    public class Renovator
    {
        //ctor
        public Renovator(string name, string type, double rate, int days)
        {
            this.name = name;
            this.type = type;
            this.rate = rate;
            this.days = days;
        }

        //fields
        private string name;
        private string type;
        private double rate;
        private int days;
        private bool hired;
        //prob
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public string Type
        {
            get { return type; }
            set { type = value; }
        }
        public double Rate
        {
            get { return rate; }
            set { rate = value; }
        }
        public int Days
        {
            get { return days; }
            set { days = value; }
        }
        public bool Hired
        {
            get { return hired; }
            set { hired = value; }
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"-Renovator: {Name}");
            sb.AppendLine($"--Specialty: {Type}");
            sb.AppendLine($"--Rate per day: {Rate} BGN");

            return sb.ToString().Trim();
        }
    }
}
