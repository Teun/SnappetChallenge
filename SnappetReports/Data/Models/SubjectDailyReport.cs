using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SnappetReports.Data.Models
{
    public class SubjectDailyReport
    {
        public string ReportDate { get; set; }
        public string Subject { get; set; }
        public int SubjectAnswers { get; set; }
    }
}
