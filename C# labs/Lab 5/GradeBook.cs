using System;
using System.Collections.Generic;
using System.Text;

namespace Lab_3
{
    internal class GradeBook
    {
        double[] grades;
        int size;

        public GradeBook(int size)
        {
            this.size = size;
            this.grades = new double[size];
        }

        public double this[int index]
        {
            get
            {
                if (index >= 0 && index < size)
                {

                    return grades[index];
                }
                else
                {
                    return -1;
                }
            }
            set
            {
                if (index >= 0 && index < size)
                {
                    grades[index] = value;
                }
            }
        }
    }
}
