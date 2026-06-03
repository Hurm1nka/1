using System;
namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            const int n = 5;
            const int v = 20;
            int[,] a = new int[v, n];
            int y = 5;
            int x = 0;
            for (int i = 0; i < v; i++)
            {
                for (int z = 0; z < n; z++)
                {
                    a[i, z] = random.Next(1, 6);
                    Console.Write(a[i, z] + " ");
                    if (a[i, z] == y)
                    {
                        x++;
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine(x);
            Console.ReadLine();
        }
    }
}


//При тестировании найдены в следующих строках ошибки:
//1.  int[,] a = new int[n, v];
//2.  for (int i = 1; i <= v; i++)
//    3.a[i, z] = random.Next(1, 5);
//4.  if (a[i, z] = y)
//    5.Console.WriteLine(x);

//Описание ошибок: 
//1.Типичная ошибка при работе с массивами – переставлены строки и столбцы при объявлении массива
//2.	Типичная ошибка при работе с массивами, индекс, начинается с 0
//3.	Неверно указан верхний диапазон для случайных чисел
//4.	Используется нелогическое выражение
//5.	Вывод результата организован внутри тела цикла – неверно закрыта фигурная скобка
