using FRDZSchool.DataAccess.Data.Repository.IRepository;
using FRDZSchool.Models.DatabaseModels;
using FRDZSchool.Models.ViewModels.CreateModels;

namespace FRDZSchool.DataAccess.Data.UnitOfWork.IUnitOfWork
{
    public interface IStudentUnitOfWork : IUnitOfWork
    {
        IRepository<Student> Student { get; set; }
        IRepository<Grade> Grade { get; set; }
        IRepository<Student_Grade> StudentGrade { get; set; }
        Task LoadCreateModel(StudentCreateModel createModel);
    }
}
