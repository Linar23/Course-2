using System;

namespace Shape
{
    abstract class Shape
    {
        public abstract double Area();
    }

    class Triangle : Shape
    {
        private double _a;
        private double _b;
        private double _c;

        public Triangle(double a, double b, double c)
        {
            this._a = a;
            this._b = b;
            this._c = c;
        }
        public override double Area()
        {
            double s = (this._a + this._b + this._c) / 2;

            return Math.Sqrt((s - this._a) * (s - this._b) * (s - this._a) * s);
        }
    }

    class Rectangle : Shape
    {
        private double _a;
        private double _b;

        public Rectangle(double a, double b)
        {
            this._a = a;
            this._b = b;
        }
        public override double Area()
        {
            return (this._a * this._b);
        }
    }
    class Circle : Shape
    {
        private double _r;

        public Circle(double r)
        {
            this._r = r;
        }
        public override double Area()
        {
            return (this._r * this._r * Math.PI);

        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Shape[] ArrayObject = new Shape[3];

            Shape triangle = new Triangle(12, 12, 12);
            Shape circle = new Circle(12);
            Shape rectangle = new Rectangle(12, 12);

            ArrayObject[0] = triangle;
            ArrayObject[1] = circle;
            ArrayObject[2] = rectangle;

            for (int count = 0; count <= 2; count++)
            {
                Console.WriteLine(ArrayObject[count].Area());
            }

            Console.ReadLine();
        }
    }
}
