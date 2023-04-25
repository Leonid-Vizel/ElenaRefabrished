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

        [ValidateNever]
        public List<Student_Grade> Student_Grade { get; set; }

        [DisplayName("Класс")]
        public int GradeId { get; set; }

        [ValidateNever]
        public List<Grade> Grades { get; set; }
    }
}
