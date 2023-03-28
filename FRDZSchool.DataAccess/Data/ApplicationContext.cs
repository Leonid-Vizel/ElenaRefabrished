using FRDZSchool.Models;
using Microsoft.EntityFrameworkCore;

namespace FRDZSchool.DataAccess.Data
{
    public class ApplicationContext : DbContext, IDisposable
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }

        public DbSet<Student> Student { get; set; } = null!;
        public DbSet<Grade> Grade { get; set; } = null!;
        public DbSet<Teacher> Teacher { get; set; } = null!;
        public DbSet<Lesson> Lesson { get; set; } = null!;
        public DbSet<Lesson_Student> Lesson_Student { get; set; } = null!;
        public DbSet<School_Object> School_Object { get; set; } = null!;
        public DbSet<Student_Grade> Student_Grade { get; set; } = null!;

        public ApplicationContext() => Database.EnsureCreated();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Grade>().HasKey(u => new { u.Id, u.Litera, u.AYear });
            modelBuilder.Entity<Lesson_Student>().HasKey(u => new { u.Lesson_Id, u.Student_Id });
            modelBuilder.Entity<Student_Grade>().HasKey(u => new { u.Grade_Id, u.Litera, u.AYear, u.Student_Id });
        }
    }
}
