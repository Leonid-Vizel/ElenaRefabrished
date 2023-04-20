using FRDZSchool.DataAccess.Data;
using FRDZSchool.DataAccess.Repository.IRepository;
using FRDZSchool.Models;

namespace FRDZSchool.DataAccess.Repository
{
    public class StudentGradeRepository : Repository<Student_Grade>, IStudentGradeRepository
    {
        private ApplicationContext _db;
        public StudentGradeRepository(ApplicationContext db) : base(db) => _db = db;

        public void Update(Student_Grade obj)
        {
            _db.Student_Grade.Update(obj);
        }
    }
}
