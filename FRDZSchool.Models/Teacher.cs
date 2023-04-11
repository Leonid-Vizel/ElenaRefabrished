using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace FRDZSchool.Models
{
    public class Teacher
    {
        [Key]
        [Column("Teacher_Num")]
        [DisplayName("Номер")]
        public int Id { get; set; }

        [DisplayName("ФИО")]
        [Required(ErrorMessage = "Введите ФИО!")]
        public string FIO { get; set; }

        [DisplayName("Должность")]
        [Required(ErrorMessage = "Введите должность!")]
        public string Post { get; set; }

        [DisplayName("Дата рождения")]
        [Required(ErrorMessage = "Введите дату рождения!")]
        public DateTime Birthday { get; set; }

        [DisplayName("Квалификация")]
        [Required(ErrorMessage = "Введите квалификацию!")]
        public string? Qualification { get; set; }

        [DisplayName("Стаж")]
        [Required(ErrorMessage = "Введите стаж!")]
        [Range(0, 60, ErrorMessage = "Стаж не может превышать {2} лет!")]
        public int? Experience { get; set; }

        [DisplayName("Номер телефона")]
        [Required(ErrorMessage = "Введите номер телефона!")]
        [Phone(ErrorMessage = "Вы указали не номер телефона!")]
        public string? Tel_Num { get; set; }
    }
}
