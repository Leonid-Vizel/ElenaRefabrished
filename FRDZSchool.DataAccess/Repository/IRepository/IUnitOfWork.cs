namespace FRDZSchool.DataAccess.Repository.IRepository
{
    public interface IUnitOfWork
    {
        ITeacherRepository Teacher { get; }
        IStudentRepository Student { get; }
        IGradeRepository Grade { get; }
        IStudentGradeRepository StudentGrade { get; }

        void Save();
    }
}
