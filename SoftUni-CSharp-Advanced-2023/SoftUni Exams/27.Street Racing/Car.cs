using System;
using System.Collections.Generic;
using System.Text;
namespace StreetRacing
{
    public class Car
    {
        public string Make { get; }
        public string Model { get; }
        public string LicensePlate { get; }
        public int HorsePower { get; }
        public double Weight { get; }

        public Car(string make, string model, string licensePlate, int horsePower, double weight)
        {
            Make = make;
            Model = model;
            LicensePlate = licensePlate;
            HorsePower = horsePower;
            Weight = weight;
        }

        public override string ToString()
        {
            return $"Make: {Make}\nModel: {Model}\nLicense Plate: {LicensePlate}\nHorse Power: {HorsePower}\nWeight: {Weight}";
        }
    }
}
