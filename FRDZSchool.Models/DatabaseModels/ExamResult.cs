namespace FRDZSchool.Models.DatabaseModels
{
    public class ExamResult
    {
        public IEnumerable<EGEResult> Ege { get; set; }
        public IEnumerable<OGEResult> Oge { get; set; }
    }
}
