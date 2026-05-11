using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID.SOLID_Implement_2._2_2_OCP
{
    #region Bad Code
    //public class Shape
    //{
    //    public virtual double Area(double radius)
    //    {
    //        return 0;
    //    }
    //}

    //public class Circle : Shape
    //{
    //    public override double Area(double radius)
    //    {
    //        return Math.PI * radius * radius;
    //    }
    //}

    //public class Square : Shape
    //{
    //    public override double Area(double radius)
    //    {
    //        return radius * radius;
    //    }
    //}

    #endregion

    #region Good Code

    public abstract class Shape
    {
        public abstract double Area();
    }

    public class Circle : Shape
    {
        public double Radius { get; set; }

        public override double Area()
        {
            return Math.PI * Radius * Radius;
        }
    }

    public class Square : Shape
    {
        public double SideLength { get; set; }

        public override double Area()
        {
            return SideLength * SideLength;
        }
    }

    #endregion
}
