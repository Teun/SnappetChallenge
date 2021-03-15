using SnappetReports.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SnappetReports.Data.Services
{
    public class ReportsService : IReportsService
    {
        public List<ReportRecord> GetReportRecords()
        {
            return ReportData.workRecords.ToList();
        }

        public string GetReportJSON()
        {
            return ReportData.workdata;
        }

        public List<SubjectAnswerCount> GetSubjectAnswerCount()
        {
            return ReportData.workRecords
                .GroupBy(a => a.Subject)                
                .Select(n => new SubjectAnswerCount { Subject = n.Key,  AnswerCount = n.Count() })
                .OrderByDescending(n => n.AnswerCount)
                .ToList();
        }


        public List<UserReport> GetUserReports()
        {
            List<UserReport> userReports = (from t in ReportData.workRecords
                orderby t.UserId, t.Subject
                group t by new { t.UserId, t.Subject} into grp
                select new UserReport
                {
                    UserId = grp.Key.UserId,
                    Subject =  grp.Key.Subject,
                    MeanProgress = Math.Round(grp.Average(a => a.Progress), 2),                            
                    MinProgress = grp.Min(a => a.Progress),
                    MaxProgress = grp.Max(a => a.Progress),
                    AnswerCount = grp.Count()                            
                }).ToList();
            return userReports;
        }


        public List<SubjectDailyReport> GetSubjectDailyReports()
        {
            List<SubjectDailyReport> subjectDailyReports = (from t in ReportData.workRecords  
                orderby t.SubmitDateTime 
                group t by new { d = Convert.ToDateTime(t.SubmitDateTime).ToShortDateString(), t.Subject } into grp
                select new SubjectDailyReport
                {   
                    Subject = grp.Key.Subject,                                                
                    SubjectAnswers = grp.Count(),
                    ReportDate = grp.Key.d
                }).ToList();
            return subjectDailyReports;
        }
    }
}
