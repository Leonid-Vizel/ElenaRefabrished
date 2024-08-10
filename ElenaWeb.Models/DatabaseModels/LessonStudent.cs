using Microsoft.EntityFrameworkCore;
using System.ComponentModel;

namespace FRDZSchool.Models.DatabaseModels
{
    [PrimaryKey(nameof(LessonId), nameof(StudentId))]
    public class LessonStudent
    {
        public int LessonId { get; set; }

        public int StudentId { get; set; }

        [DisplayName("Оценка")]
        public decimal? Mark { get; set; }

        [DisplayName("Посещение")]
        public char? Visiting { get; set; }

        public Lesson Lesson { get; set; }
        public Student Student { get; set; }
    }
}
