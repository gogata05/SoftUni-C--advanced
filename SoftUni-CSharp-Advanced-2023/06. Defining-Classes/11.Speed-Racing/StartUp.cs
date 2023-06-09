using System;
using System.Collections.Generic;
using System.Reflection;
namespace SpeedRacing;
public class Startup
{
    static void Main(string[] args)
    {
        Dictionary<string, Car> dictCarNames = new(){};
        int n = int.Parse(Console.ReadLine());
        for (int i = 0; i < n; i++)
        {
            string[] inputArray = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            Car car = new() { Model = inputArray[0], FuelTotal = double.Parse(inputArray[1]), FuelConsumption1Km = double.Parse(inputArray[2]) };
            dictCarNames.Add(car.Model, car);
        }
        while (true)
        {
            string command = Console.ReadLine();
            if (command == "End") { break; }
            string[] commandArray = command.Split(" ", StringSplitOptions.RemoveEmptyEntries); //drive = [0];
            string carModel = commandArray[1];//"BMW-M2"
            double toDrive = double.Parse(commandArray[2]);//"56"
            
            Car car = dictCarNames[carModel];
            car.Drive(toDrive);
        }
        foreach (var car in dictCarNames.Values)
        {
            Console.WriteLine($"{car.Model} {car.FuelTotal:f2} {car.DistanceTotal}");
        }
    }
}