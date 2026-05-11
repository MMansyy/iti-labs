using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID.SOLID_Case_Answer.Case_Answer_2_OCP
{
    #region Bad Code
    //public class Shape
    //{
    //    public virtual double Area { get; } // Makes derived classes implement Area

    //    public void RectangleShape(double width, double height)
    //    {
    //        // Logic for rectangle specific calculations
    //    }

    //    public void CircleShape(double radius)
    //    {
    //        // Logic for circle specific calculations
    //    }
    //}

    #endregion

    #region Good Code

    public abstract class Shape
    {
        public abstract double Area();
    }

    public class Rectangle : Shape
    {
        public double Width { get; set; }
        public double Height { get; set; }

        public override double Area()
        {
            return Width * Height;
        }
    }

    public class Circle : Shape
    {
        public double Radius { get; set; }

        public override double Area()
        {
            return Math.PI * Radius * Radius;
        }
    }

    #endregion
}
