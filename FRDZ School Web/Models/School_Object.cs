using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace FRDZ_School_Web.Models
{
    public class School_Object
    {
        [Key]
        [Column("Code")]
        [DisplayName("Номер")]
        [Required]
        public decimal Id { get; set; }

        [DisplayName("Название предмета")]
        [Required]
        public string Name_Obj { get; set; }
    }
}
