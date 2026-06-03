using System;
namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] dogs = {"Hardly any", "More than a handful!", "Woah that's a lot of dogs!",
                               "101 DALMATIONS!!!"};
            string respond;
            int number = 5;
            if (number <= 10)
            {
                respond = dogs[0];
            }
            else if (number <= 50)
            {
                respond = dogs[1];
            }
            else if (number == 101)
            {
                respond = dogs[3];
            }
            else
            {
                respond = dogs[4];
            }
            Console.WriteLine(respond);
        }
    }
}
