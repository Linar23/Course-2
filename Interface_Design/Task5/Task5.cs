using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using System.Threading;

namespace Task5
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Макетное представление диалового взаимодействия на основе конструкции");
            Console.WriteLine("k -> k + 1");

            Console.WriteLine();

            Console.WriteLine("Работает программа №5");
            Console.WriteLine("Разработчик Хуснутдинов Линар Расимович курс 2 группа 09-411");

            Console.WriteLine();

            int N = 0;

            while (true)
            {
                if (IfQuestion("Начать работу программы? да  нет "))
                {
                    while (true)
                    {
                        N = takeCount("Сколько раз посчитать функцию?");

                        if (!showScreens(N))
                            Console.WriteLine("Невозможно открыть столько окон на этом мониторе!\n Максимально экранов на этом мониторе может быть " + screensCount().ToString());
                        else
                            break;
                    }
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

        static int screenCount
        {
            Rectangle workingArea = System.Windows.Forms.Screen.PrimaryScreen.WorkingArea;
            int count = workingArea.Width / 300;
            int residue = workingArea.Width - (count * 300);
            int new_w = 300 + (residue / count);
            int count_h = (workingArea.Height / 150) + 1;
            int max_count = count_h * (workingArea.Width / new_w);
            return max_count;
        }

        
        static bool showScreens(int N)
        {
            Rectangle workingArea = System.Windows.Forms.Screen.PrimaryScreen.WorkingArea;
            int count = workingArea.Width / 300;
            int residue = workingArea.Width - (count * 300);
            int new_w = 300 + (residue / count);
            int y = 0;
            

            int count_h = (workingArea.Height / 150)+1;

            int max_count = count_h * (workingArea.Width / new_w);

            if (max_count < N)
                return false;

            int i = 0;
            for (int j = 0; j < N;j++)
            {
                
                ProcessStartInfo descend = new ProcessStartInfo(@"Task4_descend.exe")
                {
                    UseShellExecute = true,
                    CreateNoWindow = true,
                    Arguments = new_w * i + " " + y + " " + new_w + " " + 150
                };
                Process function = Process.Start(descend);

                i++;
                if (i == count)
                {
                    y += 145;
                    i = 0;
                }
                
            }

            return true;
        }
    }  
    }
}
