using FRDZSchool.Models.DatabaseModels;

namespace SchoolWeb.Models
{
    public class ExamResult
    {
        public IEnumerable<EGEResult> Ege { get; set; }
        public IEnumerable<OGEResult> Oge { get; set; }
    }
}
