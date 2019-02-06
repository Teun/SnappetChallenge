namespace Snappet.ClassInsights.Model.Dto
{
    public class PubilDailyInsight
    {
        public string Subject { get; set; }
        public string Domain { get; set; }
        public int CountOfSubmittedAnswers { get; set; }
        public int NumberOfCorrectAnswers { get; set; } 
        public int PubilId { get; set; }
    }
}
