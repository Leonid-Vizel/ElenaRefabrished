using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FRDZSchool.Models.DatabaseModels
{
    public class Student
    {
        [Key]
        public int Id { get; set; }

        [DisplayName("Имя")]
        [Required(ErrorMessage = "Введите имя!")]
        public string Name { get; set; }

        [DisplayName("Фамилия")]
        [Required(ErrorMessage = "Введите фамилию!")]
        public string Lastname { get; set; }

        [DisplayName("Отчество")]
        [Required(ErrorMessage = "Введите отчество!")]
        public string Fathername { get; set; }

        [DisplayName("Пол")]
        [Required(ErrorMessage = "Укажите пол! (Ж или М)")]
        public char Sex { get; set; }

        [DisplayName("Дата рождения")]
        [Required(ErrorMessage = "Введите дату рождения!")]
        public DateTime Birthday { get; set; }

        [ValidateNever]
        public List<Student_Grade> Student_Grade { get; set; }

        [ValidateNever]
        public List<Lesson_Student> Lesson_Student { get; set; }
    }
}
