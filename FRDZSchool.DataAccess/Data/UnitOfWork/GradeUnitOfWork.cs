using FRDZSchool.DataAccess.Data.Repository;
using FRDZSchool.DataAccess.Data.Repository.IRepository;
using FRDZSchool.DataAccess.Data.UnitOfWork.IUnitOfWork;
using FRDZSchool.Models.DatabaseModels;

namespace FRDZSchool.DataAccess.Data.UnitOfWork
{
    public class GradeUnitOfWork : UnitOfWork, IGradeUnitOfWork
    {
        public GradeUnitOfWork(ApplicationContext context) : base(context)
        {
            Grade = new Repository<Grade>(context);
        }

        public IRepository<Grade> Grade { get; set; }
    }
}
