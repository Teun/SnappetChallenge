namespace RReporter.Application.ReportWorkSummary.Dto
{
    public class LearningObjectiveSummaryDto
    {
        public string Domain { get; set; }

        public string Subject { get; set; }

        public string LearningObjective { get; set; }

        public double CorrectPercentage { get; set; }

        public int TotalProgress { get; set; }

        public double? MaxDifficulty { get; set; }

        public int NumberOfAnswers { get; set; }

    }
}