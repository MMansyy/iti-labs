using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID.SOLID_Case_Answer.Case_Answer_2_OCP
{
    #region Bad Code
    //public class Drawing
    //{
    //    public string DrawShape(string shape)
    //    {
    //        string result=string.Empty;
    //        if (shape == "Circle")
    //        {
    //            result="Drawing a Circle";
    //        }
    //        else if (shape == "Square")
    //        {
    //            result ="Drawing a Square";
    //        }

    //        return result;
    //    }
    //}

    #endregion

    #region Good Code

    public abstract class Shape
    {
        public abstract string Draw();
    }

    public class Circle : Shape
    {
        public override string Draw()
        {
            return "Draw a Circle";
        }
    }

    public class Square : Shape
    {
        public override string Draw()
        {
            return "Draw a Square";
        }
    }

    public class Drawing
    {
        public string DrawShape(Shape shape)
        {
            return shape.Draw();
        }
    }

    #endregion
}
