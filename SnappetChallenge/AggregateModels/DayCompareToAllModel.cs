using System.ComponentModel.DataAnnotations;

namespace SnappetChallenge.AggregateModels
{
    public class DayCompareToAllModel : ModelBase
    {
        [DisplayFormat(DataFormatString = "{0:n2}")]
        public double? AvgProgressForDay { get; set; }

        [DisplayFormat(DataFormatString = "{0:n2}")]
        public double? AvgProgressForAll { get; set; }

        [DisplayFormat(DataFormatString = "{0:n2}")]
        public double? ProgressChange { get; set; }
    }
}
