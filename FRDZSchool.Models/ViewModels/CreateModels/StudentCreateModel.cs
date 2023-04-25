using FRDZSchool.Models.DatabaseModels;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FRDZSchool.Models.ViewModels.CreateModels
{
    public class StudentCreateModel
    {
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

        [DisplayName("Класс")]
        [Required(ErrorMessage = "Укажите класс!")]
        public int GradeId { get; set; }

        [ValidateNever]
        public List<Grade> Grades { get; set; }

        public Student ToStudent()
        {
            return new Student
            {
                Name = Name,
                Lastname = Lastname,
                Fathername = Fathername,
                Sex = Sex,
                Birthday = Birthday,
            };
        }
    }
}
