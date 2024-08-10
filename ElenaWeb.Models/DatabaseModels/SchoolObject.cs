using FRDZSchool.Models.ViewModels.EditModels;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FRDZSchool.Models.DatabaseModels
{
    public class SchoolObject
    {
        [Key]
        public int Id { get; set; }

        [DisplayName("Название предмета")]
        [Required]
        public string Name { get; set; }

        public void Update(SchoolObjectEditModel schoolObjectEditModel)
        {
            Id = schoolObjectEditModel.Id;
            Name = schoolObjectEditModel.Name;
        }
    }
}
