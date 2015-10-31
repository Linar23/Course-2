using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Students
{
    public class Students
    {
        const int N = 4;

        private double averageScore_;
        public string name_;
        private int[] grades_ = new int[N];

        public Students(string name, int subj1, int subj2, int subj3, int subj4)
        {
            name_ = name;
            grades_[0] = subj1;
            grades_[1] = subj2;
            grades_[2] = subj3;
            grades_[3] = subj4;
            averageScore_ = CalcAverageScore();
        }

        public string Name
        {
            get
            {
                return name_;
            }
        }

        public double averageScore
        {
            get
            {
                return averageScore_;
            }
        }

        // Вычисление среднего балла
        public double CalcAverageScore()
        {
            double averageScore = 0;

            for (int i = 0; i < N; i++)
            {
                averageScore = averageScore + grades_[i];
            }
            averageScore = averageScore / N;
            return averageScore;
        }
    }

    class ArrayList
    {
        private Students[] data_;
        private int length_;
        const int arrSize = 100;

        public ArrayList() // Создать
        {
            data_ = new Students[arrSize];
            length_ = -1;
        }

        public void Push(Students value) // Добавить
        {
            if (length_ < arrSize)
            {
                length_++;
                data_[length_] = value;
            }
            else
                Console.WriteLine("Переполнен");
        }

        public Students Look(int m) // Посмотреть
        {
            return data_[m];
        }

        public void Remove(int m) // Удалить
        {
            for (int i = m; i < length_; i++)
                data_[i] = data_[i + 1];
            length_--;
        }

        public Students GetIndex(int m) // Взять по индексу
        {
            for (int i = m; i < length_; i++)
                data_[i] = data_[i + 1];
            length_--;

            return data_[m];
        }

        public void Clear() // Очистить
        {
            length_ = -1;
        }

        public int Size() // Размер
        {
            int result = length_ + 1;
            return result;
        }

        public void Print()
        {
            Console.WriteLine("Student Average Score");
            for (int i = 0; i <= length_; i++)
            {
                Console.WriteLine(i + 1 + ") " + data_[i].name_ + " - " + data_[i].averageScore);
            }
        }

        public void Sort()
        {
            for (int i = 0; i <= length_; i++)
            {
                for (int j = i; j <= length_; j++)
                {
                    if (data_[i].averageScore > data_[j].averageScore)
                    {
                        Students student = data_[i];
                        data_[i] = data_[j];
                        data_[j] = student;
                    }
                }
            }
        }

        class Program
        {
            static void Main(string[] args)
            {

                ArrayList list = new ArrayList();

                list.Push(new Students("Vasya", 1, 1, 3, 3));
                list.Push(new Students("Vanya", 5, 2, 2, 2));
                list.Push(new Students("Roma", 5, 4, 5, 2));
                list.Push(new Students("Max", 5, 2, 2, 2));
                list.Push(new Students("Kolya", 5, 3, 2, 2));
                list.Push(new Students("Vova", 5, 2, 4, 2));
                list.Push(new Students("Petr", 1, 1, 2, 2));
                list.Push(new Students("Alex", 5, 5, 5, 5));

                list.Sort();

                list.Print();

                Console.ReadLine();
            }
        }
    }
}
