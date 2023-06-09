namespace GenericArrayCreator
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            string[] peshos = ArrayCreator.Create(10, "pesho");

            Console.WriteLine(String.Join(" ", peshos));

            int[] ones = ArrayCreator.Create(19, 1);

            Console.WriteLine(String.Join("", ones));

        }
    }
}