using FRDZSchool.Models.DatabaseModels;
using System.ComponentModel;

namespace FRDZSchool.Models.ViewModels.DeleteModels
{
    public class StudentDeleteModel : Student
    {
        public StudentDeleteModel() { }

        public StudentDeleteModel(Student student)
        {
            Id = student.Id;
            Name = student.Name;
            Lastname = student.Lastname;
            Fathername = student.Fathername;
            Sex = student.Sex;
            Birthday = student.Birthday;
        }

        [DisplayName("Класс")]
        public string GradeName { get; set; }
    }
}
