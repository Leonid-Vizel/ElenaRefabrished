using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace FRDZSchool.Models
{
    public class Lesson
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("School_Object")]
        [DisplayName("Предмет")]
        [Required(ErrorMessage = "Укажите предмет!")]
        public int SchoolObjectId { get; set; }
        public School_Object SchoolObject { get; set; }

        [ForeignKey("Teacher")]
        [DisplayName("Учитель")]
        [Required(ErrorMessage = "Укажите учителя!")]
        public int TeacherId { get; set; }
        public Teacher Teacher { get; set; }

        [DisplayName("Дата проведения")]
        [Required(ErrorMessage = "Укажите дату!")]
        public DateTime DateAndTime { get; set; }

        [DisplayName("Описание")]
        public string? LessonDescription { get; set; }

        [DisplayName("Домашнее задание")]
        public string? HomeTask { get; set; }

        public List<Lesson_Student> Lesson_Student { get; set; }
    }
}
