using System.ComponentModel.DataAnnotations;

namespace SnappetChallenge.AggregateModels
{
    public class SummaryDataModel : DailyWorkModel
    {
        public DateTime Date { get; set; }
        public int ProgressLessThan0 { get; set; }
        public int ProgressOverThan0 { get; set; }
    }
}
