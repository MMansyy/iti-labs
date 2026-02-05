using System;
using System.Collections.Generic;
using System.Text;

namespace Lab_3
{
    internal class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string City { get; set; }
        public void display()
        {
            Console.WriteLine($"{FirstName} , {LastName} , {Age} , {City}");
        }
    }

}