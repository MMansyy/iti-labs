using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID.SOLID_Implement_2._2_3_LSP
{
    //#region Bad Code
    public abstract class Shape { }

    public class Rectangle : Shape
    {
        public int Width { get; set; }
        public int Height { get; set; }
    }
    public class Square : Shape
    {
        public int Side { get; set; }
    }

    //#endregion
}
