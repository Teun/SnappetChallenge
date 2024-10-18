namespace SnappetChallenge.Models
{
    public class WorkModel
    {
        public int SubmittedAnswerId { get; set; }
        public DateTime SubmitDateTime { get; set; }
        public int Correct { get; set; }
        public int Progress { get; set; }
        public int UserId { get; set; }
        public string Difficulty { get; set; } = string.Empty;
        public string Subject { get; set; } = string.Empty;
        public string Domain { get; set; } = string.Empty;
        public string LearningObjective { get; set; } = string.Empty;
    }
}