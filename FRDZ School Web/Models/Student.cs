using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace FRDZ_School_Web.Models
{
    public class Student
    {
        [Key]
        [Column("Student_Num")]
        [DisplayName("Номер")]
        [Required]
        public decimal Id { get; set; }

        [DisplayName("ФИО")]
        [Required(ErrorMessage = "Обязательно введите ФИО ученика!")]
        public string FIO { get; set; }

        [DisplayName("Пол")]
        [Required(ErrorMessage = "Обязательно введите пол ученика! (Ж или М)")]
        public char Sex { get; set; }

        [DisplayName("Дата рождения")]
        [Required(ErrorMessage = "Обязательно введите дату рождения ученика!")]
        public DateTime Birthday { get; set; }
    }
}
