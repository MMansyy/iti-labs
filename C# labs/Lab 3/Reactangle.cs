using System;
using System.Collections.Generic;
using System.Text;

namespace Lab_3
{
    internal class Rectangle
    {
        public double Width { get; set; }
        public double Height { get; set; }

        public string Color { get; set; } = "White";
        public string Unit { get; set; } = "cm";

        public int Id { get; }

        public Rectangle(int id)
        {
            Id = id;
        }

        public double Area => Width * Height;
    }

}
