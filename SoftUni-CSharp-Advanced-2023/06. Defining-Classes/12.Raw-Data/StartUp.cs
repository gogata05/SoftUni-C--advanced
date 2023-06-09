using System;
using System.Collections.Generic;
using System.Linq;
namespace RawData;
public class Startup
{
    static void Main(string[] args)
    {
        List<Car> listCars = new();
        int n = int.Parse(Console.ReadLine());
        for (int i = 0; i < n; i++)
        {
            string[] inputArray = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            Car car = new(
                inputArray[0],
                int.Parse(inputArray[1]),
                int.Parse(inputArray[2]),
                int.Parse(inputArray[3]),
                inputArray[4],
                double.Parse(inputArray[5]),
                int.Parse(inputArray[6]),
                double.Parse(inputArray[7]),
                int.Parse(inputArray[8]),
                double.Parse(inputArray[9]),
                int.Parse(inputArray[10]),
                double.Parse(inputArray[11]),
                int.Parse(inputArray[12])
            );
            listCars.Add(car);
        }
        string command = Console.ReadLine();
        string[] filteredListCars;
        if (command == "fragile")
        {
            filteredListCars = listCars
                .Where(c => c.Cargo.Type == "fragile" && c.Tyres.Any(t => t.Pressure < 1))
                .Select(c => c.Model).ToArray();
        }
        else
        {
            filteredListCars = listCars
                .Where(c => c.Cargo.Type == "flammable" && c.Engine.Power > 250)
                .Select(c => c.Model).ToArray();
        }
        Console.WriteLine(string.Join(Environment.NewLine, filteredListCars));
    }
}