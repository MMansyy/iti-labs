using System;
using System.Collections.Generic;
using System.Text;

namespace Lab_3
{
    internal class Calculator
    {
        public double Divide(double a, double b)
        {
            if (b == 0)
                throw new DivideByZeroException();

            return a / b;
        }
    }

}
