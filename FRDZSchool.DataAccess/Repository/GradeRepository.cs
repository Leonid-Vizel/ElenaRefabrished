using FRDZSchool.DataAccess.Data;
using FRDZSchool.DataAccess.Repository.IRepository;
using FRDZSchool.Models;

namespace FRDZSchool.DataAccess.Repository
{
    public class GradeRepository : Repository<Grade>, IGradeRepository
    {
        private ApplicationContext _db;
        public GradeRepository(ApplicationContext db) : base(db) => _db = db;

        public void Update(Grade obj)
        {
            _db.Grade.Update(obj);
        }
    }
}
