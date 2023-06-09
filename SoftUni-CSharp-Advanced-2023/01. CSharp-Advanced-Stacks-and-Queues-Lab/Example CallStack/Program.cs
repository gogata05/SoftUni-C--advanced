Console.WriteLine();
SayHello();

Console.WriteLine("Ok");


static void SayHello()
{
    SayHowAreYou();

    Console.WriteLine("In Hello");

    SayHowAreYou();
}

static void SayHowAreYou()
{
    SayYouAreGood();
}

static void SayYouAreGood()
{
    Console.WriteLine("I am good");
}