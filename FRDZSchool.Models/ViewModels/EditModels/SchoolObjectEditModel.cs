using FRDZSchool.Models.DatabaseModels;
using FRDZSchool.Models.ViewModels.CreateModels;

namespace FRDZSchool.Models.ViewModels.EditModels
{
    public class SchoolObjectEditModel : SchoolObjectCreateModel
    {
        public SchoolObjectEditModel() { }

        public SchoolObjectEditModel(SchoolObject schoolObject)
        {
            Name = schoolObject.Name;
        }

        public int Id { get; set; }
    }
}
