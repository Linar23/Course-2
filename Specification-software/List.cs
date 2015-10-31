using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace List
{
    class ArrayList
    {
        private int[] arrList;
        private int length_;
        private const int arrSize = 100;

        public ArrayList() // Создать
        {
            arrList = new int[arrSize];
            length_ = -1;
        }

        public void Push(int arg) // Добавить
        {
            if (length_ < arrSize)
            {
                length_++;
                arrList[length_] = arg;
            }
            else
                Console.WriteLine("Переполнен");
        }

        public int Look(int arg) // Посмотреть
        {
            int result = arrList[arg];
            return result;
        }

        public void Remove(int arg) // Удалить
        {
            for (int i = arg; i < length_; i++)
                arrList[i] = arrList[i + 1];
            length_--;
        }

        public int GetIndex(int arg) // Взять по индексу
        {
            for (int i = arg; i < length_; i++)
                arrList[i] = arrList[i + 1];
            length_--;

            return arrList[arg];
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

    }

    class Program
    {
        static void Main(string[] args)
        {

        }
    }
}
