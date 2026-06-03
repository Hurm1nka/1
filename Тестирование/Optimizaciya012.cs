using System;
using System.Linq;
namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            //Лучшее решение — использовать итераторов.
            Console.Write("Введите кол-во цифр: ");
            int num = int.Parse(Console.ReadLine());

            Random rnd = new Random();
            int twoAndZero = rnd.Next(num / 2 + 1);
            int onesCount = Math.Max(0, num - twoAndZero * 2);

            string result = Enumerable.Repeat("1", onesCount)
                .Concat(Enumerable.Repeat("0", twoAndZero))
                .Concat(Enumerable.Repeat("2", twoAndZero))
                .OrderBy(x => rnd.Next())
                .Aggregate((x, y) => x + " " + y);

            Console.WriteLine(result);

        }
    }
}

