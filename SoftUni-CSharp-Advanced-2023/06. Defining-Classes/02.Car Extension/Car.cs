﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarManufacturer
{
    public class Car
    {
        private string make;
        private string model;
        private int year;
        private double fuelQuantity;
        private double fuelConsumption;

        public string Make
        {
            get { return make; }
            set { make = value; }
        }

        public string Model
        {
            get { return model; }
            set { model = value; }
        }

        public int Year
        {
            get { return year; }
            set { year = value; }
        }

        public double FuelQuantity  
        {
            get { return fuelQuantity; }
            set { fuelQuantity = value; }
        }
        public double FuelConsumption
        {
            get { return fuelConsumption; }
            set { fuelConsumption = value; }
        }

        public void Drive(double doubleDistance)
        {
            bool canContinue = fuelQuantity - (doubleDistance * fuelConsumption) >= 0;
            if (canContinue)
            {
                FuelQuantity -= doubleDistance * FuelConsumption;
            }
            else
            {
                Console.WriteLine($"Not enough fuel to performance this trip");
            }
        }

        public string WhoAmI()
        {           
           StringBuilder sb = new StringBuilder();
           sb.AppendLine($"Make: {Make}");
           sb.AppendLine($"Model: {Model}");
           sb.AppendLine($"Year: {Year}");
           sb.AppendLine($"Fuel {FuelQuantity:f2}L");
           return sb.ToString();
        }
    }
}