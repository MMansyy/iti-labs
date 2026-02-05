using System;
using System.Collections.Generic;
using System.Text;

namespace lab_2
{
    class Student
    {
        private int age;

        public int Age
        {
            get
            {
                return age;
            }
            set
            {
                if (value >= 16 && value <= 90)
                {
                    age = value;
                }
                else
                {
                    Console.WriteLine("Invalid age");
                }
            }
        }

        public string Name { get; set; }   
        public int Id { get; }             

        public Student(int id)
        {
            Id = id;
        }

        public void display()
        {
            Console.WriteLine($"{Name} {Age} {Id}");
        }
    }
    
}
