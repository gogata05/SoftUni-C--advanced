using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeedRacing;

public class Car
{
    private string model;
    private double fuelTotal;
    private double fuelConsumption1Km;
    private double distanceTotal;

    public string Model { get { return model; } set { model = value; } }

    public double FuelTotal { get { return fuelTotal; } set { fuelTotal = value; } }

    public double FuelConsumption1Km { get { return fuelConsumption1Km; } set { fuelConsumption1Km = value; } }

    public double DistanceTotal { get { return distanceTotal; } set { distanceTotal = value; } }

    public void Drive(double toDrive)
    {
        if (toDrive * fuelConsumption1Km > fuelTotal)
        {
            Console.WriteLine("Insufficient fuel for the drive");
        }
        else
        {
            FuelTotal -= toDrive * fuelConsumption1Km;
            DistanceTotal += toDrive;
        }
    }
}