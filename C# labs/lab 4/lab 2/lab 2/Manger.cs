using System;
using System.Collections.Generic;
using System.Text;

namespace lab_2
{
    internal class Manger : Employee
    {
        protected int Bonus;
        protected int TeamSize;

        public Manger(int id, string name, int baseSalary, int bonus, int teamSize) : base(id, name, baseSalary)
        {
            this.Bonus = bonus;
            this.TeamSize = teamSize;
        }


        public override void displayInfo()
        {
            Console.WriteLine($"ID : {this.ID}, Name : {this.Name}, Salary : {this.BaseSalary}, Bonus : {this.Bonus}, Total Salary : {this.calcSalary()}, Team Size : {this.TeamSize}");
        }

        public override int calcSalary()
        {
            int total = base.BaseSalary + this.Bonus;
            return total;
        }


    }
}
