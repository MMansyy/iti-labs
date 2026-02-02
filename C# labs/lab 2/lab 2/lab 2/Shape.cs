using System;
using System.Collections.Generic;
using System.Text;

namespace lab_2
{
    internal abstract class Shape
    {
        public virtual double CalculateArea()
        {
            return 0;
        }

        public virtual double CalculatePerimeter()
        {
            return 0;
        }
    }

    internal class Circle : Shape
    {
        double radius;

        public Circle(double radius)
        {
            this.radius = radius;
        }

        public override double CalculateArea()
        {
            return Math.PI * radius * radius;
        }

        public override double CalculatePerimeter()
        {
            return 2 * Math.PI * radius;
        }
    }

    internal class Rectangle : Shape
    {
        double width;
        double height;

        public Rectangle(double width, double height)
        {
            this.width = width;
            this.height = height;
        }

        public override double CalculateArea()
        {
            return width * height;
        }

        public override double CalculatePerimeter()
        {
            return 2 * (width + height);
        }
    }

    internal class Triangle : Shape
    {
        double a, b, c;

        public Triangle(double a, double b, double c)
        {
            this.a = a;
            this.b = b;
            this.c = c;
        }

        public override double CalculateArea()
        {
            double s = (a + b + c) / 2;
            return Math.Sqrt(s * (s - a) * (s - b) * (s - c));
        }

        public override double CalculatePerimeter()
        {
            return a + b + c;
        }
    }



}
