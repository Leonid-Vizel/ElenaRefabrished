using FRDZSchool.DataAccess.Data.Repository;
using FRDZSchool.DataAccess.Data.Repository.IRepository;
using FRDZSchool.DataAccess.Data.UnitOfWork.IUnitOfWork;
using FRDZSchool.Models.DatabaseModels;
using FRDZSchool.Models.ViewModels.CreateModels;

namespace FRDZSchool.DataAccess.Data.UnitOfWork
{
    public class GradeUnitOfWork : UnitOfWork, IGradeUnitOfWork
    {
        public GradeUnitOfWork(ApplicationContext context) : base(context)
        {
            Student = new Repository<Student>(context);
            Grade = new Repository<Grade>(context);
        }

        public IRepository<Student> Student { get; set; }
        public IRepository<Grade> Grade { get; set; }
    }
}
