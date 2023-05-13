using FRDZSchool.DataAccess.Data.Repository.IRepository;
using FRDZSchool.Models.DatabaseModels;
using FRDZSchool.Models.ViewModels.CreateModels;

namespace FRDZSchool.DataAccess.Data.UnitOfWork.IUnitOfWork
{
    public interface ILessonUnitOfWork : IUnitOfWork
    {
        IRepository<Lesson> Lesson { get; set; }
        IRepository<SchoolObject> SchoolObject { get; set; }
        IRepository<Teacher> Teacher { get; set; }

        Task LoadCreateModel(LessonCreateModel createModel);
    }
}
