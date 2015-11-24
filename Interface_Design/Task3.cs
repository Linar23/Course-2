using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3_PHMI
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Схема типа if then else");

            Console.WriteLine("Работает программа №3");
            Console.WriteLine("Разработчик Хуснутдинов Линар Расимович курс 2 группа 09-411");

        Start:
            // Переменная ввода
            string s;

            Console.WriteLine();

            Console.WriteLine("Начинаем работу? да  нет ");
            s = Console.ReadLine();
            if (s == "нет")
                goto EndProgram;

            while (true)
            {
                Console.WriteLine();

                Console.WriteLine("Какую группу из представленных выполнять");
                Console.WriteLine("1 Формула y = e^(x - a) + 1");
                Console.WriteLine("2 Формула y = sqrt(abs(a))/(1 + e^x)");

                Console.WriteLine();

                try
                {
                    int groups = Convert.ToInt32(Console.ReadLine());

                    switch (groups)
                    {
                        case 1:
                            goto Group1;
                        case 2:
                            goto Group2;
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Некорректный ввод");
                    continue;
                }
            }

        Group1:
            Console.WriteLine();

            Console.WriteLine("Выполнять группу функций №1 да нет ?");
            s = Console.ReadLine();
            if (s == "нет")
                goto EndProgram;
            else if (s == "да")
            {
                Console.WriteLine();

                Console.WriteLine("Выполняется функция №1");

                // Функция №1 
                Console.WriteLine("Формула y = e^(x - a) + 1");

                Console.WriteLine();

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

                    catch (FormatException) // Проверка на корректность ввода данных 
                    {
                        Console.WriteLine("Ввод некорректный");
                        continue;
                    }
                    break;
                }

                Console.WriteLine();

                Console.WriteLine(Math.Pow(Math.E, x - a) + 1);

                goto EndProgram;
            }

        Group2:
            Console.WriteLine();

            Console.WriteLine("Выполнять группу функций №2 да нет ?");
            s = Console.ReadLine();
            if (s == "нет")
                goto EndProgram;
            else if (s == "да")
            {
                Console.WriteLine();

                Console.WriteLine("Выполняется функция №2");

                // Функция №2 
                Console.WriteLine("Формула y = sin(x)/(cos^2(x) + a))");

                Console.WriteLine();

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

                    catch (FormatException) // Проверка на корректность ввода данных 
                    {
                        Console.WriteLine("Ввод некорректный");
                        continue;
                    }

                    break;
                }
                Console.WriteLine(Math.Abs(Math.Pow(Math.Cos(x), 2) + a) < 0.0000000000000001);

                goto EndProgram;
            }

            goto EndProgram;

        EndProgram:
            Console.WriteLine();

            Console.WriteLine("Завершаем работу? да  нет ");
            s = Console.ReadLine();

            if (s == "нет")
                goto Start;
            else if (s != "да")
                goto EndProgram;

            Console.WriteLine();
        
            Console.WriteLine("Работа программы №2 завершена");
            Console.ReadLine();
        }
    }
}
