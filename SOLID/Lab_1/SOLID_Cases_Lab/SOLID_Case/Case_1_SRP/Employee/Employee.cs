using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID.SOLID_Implement_2._2_1_SRP
{
    //    public class Employee
    //    {
    //        public string Name { get; set; }
    //        public decimal Salary { get; set; }


    //        public void SaveEmployee(Employee employee)
    //        {
    //            // Code to save employee to the database
    //        }

    //        public void CalculateSalary(Employee employee)
    //        {
    //            // Code to calculate employee's salary
    //        }
    //    }


    public class Employee
    {
        public string Name { get; set; }
        public decimal Salary { get; set; }
    }


    public class EmployeeRepo
    {
        public void SaveEmployee(Employee employee)
        {
            // Code to save employee to database
        }
    }


    public class EmployeeSalaryCalcultor
    {
        public decimal CalculateSalary(Employee employee)
        {
            // salary calculation logic

            return employee.Salary;
        }
    }
}
