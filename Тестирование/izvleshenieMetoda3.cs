using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            NewMethod();
            Console.ReadLine();
        }

        private static void NewMethod()
        {
            // Настраиваем консольный интерфейс (CUI)
            Console.Title = "Мое приложение";
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.WriteLine("Привет, это мой проект!");
            Console.BackgroundColor = ConsoleColor.Black;
        }
    }
}
