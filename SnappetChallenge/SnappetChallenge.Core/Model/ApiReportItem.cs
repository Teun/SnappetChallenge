namespace SnappetChallenge.Core
{
    /// <summary>
    /// Item in api response
    /// </summary>
    public class ApiReportItem
    {
        /// <summary>
        /// Gets or sets the sum progress.
        /// </summary>
        /// <value>
        /// The sum progress.
        /// </value>
        public int SumProgress { get; set; }

        /// <summary>
        /// Gets or sets the correct answers.
        /// </summary>
        /// <value>
        /// The correct answers.
        /// </value>
        public decimal CorrectAnswers { get; set; }

        /// <summary>
        /// Gets or sets the subject.
        /// </summary>
        /// <value>
        /// The subject.
        /// </value>
        public string Subject { get; set; }
    }
}
