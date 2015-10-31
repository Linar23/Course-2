using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace arrayList
{
    class Person
    {
        public string name_;
        public int age_;

        public Person()
        {
            name_ = null;
            age_ = 0;
        }

        public Person(string name, int age)
        {
            this.name_ = name;
            this.age_ = age;
        }
    }

    class ArrayList
    {
        private Person[] data_;
        private int length_;
        const int arrSize = 100;

        public ArrayList() // Создать
        {
            data_ = new Person[arrSize];
            length_ = -1;
        }

        public void Push(Person value) // Добавить
        {
            if (length_ < arrSize)
            {
                length_++;
                data_[length_] = value;
            }
            else
                Console.WriteLine("Переполнен");
        }

        public Person Look(int m) // Посмотреть
        {
            return data_[m];
        }

        public void Remove(int m) // Удалить
        {
            for (int i = m; i < length_; i++)
                data_[i] = data_[i + 1];
            length_--;
        }

        public Person GetIndex(int m) // Взять по индексу
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
            Console.WriteLine("Person Age");
            for (int i = 0; i <= length_; i++)
            {
                Console.WriteLine(i + 1 + ") " + data_[i].name_ + " - " + data_[i].age_);
            }
        }

        // Сортировка за линейное время
        public void Sort()
        {
            int maxValue = 0;
            int minValue = 0;

            for (int i = 0; i < (length_ + 1); i++)
            {
                if (data_[i].age_ > maxValue)
                    maxValue = data_[i].age_;

                if (data_[i].age_ < minValue)
                    minValue = data_[i].age_;
            }

            List<int>[] bucket = new List<int>[maxValue - minValue + 1];
            List<string>[] bucketName = new List<string>[maxValue - minValue + 1];

            for (int i = 0; i < bucket.Length; i++)
            {
                bucket[i] = new List<int>();
                bucketName[i] = new List<string>();
            }

            for (int i = 0; i < (length_ + 1); i++)
            {
                bucket[data_[i].age_ - minValue].Add(data_[i].age_);
                bucketName[data_[i].age_ - minValue].Add(data_[i].name_);
            }

            int position = 0;

            for (int i = 0; i < bucket.Length; i++)
            {
                if (bucket[i].Count > 0)
                {
                    for (int j = 0; j < bucket[i].Count; j++)
                    {
                        data_[position].age_ = bucket[i][j];
                        data_[position].name_ = bucketName[i][j];
                        position++;
                    }
                }
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            ArrayList array = new ArrayList();

            Person person1 = new Person("Jack", 32);
            Person person2 = new Person("Kate", 27);
            Person person3 = new Person("Lock", 55);
            Person person4 = new Person("Hugo", 26);

            array.Push(person1);
            array.Push(person2);
            array.Push(person3);
            array.Push(person4);

            array.Print();

            array.Sort();
            Console.WriteLine();

            array.Print();

            Console.ReadLine();
        }
    }
}
