using FRDZSchool.DataAccess.Data.Repository.IRepository;
using FRDZSchool.Models.DatabaseModels;
using FRDZSchool.Models.ViewModels.CreateModels;
using FRDZSchool.Models.ViewModels.IndexAdminModels;

namespace FRDZSchool.DataAccess.Data.UnitOfWork.IUnitOfWork
{
    public interface IStudentUnitOfWork : IUnitOfWork
    {
        IRepository<Student> Student { get; set; }
        IRepository<Grade> Grade { get; set; }
        Task LoadCreateModel(StudentCreateModel createModel);
        Task LoadIndexAdminModel(StudentIndexAdminModel indexAdminModel);
    }
}
