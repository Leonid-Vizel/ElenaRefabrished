using FRDZSchool.Models;

namespace FRDZSchool.DataAccess.Repository.IRepository
{
    public interface IStudentGradeRepository : IRepository<Student_Grade>
    {
        void Update(Student_Grade obj);
    }
}
