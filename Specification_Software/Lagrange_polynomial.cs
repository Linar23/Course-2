using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lagrange_polynomial
{
    class Polynomial
    {
        // Поля
        private double[] coefficient_;

        // Конструктор
        public Polynomial(params double[] coefficient)
        {
            this.coefficient_ = coefficient;
        }

        // Свойства
        public double this[int n]
        {
            get
            {
                return coefficient_[n];
            }
            set
            {
                coefficient_[n] = value;
            }
        }

        // Вычисление полинома
        public double Calc(double x)
        {
            int n = coefficient_.Length - 1;
            double result = coefficient_[n];
            for (int i = n - 1; i >= 0; i--)
            {
                result = x * result + coefficient_[i];
            }
            return result;
        }

        public static Polynomial operator +(Polynomial pFirst, Polynomial pSecond)
        {
            int itemsCount = Math.Max(pFirst.coefficient_.Length, pSecond.coefficient_.Length);
            var result = new double[itemsCount];

            for (int i = 0; i < itemsCount; i++)
            {
                double a = 0;
                double b = 0;
                if (i < pFirst.coefficient_.Length)
                {
                    a = pFirst[i];
                }
                if (i < pSecond.coefficient_.Length)
                {
                    b = pSecond[i];
                }
                result[i] = a + b;
            }
            return new Polynomial(result);
        }

        public static Polynomial operator -(Polynomial pFirst, Polynomial pSecond)
        {
            int itemsCount = Math.Max(pFirst.coefficient_.Length, pSecond.coefficient_.Length);
            var result = new double[itemsCount];
            for (int i = 0; i < itemsCount; i++)
            {
                double a = 0;
                double b = 0;
                if (i < pFirst.coefficient_.Length)
                {
                    a = pFirst[i];
                }
                if (i < pSecond.coefficient_.Length)
                {
                    b = pSecond[i];
                }
                result[i] = a - b;
            }
            return new Polynomial(result);
        }

        public static Polynomial operator *(Polynomial pFirst, Polynomial pSecond)
        {
            int itemsCount = pFirst.coefficient_.Length + pSecond.coefficient_.Length - 1;
            var result = new double[itemsCount];

            for (int i = 0; i < pFirst.coefficient_.Length; i++)
                for (int j = 0; j < pSecond.coefficient_.Length; j++)
                {
                    result[i + j] = pFirst[i] * pSecond[j] + result[i + j];
                }
            return new Polynomial(result);
        }

        public static Polynomial operator /(Polynomial pFirst, double nSecond)
        {
            int itemsCount = pFirst.coefficient_.Length;
            var result = new double[itemsCount];
            for (int i = 0; i < pFirst.coefficient_.Length; i++)
            {
                result[i] = pFirst[i] / nSecond;
            }
            return new Polynomial(result);
        }

        public void Print()
        {
            int itemsCount = coefficient_.Length;
            for (int i = 0; i < itemsCount; i++)
            {
                if (coefficient_[i] >= 0) Console.Write(coefficient_[i] + "*x^" + i);
                else Console.Write("(" + coefficient_[i] + ")" + "*x^" + i);
                if (i != (itemsCount-1)) Console.Write(" + ");
            }
            Console.WriteLine();
        }
    }
    
    class Lagrange_polynomial
    {
        // Поля
        private double[] Nodes;

        // Конструктор
        public Lagrange_polynomial(params double[] Nodes)
        {
            this.Nodes = Nodes;
        }

        // Вычисление базисных полиномов
        public Polynomial[] PolynomialBasis(params double[] Nodes)
        {
            // Знаменатели базисных полиномов
            var denominator = new double[Nodes.Length];

            for (int i = 0;i < Nodes.Length;i++)
            {
                denominator[i] = 1;
            }

            // Числители базисных полиномов - многочлены
            Polynomial[] numerator = new Polynomial[Nodes.Length];

            // Промежуточный полином равный 1 необходимый для начального умножения
            Polynomial interNumerator = new Polynomial(1);

            // Базисные полиномы
            Polynomial[] PolynomialBasis = new Polynomial[Nodes.Length];

            // Вычисление базисных полиномов
            for (int l = 0; l < Nodes.Length; l++)
            for (int i = 0; i < Nodes.Length; i++)
            {
                    if ((l == (Nodes.Length-1)) & (i == (Nodes.Length - 1)))
                    {
                        break;
                    }

                if (l == i)
                {
                    denominator[l] = denominator[l] * (Nodes[l] - Nodes[i + 1]);
                    i++;
                        if (l == 0)
                        { numerator[l] = new Polynomial(-Nodes[i], 1); }
                        else
                        {
                            interNumerator = new Polynomial(-Nodes[i], 1);
                            numerator[l] = numerator[l] * interNumerator;
                        }
                }
                else
                {
                    denominator[l] = denominator[l] * (Nodes[l] - Nodes[i]);
                    if (i == 0)
                        { numerator[l] = new Polynomial(-Nodes[i], 1); }
                        else
                        {
                            interNumerator = new Polynomial(-Nodes[i], 1);
                            numerator[l] = numerator[l] * interNumerator;
                        }
                    }
            }

            // Вычисление базисного полинома по числителю и знаменателю
            for (int i = 0; i < Nodes.Length; i++)
            {
                PolynomialBasis[i] = numerator[i] / denominator[i];
            }

            return PolynomialBasis;
        }

        public void CalcLagrange(Polynomial[] PolynomialBasis)
        {
            Polynomial lagrangePolynomial = new Polynomial(1);

            for (int i = 0; i < Nodes.Length; i++)
            {
                Polynomial interFunction = new Polynomial(Math.Tan(Nodes[i]));

                if (i == 0)
                {

                    lagrangePolynomial = lagrangePolynomial * PolynomialBasis[i];
                    lagrangePolynomial = lagrangePolynomial * interFunction;
                }
                else
                {
                    lagrangePolynomial = lagrangePolynomial + (PolynomialBasis[i] * interFunction);
                } 
            }

            lagrangePolynomial.Print();
        } 
    }

    class Program
    {
        static void Main(string[] args)
        {
            Lagrange_polynomial test = new Lagrange_polynomial(-1.5, -0.75, 0, 0.75, 1.5);

            test.CalcLagrange(test.PolynomialBasis(-1.5, -0.75, 0, 0.75, 1.5));

            Console.ReadLine();
        }
    }
}
