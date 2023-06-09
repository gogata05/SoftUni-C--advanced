namespace CarManufacturer
{
    public class StartUp
    {
        static void Main()
        {
            List<Tire> tires = new List<Tire>();
            List<Engine> engines = new List<Engine>();
            List<Car> cars = new List<Car>();

            string input;
            while ((input = Console.ReadLine()) != "No more tires")
            {
                string[] tireData = input.Split();
                for (int i = 0; i < tireData.Length; i += 2)
                {
                    int year = int.Parse(tireData[i]);
                    double pressure = double.Parse(tireData[i + 1]);
                    tires.Add(new Tire(year, pressure));
                }
            }

            while ((input = Console.ReadLine()) != "Engines done")
            {
                string[] engineData = input.Split();
                for (int i = 0; i < engineData.Length; i += 2)
                {
                    int horsePower = int.Parse(engineData[i]);
                    double cubicCapacity = double.Parse(engineData[i + 1]);
                    engines.Add(new Engine(horsePower, cubicCapacity));
                }
            }

            while ((input = Console.ReadLine()) != "Show special")
            {
                string[] carData = input.Split();
                string make = carData[0];
                string model = carData[1];
                int year = int.Parse(carData[2]);
                double fuelQuantity = double.Parse(carData[3]);
                double fuelConsumption = double.Parse(carData[4]);
                int engineIndex = int.Parse(carData[5]);
                int tiresIndex = int.Parse(carData[6]);

                Car car = new Car(make, model, year, fuelQuantity, fuelConsumption, engines[engineIndex], tires.Skip(4 * tiresIndex).Take(4).ToArray());
                cars.Add(car);
            }

            foreach (Car car in cars)
            {
                if (car.Year >= 2017 && car.Engine.HorsePower > 330 && car.Tires.Sum(t => t.Pressure) > 9 && car.Tires.Sum(t => t.Pressure) < 10)
                {
                    car.Drive(20);
                    Console.WriteLine($"Make: {car.Make}");
                    Console.WriteLine($"Model: {car.Model}");
                    Console.WriteLine($"Year: {car.Year}");
                    Console.WriteLine($"HorsePowers: {car.Engine.HorsePower}");
                    Console.WriteLine($"FuelQuantity: {car.FuelQuantity:f2}");
                }
            }
        }
    }
}
