using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace FRDZ_School_Web.Models
{
    public class Grade
    {
        [Column("Grade_Num")]
        [DisplayName("Номер")]
        [Required(ErrorMessage = "У класса обязательно должен быть номер!")]
        [Range(1, 11, ErrorMessage = "В школе могут быть только {1}-{2} классы!")]
        public decimal Id { get; set; }

        [Required(ErrorMessage = "У класса обязательно должен быть буквенный индекс!")]
        [Column("Grade_Index")]
        [DisplayName("Литера")]
        public char Litera { get; set; }

        [Required(ErrorMessage = "Укажите учебный год!")]
        [Column("Academic_Year")]
        [DisplayName("Учебный год")]
        public DateTime AYear { get; set; }

        [DisplayName("Специализация")]
        public string? Specialization { get; set; }
    }
}
