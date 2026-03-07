using Microsoft.EntityFrameworkCore;

namespace MVCLAB2.Models
{
    public class ITIContextcs : DbContext
    {

        public ITIContextcs() : base() { }

        public ITIContextcs(DbContextOptions<ITIContextcs> options) : base(options) { }


        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=iti_test;Integrated Security=True;Trust Server Certificate=True");
        //}

        public DbSet<Student> students { get; set; }
        public DbSet<Department> departments { get; set; }
        public DbSet<Course> courses { get; set; }
        public DbSet<StudentCourse> studentCourses { get; set; }
        public DbSet<Role> roles { get; set; }
        public DbSet<User> users { get; set; }
        public DbSet<UserRole> userRoles { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>()
                .HasOne(c => c.department)
                .WithMany(d => d.courses)
                .HasForeignKey(c => c.deptID)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Student>()
                .HasOne(s => s.department)
                .WithMany(d => d.students)
                .HasForeignKey(s => s.deptId)
                .OnDelete(DeleteBehavior.Cascade);


            modelBuilder.Entity<StudentCourse>()
                .HasKey(sc => new { sc.studentId, sc.courseId });

            modelBuilder.Entity<StudentCourse>()
                .HasOne(sc => sc.student)
                .WithMany(s => s.studentCourses)
                .HasForeignKey(sc => sc.studentId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<StudentCourse>()
                .HasOne(sc => sc.course)
                .WithMany(c => c.studentCourses)
                .HasForeignKey(sc => sc.courseId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<UserRole>()
                .HasKey(ur => new { ur.userId, ur.roleId });
            modelBuilder.Entity<UserRole>()
                .HasOne(ur => ur.user)
                .WithMany(u => u.userRoles)
                .HasForeignKey(ur => ur.userId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<UserRole>()
                .HasOne(ur => ur.role)
                .WithMany(r => r.userRoles)
                .HasForeignKey(ur => ur.roleId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}