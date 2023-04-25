using FRDZSchool.DataAccess.Data.Repository;
using FRDZSchool.DataAccess.Data.Repository.IRepository;
using FRDZSchool.DataAccess.Data.UnitOfWork.IUnitOfWork;
using FRDZSchool.Models.DatabaseModels;
using FRDZSchool.Models.ViewModels.CreateModels;

namespace FRDZSchool.DataAccess.Data.UnitOfWork
{
    public class StudentUnitOfWork : UnitOfWork, IStudentUnitOfWork
    {
        public StudentUnitOfWork(ApplicationContext context) : base(context)
        {
            Student = new Repository<Student>(context);
            Grade = new Repository<Grade>(context);
            StudentGrade = new Repository<Student_Grade>(context);
        }

        public IRepository<Student> Student { get; set; }
        public IRepository<Grade> Grade { get; set; }
        public IRepository<Student_Grade> StudentGrade { get; set; }

        public async Task LoadCreateModel(StudentCreateModel createModel)
        {
            createModel.Grades = await Grade.GetAllAsync();
        }
    }
}
