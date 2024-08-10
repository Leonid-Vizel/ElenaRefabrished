using FRDZSchool.DataAccess.Data.Repository.IRepository;
using FRDZSchool.DataAccess.Data.Repository;
using FRDZSchool.DataAccess.Data.UnitOfWork.IUnitOfWork;
using FRDZSchool.Models.DatabaseModels;
using FRDZSchool.Models.ViewModels.CreateModels;

namespace FRDZSchool.DataAccess.Data.UnitOfWork
{
    public class LessonUnitOfWork : UnitOfWork, ILessonUnitOfWork
    {
        public LessonUnitOfWork(ApplicationContext context) : base(context)
        {
            Lesson = new Repository<Lesson>(context);
            SchoolObject = new Repository<SchoolObject>(context);
            Teacher = new Repository<Teacher>(context);
        }

        public IRepository<Lesson> Lesson { get; set; }
        public IRepository<SchoolObject> SchoolObject { get; set; }
        public IRepository<Teacher> Teacher { get; set; }

        public async Task LoadCreateModel(LessonCreateModel createModel)
        {
            createModel.SchoolObjects = await SchoolObject.GetAllAsync();
            createModel.Teachers = await Teacher.GetAllAsync();
        }
    }
}
