namespace DefiningClasses
{
    public class StartUp
    {
        static void Main()
        {
            Person peter = new();
            peter.Name = "Peter";
            peter.Age = 20;

            Person george = new()
            {
                Name = "George",
                Age = 18
            };

            Person noNameDefaultAge = new();
            Person noNameWithAge = new(25);
            Person john = new("John", 32);

            Console.WriteLine($"{peter.Name} is {peter.Age} years old");//Peter is 20 years old
            Console.WriteLine($"{george.Name} is {george.Age} years old");//George is 18 years old



            Console.WriteLine($"{noNameDefaultAge.Name} is {noNameDefaultAge.Age} years old");//No name is 1 years old

            Console.WriteLine($"{noNameWithAge.Name} is {noNameWithAge.Age} years old"); //No name is 25 years old

            Console.WriteLine($"{john.Name} is {john.Age} years old"); //John is 32 years old


        }
    }
}