using System.ComponentModel.DataAnnotations;

namespace SnappetChallenge.AggregateModels
{
    public class DayCompareToLastWeekModel : ModelBase
    {
        [DisplayFormat(DataFormatString = "{0:n2}")]
        public double? AvgProgressForDay { get; set; }

        [DisplayFormat(DataFormatString = "{0:n2}")]
        public double? AvgProgressForLastWeek { get; set; }

        [DisplayFormat(DataFormatString = "{0:n2}")]
        public double? ProgressChange { get; set; }

    }
}
