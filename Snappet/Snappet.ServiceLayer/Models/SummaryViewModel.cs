namespace Snappet.ServiceLayer.Models
{
    /// <summary>
    /// Summary view model
    /// </summary>
    public class SummaryViewModel
    {
        /// <summary>
        /// Total answers submitted
        /// </summary>
        public int TotalAnswersSubmitted { get; set; }

        /// <summary>
        /// Total correct answers
        /// </summary>
        public int TotalCorrectAnswers { get; set; }

        /// <summary>
        /// Total progress
        /// </summary>
        public int TotalProgress { get; set; }

        /// <summary>
        /// Title
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Total progress
        /// </summary>
        public int CorrectPercentage { get => ((TotalCorrectAnswers / TotalAnswersSubmitted) * 100); }

    }
}
