using System;

namespace BlCore.ReportServices.Models
{
    public class OneUserReportItem
    {
        public DateTime ActionDt { get; set; }

        public int User { get; set; }

        public string Correct { get; set; }

        public string Exercise { get; set; }

        public string Difficulty { get; set; }

        public string Subject { get; set; }

        public string Objective { get; set; }

        public string Domain { get; set; }

        public int Progress { get; set; }
    }
}
