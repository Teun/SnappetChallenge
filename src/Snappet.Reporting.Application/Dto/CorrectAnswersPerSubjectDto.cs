namespace Snappet.Reporting.Application.Dto
{
    public class CorrectAnswersPerSubjectDto
    {
        public string Subject { get; set; }
        public int Count { get; set; }
        public int Total { get; set; }
        public decimal Percentage => Total > 0 ? Count / (decimal)Total : 0;
    }
}