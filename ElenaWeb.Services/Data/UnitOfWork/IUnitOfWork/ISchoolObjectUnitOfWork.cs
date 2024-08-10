using FRDZSchool.DataAccess.Data.Repository.IRepository;
using FRDZSchool.Models.DatabaseModels;

namespace FRDZSchool.DataAccess.Data.UnitOfWork.IUnitOfWork
{
    public interface ISchoolObjectUnitOfWork : IUnitOfWork
    {
        IRepository<SchoolObject> SchoolObject { get; set; }
    }
}
