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
                .Select(n => new SubjectAnswerCount { Subject = n.Key,  AnswerCount = n.Count() }).ToList();
        }


        public List<UserReport> GetUserReports()
        {
            return ReportData.workRecords.GroupBy(i => i.UserId)
                  .Select(g => new UserReport {
                      UserId = g.Key,
                      AnswerCount = g.Sum(i => i.SubmittedAnswerId),
                      MeanProgress = g.Average(i => i.Progress),
                      MaxProgress = g.Max(i => i.Progress),
                      MinProgress = g.Min(i => i.Progress)
                  }).ToList();
        }
    }
}
