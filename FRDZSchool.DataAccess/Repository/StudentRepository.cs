using FRDZSchool.DataAccess.Data;
using FRDZSchool.DataAccess.Repository.IRepository;
using FRDZSchool.Models;

namespace FRDZSchool.DataAccess.Repository
{
    public class StudentRepository : Repository<Student>, IStudentRepository
    {
        private ApplicationContext _db;
        public StudentRepository(ApplicationContext db) : base(db) => _db = db;

        public void Update(Student obj)
        {
            _db.Student.Update(obj);
        }
    }
}
