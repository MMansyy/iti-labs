using System;
using System.Collections.Generic;
using System.Text;

namespace lab_2
{
    internal class Date
    {
        int year;
        int month;
        int day;
        public static int counter { get; set; }


        static Date()
        {
            counter = 0;
        }

        public Date() : this(1990, 1, 1) { }

        public Date(int year, int month, int day)
        {
            this.year = year;
            this.month = month;
            this.day = day;
            counter++;
        }

        public void displayDate()
        {
            Console.WriteLine($"{this.year} / {this.month} / {this.day}");
        }
    }
}
