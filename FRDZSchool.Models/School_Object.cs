using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace FRDZSchool.Models
{
    public class School_Object
    {
        [Key]
        [Column("Code")]
        [DisplayName("Номер")]
        [Required]
        public int Id { get; set; }

        [DisplayName("Название предмета")]
        [Required]
        public string Name_Obj { get; set; }
    }
}
