using FRDZSchool.Models.DatabaseModels;
using FRDZSchool.Models.ViewModels.CreateModels;

namespace FRDZSchool.Models.ViewModels.EditModels
{
    public class TeacherEditModel : TeacherCreateModel
    {
        public TeacherEditModel() { }

        public TeacherEditModel(Teacher teacher)
        {
            Id = teacher.Id;
            Name = teacher.Name;
            Lastname = teacher.Lastname;
            Fathername = teacher.Fathername;
            Post = teacher.Post;
            Birthday = teacher.Birthday;
            Qualification = teacher.Qualification;
            Experience = teacher.Experience;
            PhoneNumber = teacher.PhoneNumber;
        }

        public int Id { get; set; }
    }
}
