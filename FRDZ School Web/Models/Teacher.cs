using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace FRDZ_School_Web.Models
{
    public class Teacher
    {
        [Key]
        [Column("Teacher_Num")]
        [DisplayName("Номер")]
        public decimal Id { get; set; }

        [DisplayName("ФИО")]
        [Required(ErrorMessage="Обязательно введите ФИО учителя!")]
        public string FIO { get; set; }

        [DisplayName("Должность")]
        [Required(ErrorMessage = "Обязательно введите должность, занимаемую учителем!")]
        public string Post { get; set; }

        [DisplayName("Дата рождения")]
        [Required(ErrorMessage = "Обязательно введите дату рождения учителя!")]
        public DateTime Birthday { get; set; }

        [DisplayName("Квалификация")]
        [Required(ErrorMessage = "Обязательно введите квалификацию учителя!")]
        public string? Qualification { get; set; }

        [DisplayName("Стаж")]
        [Required(ErrorMessage = "Обязательно введите стаж учителя!")]
        [Range(0, 60, ErrorMessage = "Стаж не может превышать {2} лет")]
        public decimal? Experience { get; set; }

        [DisplayName("Номер телефона")]
        [Required(ErrorMessage = "Обязательно введите номер телефона учителя!")]
        [Phone(ErrorMessage = "Вы указали не номер телефона!")]
        public string? Tel_Num { get; set; }
    }
}
