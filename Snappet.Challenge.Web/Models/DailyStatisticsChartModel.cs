namespace Snappet.Challenge.Web.Models
{
    public class DailyStatisticsChartModel
    {
        public long X { get; set; }

        public float Y { get; set; }

        public double? AvgDifficulty { get; set; }

        public int AmountOfProgressedStudents { get; set; }

        public int Correct { get; set; }

        public int Incorrect { get; set; }
    }
}