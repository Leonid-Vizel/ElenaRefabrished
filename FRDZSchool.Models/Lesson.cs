using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace FRDZSchool.Models
{
    public class Lesson
    {
        [Key]
        [Column("Lesson_Num")]
        [DisplayName("Номер")]
        public int Id { get; set; }

        [DisplayName("Описание")]
        public string? Lesson_Description { get; set; }

        [DisplayName("Предмет")]
        [Required]
        public int Code_Obj { get; set; }
        [ForeignKey("Code_Obj")]
        public School_Object SchoolObject { get; set; }

        [DisplayName("Дата проведения")]
        [Required]
        public DateTime Date_And_Time { get; set; }

        [DisplayName("Учитель")]
        [Required]
        public int Teacher_Num { get; set; }
        [ForeignKey("Teacher_Num")]
        public Teacher Teacher { get; set; }

        [DisplayName("Домашнее задание")]
        public string? Home_Task { get; set; }
    }
}
