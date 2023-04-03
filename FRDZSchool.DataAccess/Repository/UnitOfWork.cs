using FRDZSchool.DataAccess.Data;
using FRDZSchool.DataAccess.Repository.IRepository;

namespace FRDZSchool.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationContext _db;
        public ITeacherRepository Teacher { get; private set; }
        public UnitOfWork(ApplicationContext db)
        {
            _db = db;
            Teacher = new TeacherRepository(_db);
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
