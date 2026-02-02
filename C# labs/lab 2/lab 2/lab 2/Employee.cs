using System;
using System.Collections.Generic;
using System.Text;

namespace lab_2
{
    internal class Employee
    {
        protected int ID;
        protected string Name;
        protected int BaseSalary;



        public Employee(int ID, string Name, int BaseSalary)
        {
            this.ID = ID;
            this.Name = Name;
            this.BaseSalary = BaseSalary;
        }

        public virtual void displayInfo()
        {
            Console.WriteLine($"ID : {this.ID}, Name : {this.Name}, Salary : {this.BaseSalary}");
        }

        public virtual int calcSalary()
        {
            return this.BaseSalary;
        }
    }
}
