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
            Console.WriteLine("Схема последовательная интерпретация элементов");

            Console.WriteLine("Работает программа №2");
            Console.WriteLine("Разработчик Хуснутдинов Линар Расимович курс 2 группа 09-411");

            Console.WriteLine();

            while (true)
            {
            Start:
                // Переменная для считывания
                string s;

                Console.WriteLine();

                Console.WriteLine("Начинаем работу? да  нет ");
                s = Console.ReadLine();
                if (s == "нет")
                    goto EndProgram;
                else if (s == "да")
                {
                    Console.WriteLine();

                    Console.WriteLine("Выполняется функция №1");

                    // Функция №1
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

                        catch (FormatException) // Проверка на корректность ввода данных
                        {
                            Console.WriteLine("Ввод некорректный");
                            continue;
                        }

                        break;

                    }

                    Console.WriteLine(Math.Pow(Math.E, x - a) + 1);
                }
                else
                {
                    goto Start;
                }

                Console.WriteLine();

            Function2:
                Console.WriteLine("Выполнять следующую? да  нет ");
            s = Console.ReadLine();
                if (s == "нет")
                    goto EndProgram;

                else if (s == "да")
                {
                    Console.WriteLine();

                    Console.WriteLine("Выполняется функция №2");

                    // Функция №2
                    Console.WriteLine("Формула y = sqrt(abs(a))/(1 + e^x)");
                    double x1, a1;
                    while (true)
                    {
                        try
                        {
                            Console.WriteLine("Введите значение x");
                            x1 = Convert.ToDouble(Console.ReadLine());

                            Console.WriteLine("Введите значение a");
                            a1 = Convert.ToDouble(Console.ReadLine());
                        }

                        catch (FormatException) // Проверка на корректность ввода данных
                        {
                            Console.WriteLine("Ввод некорректный");
                            continue;
                        }

                        break;

                    }

                    Console.WriteLine((Math.Sqrt(Math.Abs(a1))) / (1 + Math.Exp(x1)));
                }
                else
                {
                    Console.WriteLine("Некорректные данные");
                    goto Function2;
                }

            Function3:
                Console.WriteLine();

                Console.WriteLine("Выполнять следующую? да  нет ");
                s = Console.ReadLine();
                if (s == "нет")
                    goto EndProgram;

                else if (s == "да")
                {
                    Console.WriteLine();

                    Console.WriteLine("Выполняется функция №3");

                    // Функция №3
                    Console.WriteLine("Формула y = cos(x)/(sqrt(a) + e^x)");
                    double x3, a3;
                    while (true)
                    {
                        try
                        {
                            Console.WriteLine("Введите значение x");
                            x3 = Convert.ToDouble(Console.ReadLine());

                            Console.WriteLine("Введите значение a");
                            a3 = Convert.ToDouble(Console.ReadLine());
                        }

                        catch (FormatException) // Проверка на корректность ввода данных
                        {
                            Console.WriteLine("Ввод некорректный");
                            continue;
                        }

                        break;

                    }

                    Console.WriteLine(Math.Cos(x3) / (Math.Sqrt(a3) + Math.Pow(Math.E, x3)));
                }
                else
                {
                    Console.WriteLine("Некорректные данные");
                    goto Function3;
                }

                Console.WriteLine();

            Function4:
                Console.WriteLine("Выполнять следующую? да  нет ");
                s = Console.ReadLine();
                if (s == "нет")
                    goto EndProgram;

                else if (s == "да")
                {

                    Console.WriteLine();

                    Console.WriteLine("Выполняется функция №4");

                    // Функция №4
                    Console.WriteLine("Формула y = sin ( x ^ 2 ) / ln| a + x |");
                    double x4, a4;
                    while (true)
                    {
                        try
                        {
                            Console.WriteLine("Введите значение x");
                            x4 = Convert.ToDouble(Console.ReadLine());

                            Console.WriteLine("Введите значение a");
                            a4 = Convert.ToDouble(Console.ReadLine());
                        }

                        catch (FormatException) // Проверка на корректность ввода данных
                        {
                            Console.WriteLine("Ввод некорректный");
                            continue;
                        }

                        break;

                    }

                    Console.WriteLine(Math.Sin(x4 * x4) / Math.Log(Math.Abs(a4 + x4)));
                }
                else
                {
                    Console.WriteLine("Некорректные данные");
                    goto Function4;
                }

            EndProgram:
                Console.WriteLine("Завершаем работу? да  нет ");
                s = Console.ReadLine();
                if (s == "да")
                    break;
                else if (s == "нет")
                    goto Start;

                Console.WriteLine();
            }

            Console.WriteLine("Работа программы №2 завершена.");
            Console.ReadLine();

        }
    }
}
