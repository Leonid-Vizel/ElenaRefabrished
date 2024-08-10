using FRDZSchool.Models.DatabaseModels;
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

        [DisplayName("Специализация")]
        public string? Specialization { get; set; }

        public Grade ToGrade()
        {
            return new Grade
            {
                Number = Number,
                Litera = Litera,
                Specialization = Specialization
            };
        }
    }
}
