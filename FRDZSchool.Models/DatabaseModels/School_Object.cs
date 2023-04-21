using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace FRDZSchool.Models.DatabaseModels
{
    public class School_Object
    {
        [Key]
        public int Id { get; set; }

        [DisplayName("Название предмета")]
        [Required]
        public string Name { get; set; }
    }
}
