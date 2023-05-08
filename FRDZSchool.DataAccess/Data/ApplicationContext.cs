using FRDZSchool.Models.DatabaseModels;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FRDZSchool.DataAccess.Data
{
    public class ApplicationContext : IdentityDbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }

        public DbSet<Student> Student { get; set; } = null!;
        public DbSet<Grade> Grade { get; set; } = null!;
        public DbSet<Teacher> Teacher { get; set; } = null!;
        public DbSet<Lesson> Lesson { get; set; } = null!;
        public DbSet<Lesson_Student> Lesson_Student { get; set; } = null!;
        public DbSet<School_Object> School_Object { get; set; } = null!;

        public ApplicationContext() => Database.EnsureCreated();

        protected override void OnModelCreating(ModelBuilder modelBuilder) => base.OnModelCreating(modelBuilder);
    }
}
