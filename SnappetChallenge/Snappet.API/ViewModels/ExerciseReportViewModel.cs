namespace Snappet.API.ViewModels
{
    public class ExerciseReportViewModel
    {
        public DateTime SubmitDateTime { get; set; }
        public int Progress { get; set; }
        public int UserId { get; set; }
        public int ExerciseId { get; set; }
        public double? Difficulty { get; set; }
        public string? Subject { get; set; }
        public string? Domain { get; set; }
        public string? LearningObjective { get; set; }
    }
}
