using FRDZSchool.Models;

namespace FRDZSchool.DataAccess.Repository.IRepository
{
    public interface IGradeRepository : IRepository<Grade>
    {
        void Update(Grade obj);
    }
}
