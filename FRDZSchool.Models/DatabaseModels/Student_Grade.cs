using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Microsoft.EntityFrameworkCore;

namespace FRDZSchool.Models.DatabaseModels
{
    [PrimaryKey(nameof(StudentId), nameof(GradeId))]
    public class Student_Grade
    {
        public int StudentId { get; set; }

        public int GradeId { get; set; }

        public Student Student { get; set; }
        public Grade Grade { get; set; }
    }
}
