using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expression
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Работает программа №1");
            Console.WriteLine("Задача вычислить значение выражения y = e^(x - a) + 1");
            Console.WriteLine("Разработчик Хуснутдинов Линар Расимович курс 2 группа 09-411");

            while (true)
            {
                Console.WriteLine("Начинаем работу да  нет ?");
                if (Console.ReadLine() == "нет")
                    break;

                Console.WriteLine("Формула y = e^(x - a) + 1");
                double x, a;
                while (true)
                {
                    try
                    {
                        Console.WriteLine("Введите значение x");
                        x = Convert.ToDouble(Console.ReadLine());

                        Console.WriteLine("Введите значение a");
                        a = Convert.ToDouble(Console.ReadLine());
                    }

                    catch(FormatException) // Проверка на корректность ввода данных
                    {
                        Console.WriteLine("Ввод некорректный");
                        continue;
                    }

                    break;
                    
                }

                Console.WriteLine(Math.Pow(Math.E, x - a) + 1);

                Console.WriteLine("Завершаем работу? да  нет ");
                if (Console.ReadLine() == "да")
                    break;
           }
            Console.WriteLine("Работа программы №1 завершена.");
            Console.ReadLine();
            
        }
    }
}
