using FRDZSchool.DataAccess.Data.Repository.IRepository;
using FRDZSchool.Models.DatabaseModels;
using FRDZSchool.Models.ViewModels.CreateModels;

namespace FRDZSchool.DataAccess.Data.UnitOfWork.IUnitOfWork
{
    public interface IGradeUnitOfWork : IUnitOfWork
    {
        IRepository<Student> Student { get; set; }
        IRepository<Grade> Grade { get; set; }
    }
}
