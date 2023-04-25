using FRDZSchool.Models.DatabaseModels;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FRDZSchool.Models.ViewModels.CreateModels
{
    public class GradeCreateModel
    {
        [DisplayName("Номер")]
        [Required(ErrorMessage = "У класса обязательно должен быть номер!")]
        [Range(1, 11, ErrorMessage = "В школе могут быть только {1}-{2} классы!")]
        public int Number { get; set; }

        [DisplayName("Литера")]
        [Required(ErrorMessage = "У класса обязательно должен быть буквенный индекс!")]
        public char Litera { get; set; }

        [DisplayName("Учебный год")]
        [Required(ErrorMessage = "У класса обязательно должен быть указан учебный год!")]
        public DateTime AcademYear { get; set; }

        [DisplayName("Специализация")]
        public string? Specialization { get; set; }

        [DisplayName("Ученики")]
        [Required(ErrorMessage = "Укажите учеников!")]
        public int StudentId { get; set; }

        [ValidateNever]
        public List<Student> Students { get; set; }

        public Grade ToGrade()
        {
            return new Grade
            {
                Number = Number,
                Litera = Litera,
                AcademYear = AcademYear,
                Specialization = Specialization
            };
        }
    }
}
