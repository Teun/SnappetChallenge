using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SnappetChallenge.AggregateModels
{
    public class DailyWorkModel : ModelBase
    {
        public int Correct0 { get; internal set; }
        public int Correct1 { get; internal set; }
        public int Correct3 { get; internal set; }

        [DisplayFormat(DataFormatString = "{0:n2}")]
        public double? AvgProgress { get; internal set; }
    }
}
