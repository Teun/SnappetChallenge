namespace BlCore.ReportServices.Models
{
    public class OneObjectiveReportTotal
    {
        public string Objective { get; set; }

        public int UsersCount { get; set; }

        public int Progress { get; set; }

        public int AverageProgress { get; set; }
    }
}