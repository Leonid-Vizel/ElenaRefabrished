using FRDZSchool.DataAccess.Data;
using FRDZSchool.DataAccess.Repository.IRepository;

namespace FRDZSchool.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationContext _db;
        public ITeacherRepository Teacher { get; private set; }
        public IStudentRepository Student { get; private set; }
        public IGradeRepository Grade { get; private set; }
        public UnitOfWork(ApplicationContext db)
        {
            _db = db;
            Teacher = new TeacherRepository(_db);
            Student = new StudentRepository(_db);
            Grade = new GradeRepository(_db);
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
