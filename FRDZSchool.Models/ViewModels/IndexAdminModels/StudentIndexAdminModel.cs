using FRDZSchool.Models.DatabaseModels;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel;

namespace FRDZSchool.Models.ViewModels.IndexAdminModels
{
    public class StudentIndexAdminModel
    {
        public int Id { get; set; }

        [DisplayName("Имя")]
        public string Name { get; set; }

        [DisplayName("Фамилия")]
        public string Lastname { get; set; }

        [DisplayName("Отчество")]
        public string Fathername { get; set; }

        [DisplayName("Пол")]
        public char Sex { get; set; }

        [DisplayName("Дата рождения")]
        public DateTime Birthday { get; set; }

        [DisplayName("Класс")]
        public int GradeId { get; set; }

        [ValidateNever]
        public List<Grade> Grades { get; set; }

        public StudentIndexAdminModel() { }

        public StudentIndexAdminModel(Student student)
        {
            Id = student.Id;
            Name = student.Name;
            Lastname = student.Lastname;
            Fathername = student.Fathername;
            Sex = student.Sex;
            Birthday = student.Birthday;
        }
    }
}
