using FRDZSchool.Models;

namespace FRDZSchool.DataAccess.Repository.IRepository
{
    public interface IStudentRepository : IRepository<Student>
    {
        void Update(Student obj);
    }
}
