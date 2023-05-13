using FRDZSchool.Models.DatabaseModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FRDZSchool.DataAccess.Data
{
    public class ApplicationContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }

        public DbSet<Student> Student { get; set; } = null!;
        public DbSet<Grade> Grade { get; set; } = null!;
        public DbSet<Teacher> Teacher { get; set; } = null!;
        public DbSet<Lesson> Lesson { get; set; } = null!;
        public DbSet<LessonStudent> LessonStudent { get; set; } = null!;
        public DbSet<SchoolObject> SchoolObject { get; set; } = null!;

        public ApplicationContext() => Database.EnsureCreated();

        protected override void OnModelCreating(ModelBuilder modelBuilder) => base.OnModelCreating(modelBuilder);
    }
}
