using System;
using System.Collections.Generic;
using System.Text;
namespace Drones
{
    public class Drone
    {
        public string Name { get; private set; }
        public string Brand { get; private set; }
        public int Range { get; private set; }
        public bool Available { get; private set; }

        public Drone(string name, string brand, int range)
        {
            this.Name = name;
            this.Brand = brand;
            this.Range = range;
            this.Available = true;
        }

        public void Fly()
        {
            this.Available = false;
        }

        public override string ToString()
        {
            return $"Drone: {this.Name}\nManufactured by: {this.Brand}\nRange: {this.Range} kilometers";
        }
    }

}
