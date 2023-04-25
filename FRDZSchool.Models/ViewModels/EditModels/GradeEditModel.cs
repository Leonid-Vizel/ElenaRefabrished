using FRDZSchool.Models.DatabaseModels;
using FRDZSchool.Models.ViewModels.CreateModels;

namespace FRDZSchool.Models.ViewModels.EditModels
{
    public class GradeEditModel : GradeCreateModel
    {
        public GradeEditModel() { }

        public GradeEditModel(Grade grade)
        {
            Id = grade.Id;
            Number = grade.Number;
            Litera = grade.Litera;
            Specialization = grade.Specialization;
        }

        public int Id { get; set; }
    }
}
