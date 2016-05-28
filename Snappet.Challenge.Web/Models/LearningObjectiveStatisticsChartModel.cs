namespace Snappet.Challenge.Web.Models
{
    public class LearningObjectiveStatisticsChartModel
    {
        public string LearningObjective { get; set; }
        public DailyStatisticsChartModel[] DailyStatistics { get; set; }
    }
}