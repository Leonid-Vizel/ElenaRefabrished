using FRDZSchool.DataAccess.Data.Repository.IRepository;
using FRDZSchool.Models.DatabaseModels;

namespace FRDZSchool.DataAccess.Data.UnitOfWork.IUnitOfWork
{
    public interface ITeacherUnitOfWork : IUnitOfWork
    {
        IRepository<Teacher> Teacher { get; set; }
    }
}
