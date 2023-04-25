using FRDZSchool.DataAccess.Data.Repository;
using FRDZSchool.DataAccess.Data.Repository.IRepository;
using FRDZSchool.DataAccess.Data.UnitOfWork.IUnitOfWork;
using FRDZSchool.Models.DatabaseModels;

namespace FRDZSchool.DataAccess.Data.UnitOfWork
{
    public class TeacherUnitOfWork : UnitOfWork, ITeacherUnitOfWork
    {
        public TeacherUnitOfWork(ApplicationContext context) : base(context)
        {
            Teacher = new Repository<Teacher>(context);
        }

        public IRepository<Teacher> Teacher { get; set; }
    }
}
