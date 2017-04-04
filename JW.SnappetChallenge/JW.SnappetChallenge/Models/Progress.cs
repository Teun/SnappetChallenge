namespace JW.SnappetChallenge.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class Progress
    {
        public string Description { get; set; }
        public int TotalAnwers { get; set; }
        public int CorrectAnswers { get; set; }
        public double OverallProgress { get; set; }
    }
}