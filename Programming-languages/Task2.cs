using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите выражение в инфиксной записи");
            
            string expression = Console.ReadLine();

            // Создание пустого стека для хранения операторов
            Stack <char> opstack = new Stack<char>();

            // Создание пустого списка для вывода
            List<char> postfixList = new List<char>();

            List<char> tokenList = new List<char>();

            // Преобразование инфиксной строки в список
            for (int i = 0; i <= expression.Length; i++)
            {
                tokenList.Add(expression[i]);
            }

            // Сканирование списка
            for (int i = 0; i <= tokenList.Count; i++)
            {
                if (tokenList[i] == 'a')
                {

                }
            }
        }
    }
}
