using System;
using System.Collections.Generic;
using System.Text;
namespace StreetRacing
{
    public class Race
    {
        private readonly List<Car> Participants;
        public string Name { get; }
        public string Type { get; }
        public int Laps { get; }
        public int Capacity { get; }
        public int MaxHorsePower { get; }
        public int Count { get { return Participants.Count; } }

        public Race(string name, string type, int laps, int capacity, int maxHorsePower)
        {
            Name = name;
            Type = type;
            Laps = laps;
            Capacity = capacity;
            MaxHorsePower = maxHorsePower;
            Participants = new List<Car>();
        }

        public bool Add(Car car)
        {
            if (!Participants.Exists(c => c.LicensePlate == car.LicensePlate) && Participants.Count < Capacity && car.HorsePower <= MaxHorsePower)
            {
                Participants.Add(car);
                return true;
            }
            return false;
        }

        public bool Remove(string licensePlate)
        {
            Car car = Participants.Find(c => c.LicensePlate == licensePlate);
            if (car != null)
            {
                Participants.Remove(car);
                return true;
            }
            return false;
        }

        public Car FindParticipant(string licensePlate)
        {
            return Participants.Find(c => c.LicensePlate == licensePlate);
        }

        public Car GetMostPowerfulCar()
        {
            if (Participants.Count == 0)
            {
                return null;
            }
            Car maxPowerCar = Participants[0];
            foreach (Car car in Participants)
            {
                if (car.HorsePower > maxPowerCar.HorsePower)
                {
                    maxPowerCar = car;
                }
            }
            return maxPowerCar;
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"Race: {Name} - Type: {Type} (Laps: {Laps})\n");
            foreach (Car car in Participants)
            {
                sb.Append(car.ToString() + "\n");
            }
            return sb.ToString();
        }
    }
}
