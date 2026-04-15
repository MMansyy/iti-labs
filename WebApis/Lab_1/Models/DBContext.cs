using Microsoft.EntityFrameworkCore;

namespace Lab_1.Models
{
    public class DBContext : DbContext
    {
        public DBContext() : base()
        {
        }

        public DBContext(DbContextOptions<DBContext> options) : base(options)
        {
        }


        public DbSet<Course> Courses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Course>()
                .Property(c => c.ID)
                .ValueGeneratedOnAdd();

        }

    }
}
