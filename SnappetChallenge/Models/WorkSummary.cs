using System.ComponentModel.DataAnnotations;

namespace SnappetChallenge.Models
{
    public class WorkSummary
    {
        public int ProgressToday { get; set; }
        public int QuestionsOk { get; set; }
        public int QuestionsNok { get; set; }
        public int TotalQuestions { get; set; }
        public string GroupedBy { get; set; }
        [DisplayFormat(DataFormatString = "{0:N}")]
        public decimal? AverageDifficulty { get; set; }
    }
}