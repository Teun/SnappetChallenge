using SnappetReports.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SnappetReports.Data.Services
{
    public interface IReportsService
    {
        public List<ReportRecord> GetReportRecords();
        public string GetReportJSON();
        public List<SubjectAnswerCount> GetSubjectAnswerCount();
        public List<UserReport> GetUserReports();
        public List<SubjectDailyReport> GetSubjectDailyReports();
    }
}
