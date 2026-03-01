using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lab13
{
    internal class DataBaseContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
            optionsBuilder.UseSqlServer("Data Source=MANSY\\SQLEXPRESS;Integrated Security=True;Encrypt=True;Trust Server Certificate=True;Initial Catalog=EFCore");
        
    }
}
