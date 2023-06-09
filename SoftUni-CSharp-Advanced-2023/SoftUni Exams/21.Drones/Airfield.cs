using System;
using System.Collections.Generic;
using System.Text;
namespace Drones
{
    public class Airfield
    {
        private readonly List<Drone> Drones;
        public string Name { get; private set; }
        public int Capacity { get; private set; }
        public double LandingStrip { get; private set; }

        public Airfield(string name, int capacity, double landingStrip)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.LandingStrip = landingStrip;
            this.Drones = new List<Drone>();
        }

        public int Count => this.Drones.Count;

        public string AddDrone(Drone drone)
        {
            if (string.IsNullOrEmpty(drone.Name) || string.IsNullOrEmpty(drone.Brand) || drone.Range < 5 || drone.Range > 15)
            {
                return "Invalid drone.";
            }

            if (this.Drones.Count >= this.Capacity)
            {
                return "Airfield is full.";
            }

            this.Drones.Add(drone);
            return $"Successfully added {drone.Name} to the airfield.";
        }

        public bool RemoveDrone(string name)
        {
            var drone = this.Drones.Find(d => d.Name == name);
            return drone != null && this.Drones.Remove(drone);
        }

        public int RemoveDroneByBrand(string brand)
        {
            int removedCount = this.Drones.RemoveAll(d => d.Brand == brand);
            return removedCount;
        }

        public Drone FlyDrone(string name)
        {
            var drone = this.Drones.Find(d => d.Name == name);
            if (drone == null)
            {
                return null;
            }
            drone.Fly();
            return drone;
        }

        public List<Drone> FlyDronesByRange(int range)
        {
            List<Drone> flownDrones = this.Drones.FindAll(d => d.Range >= range);
            flownDrones.ForEach(d => d.Fly());
            return flownDrones;
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Drones available at {this.Name}:");

            foreach (var drone in this.Drones)
            {
                if (drone.Available)
                {
                    sb.AppendLine(drone.ToString());
                }
            }
            return sb.ToString();
        }
    }
}
