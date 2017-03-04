namespace Snappet.Reporting.Application.Dto
{
    public class CorrectAnswersPerLearningObjectiveDto
    {
        public string Subject { get; set; }
        public string LearningObjective { get; set; }
        public int Count { get; set; }
        public int Total { get; set; }
        public decimal Percentage => Total > 0 ? Count / (decimal)Total : 0;
    }

    public class CorrectAnswersPerUserDto : CorrectAnswersPerLearningObjectiveDto
    {
        public int UserId { get; set; }
    }
}