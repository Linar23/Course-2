using System;
using System.Collections.Generic;
using System.Linq;

namespace ACMP
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите выражение в инфиксной записи");

            // Входная строка
            string expression = Console.ReadLine();

            // Создание пустого стека для хранения операторов
            Stack<char> operatorStack = new Stack<char>();

            // Создание пустого списка для вывода
            List<char> postfixList = new List<char>();

            // Переменная в которой хранится первый элемент стека 
            char first;

            // Переменная - статус
            int status = 2;

            int i = 0;

            expression = expression + '$';

            // Алгоритм сортировочной станции Дейкстры
            while (status == 2)
            {
                // Получение элемента на вершине стека
                if (operatorStack.Count != 0) first = operatorStack.First();
                else first = '\0';

                // Проверка является ли элемент числом
                if (Char.IsDigit(expression[i]))
                {
                    while (Char.IsDigit(expression[i]))
                    {
                        postfixList.Add(expression[i]);
                        i++;
                        if (i == expression.Length)
                        {
                            i--;
                            break;
                        }
                    }
                    postfixList.Add(' ');
                }

                if (expression[i] == ' ')
                    i++;

                // Если на стрелке + или -
                else if (expression[i] == '+' || expression[i] == '-')
                {
                    if (first == '\0' || first == '(')
                    {
                        operatorStack.Push(expression[i]);
                        i++;
                    }

                    else if (first == '+' || first == '-' || first == '*' || first == '/')
                    {
                        postfixList.Add(operatorStack.Pop());
                        postfixList.Add(' ');
                    }
                }

                // Если на стрелке * или /
                else if (expression[i] == '*' || expression[i] == '/')
                {
                    if (first == '\0' || first == '(' || first == '+' || first == '-')
                    {
                        operatorStack.Push(expression[i]);
                        i++;
                    }
                    else if (first == '*' || first == '/')
                    {
                        postfixList.Add(operatorStack.Pop());
                        postfixList.Add(' ');
                    }
                }

                // Если на стрелке открывающая скобка, то добавляем её в стек
                else if (expression[i] == '(')
                {
                    operatorStack.Push(expression[i]);
                    i++;
                }

                // Если на стрелке закрывающая скобка
                else if (expression[i] == ')')
                {
                    // Если на стрелке закрывающая скобка, а в стеке нет элементов - изменяем стутус на 0 - ошибка
                    if (first == '\0') status = 0;
                    else if (first == '+' || first == '-' || first == '*' || first == '/')
                    {
                        postfixList.Add(operatorStack.Pop());
                        postfixList.Add(' ');
                    }
                    else if (first == '(')
                    {
                        operatorStack.Pop();
                        i++;
                    }
                }

                // Если последний элемент
                else if (expression[i] == '$')
                {
                    if (first == '\0') status = 1;
                    else if (first == '+' || first == '-' || first == '*' || first == '/')
                    {
                        postfixList.Add(operatorStack.Pop());
                        postfixList.Add(' ');
                    }
                    else if (first == '(') status = 0; // Если на стрелке последний вагон, а в стеке есть открывающая скобка - ошибка
                }
                else status = 0; // Неизвестный символ
                }

                i = 0;

            Console.WriteLine();

            while (i < postfixList.Count)
            {
                Console.Write(postfixList[i]);
                i++;
            }

            Console.WriteLine();
            Console.WriteLine();

            // Стек для хранения чисел
            Stack<int> stackDigit = new Stack<int>();

            int var1, var2 = 0;

            // Вычисление выражения по постфиксной записи
            for (i = 0; i < postfixList.Count; i++)
            {
                if (Char.IsDigit(postfixList[i])) stackDigit.Push((int)Char.GetNumericValue(postfixList[i]));
                else if (postfixList[i] == '+') stackDigit.Push(stackDigit.Pop() + stackDigit.Pop());
                else if (postfixList[i] == '-')
                {
                    var2 = stackDigit.Pop();
                    var1 = stackDigit.Pop();
                    stackDigit.Push(var1 - var2);
                }
                else if (postfixList[i] == '*') stackDigit.Push(stackDigit.Pop() * stackDigit.Pop());
                else if (postfixList[i] == '/')
                {
                    var2 = stackDigit.Pop();
                    var1 = stackDigit.Pop();
                    stackDigit.Push(var1 / var2);
                }
            }

            Console.WriteLine(stackDigit.Pop());

            Console.ReadLine();
            }
        }
    }
