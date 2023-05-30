using FRDZSchool.Models.DatabaseModels;
using FRDZSchool.Models.ViewModels.CreateModels;

namespace FRDZSchool.Models.ViewModels.EditModels
{
    public class LessonEditModel : LessonCreateModel
    {
        public LessonEditModel() { }

        public LessonEditModel(Lesson lesson)
        {
            Id = lesson.Id;
            DateAndTime = lesson.DateAndTime;
            LessonDescription = lesson.LessonDescription;
            HomeTask = lesson.HomeTask;
            SchoolObjectId = lesson.SchoolObjectId;
            TeacherId = lesson.TeacherId;
        }

        public int Id { get; set; }
    }
}
