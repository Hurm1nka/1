using System;
using System.Linq;
namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
                Console.Write("Введите кол-во цифр: ");
        int num = int.Parse(Console.ReadLine());

        int rnd = new Random();
        int twoAndZero = rnd.Next(num/2+1); 
        int onesCount = Math.Max(0, num - twoAndZero * 2);

        int result = Enumerable.Repeat("1", onesCount)
            .Concat(Enumerable.Repeat("0", twoAndZero))
            .Concat(Enumerable.Repeat("2", twoAndZero))
            .OrderBy(x => rnd.Next())
            .Aggregate((x, y) => x + " " + y);

        Console.WriteLine(result);
// Также возможен такой вариант: 
while (true)
        {
            Console.Write("Введите кол-во цифр: ");
            int num = int.Parse(Console.ReadLine());

            // можно и 3 только вот чтоб было обязательно один 1 и вариант ниже в 
            // комбинации
            // можно и 2 только чтоб было либо 0,2 либо 2,0
            // либо 1,1
            // и вариант только 1
            if (num < 0)
            {
                Console.WriteLine("Введите положительное число!!!!!");
                continue;
            }

            Random rnd = new Random();
            int diff = 0;
            
            int count = num;
            while (count > 0)
            {
                int s = rnd.Next(0, 3 + 1);
                if (s == 0 && (count - Math.Abs(diff + 1)) > 0)
                {
                    Console.Write(0 + " ");
                    diff++;
                    count--;
                }
                if (s == 1 && (count - Math.Abs(diff)) > 0)
                {
                    Console.Write(1 + " ");
                    count--;
                }
                if (s == 2 && (count - Math.Abs(diff - 1)) > 0)
                {
                    Console.Write(2 + " ");
                    diff--;
                    count--;
                }
            }
            Console.WriteLine();
        }


        }
    }
}

