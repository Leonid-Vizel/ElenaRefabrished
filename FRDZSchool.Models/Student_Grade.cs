using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace FRDZSchool.Models
{
    public class Student_Grade
    {
        [Column("Student_Num")]
        [DisplayName("Номер ученика")]
        [Required]
        public int Student_Id { get; set; }

        [Column("Grade_Num")]
        [DisplayName("Номер класса")]
        [Required]
        public int Grade_Id { get; set; }

        [Column("Grade_Index")]
        [DisplayName("Литера")]
        [Required]
        public char Litera { get; set; }

        [Column("Academic_Year")]
        [DisplayName("Учебный год")]
        [Required]
        public DateTime AYear { get; set; }
    }
}
