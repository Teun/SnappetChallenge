namespace RReporter.Application.ReportWorkSummary.Dto
{
    public class PupilSummaryDto
    {
        public int UserId { get; set; }

        public LearningObjectiveSummaryDto[] LearningObjectiveSummaries { get; set; }

    }
}