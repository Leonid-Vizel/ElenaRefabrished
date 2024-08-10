using FRDZSchool.DataAccess.Data.Repository;
using FRDZSchool.DataAccess.Data.Repository.IRepository;
using FRDZSchool.DataAccess.Data.UnitOfWork.IUnitOfWork;
using FRDZSchool.Models.DatabaseModels;

namespace FRDZSchool.DataAccess.Data.UnitOfWork
{
    public class SchoolObjectUnitOfWork : UnitOfWork, ISchoolObjectUnitOfWork
    {
        public SchoolObjectUnitOfWork(ApplicationContext context) : base(context)
        {
            SchoolObject = new Repository<SchoolObject>(context);
        }

        public IRepository<SchoolObject> SchoolObject { get; set; }
    }
}
