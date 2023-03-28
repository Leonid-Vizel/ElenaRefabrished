using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace FRDZSchool.Models
{
    public class Student
    {
        [Key]
        [Column("Student_Num")]
        [DisplayName("Номер")]
        [Required]
        public int Id { get; set; }

        [DisplayName("ФИО")]
        [Required(ErrorMessage = "Введите ФИО!")]
        public string FIO { get; set; }

        [DisplayName("Пол")]
        [Required(ErrorMessage = "Укажите пол! (Ж или М)")]
        public char Sex { get; set; }

        [DisplayName("Дата рождения")]
        [Required(ErrorMessage = "Введите дату рождения!")]
        public DateTime Birthday { get; set; }
    }
}
