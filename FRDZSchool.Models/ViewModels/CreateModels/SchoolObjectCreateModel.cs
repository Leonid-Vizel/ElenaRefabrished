using FRDZSchool.Models.DatabaseModels;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FRDZSchool.Models.ViewModels.CreateModels
{
    public class SchoolObjectCreateModel
    {
        [DisplayName("Название предмета")]
        [Required(ErrorMessage = "Введите название предмета")]
        public string Name { get; set; }

        public SchoolObject ToSchoolObject()
        {
            return new SchoolObject
            {
                Name = Name
            };
        }
    }
}
