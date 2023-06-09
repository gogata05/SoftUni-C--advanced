using System;
namespace Parking
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            // Initialize the repository
            Parking parking = new Parking("Underground parking garage", 5);//string type, int capacity

            // Initialize entity
            Car volvo = new Car("Volvo", "XC70", 2010);//string manufacturer, string model, int year

            // Print Car
            Console.WriteLine(volvo); // Volvo XC70 (2010)

            // Add Car
            parking.Add(volvo);

            // Remove Car
            Console.WriteLine(parking.Remove("Volvo", "XC90")); // False
            Console.WriteLine(parking.Remove("Volvo", "XC70")); // True

            Car peugeot = new Car("Peugeot", "307", 2011);//string manufacturer, string model, int year
            Car audi = new Car("Audi", "S4", 2005);//string manufacturer, string model, int year

            parking.Add(peugeot);
            parking.Add(audi);

            // Get Latest Car
            Car latestCar = parking.GetLatestCar();//Car
            Console.WriteLine(latestCar); // Peugeot 307 (2011)

            // Get Car
            Car audiS4 = parking.GetCar("Audi", "S4");//string manufacturer, string model
            Console.WriteLine(audiS4); // Audi S4 (2005)

            // Count
            Console.WriteLine(parking.Count); // 2

            // Get Statistics
            Console.WriteLine(parking.GetStatistics());//Parking parking
            // The cars are parked in Underground parking garage:
            // Peugeot 307(2011)
            // Audi S4(2005)
        }
    }
}
