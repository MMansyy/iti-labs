using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;

namespace MVCLAB2.Models
{
    public class ITIContextcs : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=iti_test;Integrated Security=True;Trust Server Certificate=True");
            optionsBuilder.LogTo(Console.WriteLine, LogLevel.Debug);
        }

      


        public DbSet<Student> students { get; set; }

        public DbSet<Department> departments { get; set; }
    }
}
