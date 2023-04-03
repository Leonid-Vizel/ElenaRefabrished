using FRDZSchool.DataAccess.Data;
using FRDZSchool.DataAccess.Repository.IRepository;
using FRDZSchool.Models;

namespace FRDZSchool.DataAccess.Repository
{
    public class TeacherRepository : Repository<Teacher>, ITeacherRepository
    {
        private ApplicationContext _db;
        public TeacherRepository(ApplicationContext db) : base(db)
        {
            _db = db;
        }

        void ITeacherRepository.Save()
        {
            _db.SaveChanges();
        }

        void ITeacherRepository.Update(Teacher obj)
        {
            _db.Teacher.Update(obj);
        }
    }
}
