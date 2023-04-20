using FRDZSchool.Models;

namespace FRDZSchool.DataAccess.Repository.IRepository
{
    public interface ITeacherRepository : IRepository<Teacher>
    {
        void Update(Teacher obj);
    }
}
