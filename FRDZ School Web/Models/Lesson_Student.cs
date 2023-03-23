using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace FRDZ_School_Web.Models
{
    public class Lesson_Student
    {
        [Column("Lesson_Num")]
        [DisplayName("Номер урока")]
        [Required]
        public decimal Lesson_Id { get; set; }

        [Column("Student_Num")]
        [DisplayName("Номер ученика")]
        [Required]
        public decimal Student_Id { get; set; }

        [DisplayName("Оценка")]
        public decimal? Mark { get; set; }

        [DisplayName("Посещение")]
        public char? Visiting { get; set; }
    }
}
