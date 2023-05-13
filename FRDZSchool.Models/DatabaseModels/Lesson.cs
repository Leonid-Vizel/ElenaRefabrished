using FRDZSchool.Models.ViewModels.EditModels;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FRDZSchool.Models.DatabaseModels
{
    public class Lesson
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("School_Object")]
        [DisplayName("Предмет")]
        [Required]
        public int SchoolObjectId { get; set; }
        public SchoolObject SchoolObject { get; set; }

        [ForeignKey("Teacher")]
        [DisplayName("Учитель")]
        [Required]
        public int TeacherId { get; set; }
        public Teacher Teacher { get; set; }

        [DisplayName("Дата проведения")]
        [Required]
        public DateTime DateAndTime { get; set; }

        [DisplayName("Описание")]
        public string? LessonDescription { get; set; }

        [DisplayName("Домашнее задание")]
        public string? HomeTask { get; set; }

        public List<LessonStudent> LessonStudent { get; set; }

        public void Update(LessonEditModel lessonEditModel)
        {
            Id = lessonEditModel.Id;
            DateAndTime = lessonEditModel.DateAndTime;
            LessonDescription = lessonEditModel.LessonDescription;
            HomeTask = lessonEditModel.HomeTask;
            SchoolObjectId = lessonEditModel.SchoolObjectId;
            TeacherId = lessonEditModel.TeacherId;
        }
    }
}
