using FRDZSchool.DataAccess.Data.Repository.IRepository;
using FRDZSchool.Models.DatabaseModels;

namespace FRDZSchool.DataAccess.Data.UnitOfWork.IUnitOfWork
{
    public interface IGradeUnitOfWork : IUnitOfWork
    {
        IRepository<Grade> Grade { get; set; }
    }
}
