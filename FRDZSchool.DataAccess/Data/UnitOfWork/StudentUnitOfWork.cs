using FRDZSchool.DataAccess.Data.Repository;
using FRDZSchool.DataAccess.Data.Repository.IRepository;
using FRDZSchool.DataAccess.Data.UnitOfWork.IUnitOfWork;
using FRDZSchool.Models.DatabaseModels;
using FRDZSchool.Models.ViewModels.CreateModels;
using FRDZSchool.Models.ViewModels.IndexAdminModels;

namespace FRDZSchool.DataAccess.Data.UnitOfWork
{
    public class StudentUnitOfWork : UnitOfWork, IStudentUnitOfWork
    {
        public StudentUnitOfWork(ApplicationContext context) : base(context)
        {
            Student = new Repository<Student>(context);
            Grade = new Repository<Grade>(context);
        }

        public IRepository<Student> Student { get; set; }
        public IRepository<Grade> Grade { get; set; }

        public async Task LoadCreateModel(StudentCreateModel createModel)
        {
            createModel.Grades = await Grade.GetAllAsync();
        }

        public async Task LoadIndexAdminModel(StudentIndexAdminModel indexAdminModel)
        {
            indexAdminModel.Grades = await Grade.GetAllAsync();
        }
    }
}
