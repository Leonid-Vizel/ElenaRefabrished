using FRDZSchool.Models.DatabaseModels;
using FRDZSchool.Models.ViewModels.CreateModels;

namespace FRDZSchool.Models.ViewModels.EditModels
{
    public class StudentEditModel : StudentCreateModel
    {
        public StudentEditModel() { }

        public StudentEditModel(Student student)
        {
            Id = student.Id;
            Name = student.Name;
            Lastname = student.Lastname;
            Fathername = student.Fathername;
            Sex = student.Sex;
            Birthday = student.Birthday;
        }

        public int Id { get; set; }
    }
}
