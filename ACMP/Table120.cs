using System;
using System.Collections.Generic;
using System.Linq;

namespace ACMP
{
    class Program
    {
        static void Main(string[] args)
        {
            int N, M = 0;

            string[] temp = Console.ReadLine().Split(' ');
            N = int.Parse(temp[0]);
            M = int.Parse(temp[1]);

            int[,] TableA = new int[N, M];
            int[,] TableB = new int[N, M];

            for (int i = 0; i < N; i++)
            {
                string[] tempTable = Console.ReadLine().Split(' ');
                for (int j = 0; j < M; j++)
                {
                    TableA[i, j] = int.Parse(tempTable[j]);
                }
            }

            int K = 0;

            // Алгоритм Дейкстры
            for (int i = 0; i < N; i++)
                for (int j = 0; j < M; j++)
                    if (i == 0 & j == 0)
                    {
                        TableB[i, j] = TableA[i, j];
                    }
                    else if (i == 0) TableB[i, j] = TableA[i, j] + TableB[i, j - 1];
                    else if (j == 0) TableB[i, j] = TableA[i, j] + TableB[i - 1, j];
                    else
                    {
                        K = Math.Min(TableB[i - 1, j], TableB[i, j - 1]) + TableA[i, j];
                        TableB[i, j] = K;
                    }

            Console.WriteLine(TableB[N - 1, M - 1]);
            Console.ReadLine();
        }
    }
}
