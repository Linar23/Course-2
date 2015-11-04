using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using System.Threading;

namespace Task4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Вычисление возможных вариантов значений функций");
            Console.WriteLine("в зависимости от введенного количества необходимых результатов");

            Console.WriteLine();

            Console.WriteLine("Работает программа №4");
            Console.WriteLine("Разработчик Хуснутдинов Линар Расимович курс 2 группа 09-411");

            Console.WriteLine();

            int N = 0;

            while (true)
            {
                if (IfQuestion("Начать работу программы? да  нетч"))
                {
                    Console.WriteLine();

                    N = takeCount("Сколько раз посчитать функцию?");

                    ProcessStartInfo descend = new ProcessStartInfo(@"Task4_descend.exe")
                    {
                        UseShellExecute = true,
                        CreateNoWindow = true,
                        Arguments = N.ToString()
                    };

                    Process function = Process.Start(descend);

                    Console.WriteLine();
                    Console.WriteLine("Программа открыта в новом окне");
                    Console.WriteLine();

                    FullExit();
                }
                else
                    break;
            }
        }

        static bool IfQuestion(string message)
        {
            Console.WriteLine(message);
            string ans = Console.ReadLine();

            while (ans != "да" && ans != "нет")
            {
                Console.WriteLine("Недопустимый ответ.\n" + message);
                ans = Console.ReadLine();
            }
            if (ans == "да")
                return true;
            if (ans == "нет")
                return false;
            return false;
        }

        static int takeCount(string mess)
        {
            while (true)
            {
                Console.WriteLine(mess);
                try
                {
                    int n = Convert.ToInt32(Console.ReadLine());
                    return n;
                }
                catch
                {
                    Console.WriteLine("Недопустимый ответ");
                }
            }
        }

        static void FullExit()
        {
            Console.WriteLine("Завершить работу программы? да  нет ");
            string s = Console.ReadLine();

            while (s != "да" && s != "нет")
            {
                Console.WriteLine("Недопустимый ответ.\n");
                s = Console.ReadLine();
            }
            if (s == "да")
                Environment.Exit(0);
            if (s == "нет")
                return;
            return;
        }
    }

}
