using FRDZSchool.Models.DatabaseModels;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FRDZSchool.Models.ViewModels.CreateModels
{
    public class LessonCreateModel
    {

        [DisplayName("Дата проведения")]
        [Required(ErrorMessage = "Укажите дату!")]
        public DateTime DateAndTime { get; set; }

        [DisplayName("Описание")]
        public string? LessonDescription { get; set; }

        [DisplayName("Домашнее задание")]
        public string? HomeTask { get; set; }

        [DisplayName("Предмет")]
        [Required(ErrorMessage = "Укажите предмет!")]
        public int SchoolObjectId { get; set; }

        [DisplayName("Учитель")]
        [Required(ErrorMessage = "Укажите учителя!")]
        public int TeacherId { get; set; }

        [ValidateNever]
        public List<Teacher> Teachers { get; set; }

        [ValidateNever]
        public List<SchoolObject> SchoolObjects { get; set; }

        public Lesson ToLesson()
        {
            return new Lesson
            {
                DateAndTime = DateAndTime,
                LessonDescription = LessonDescription,
                HomeTask = HomeTask,
                SchoolObjectId = SchoolObjectId,
                TeacherId = TeacherId
            };
        }
    }
}
