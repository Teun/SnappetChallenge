using Snappet.Entities;
using Snappet.ServiceLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Snappet.ServiceLayer
{
    /// <summary>
    /// Summary Service
    /// </summary>
    public class SummaryService : ISummaryService
    {

        private SnappetDBContext dbContext { get; set; }

        public SummaryService(SnappetDBContext snappetDBContext)
        {
            dbContext = snappetDBContext;
        }

        public IEnumerable<SummaryViewModel> LoadSubjectSummaries(DateTime date)
        {
            var subjectGroupBy = dbContext.Summary.Where(summary => summary.SubmitDateTime.Value.Date == date.Date).GroupBy(item => item.Subject);
            List<SummaryViewModel> subjectSummary = subjectGroupBy
                .Select(item =>
                        new SummaryViewModel()
                        {
                            Title = item.Key,
                            TotalProgress = item.Sum(p => p.Progress),
                            TotalAnswersSubmitted = item.Count(),
                            TotalCorrectAnswers = item.Count(summary => summary.Correct == 1)
                        }).ToList();

            return subjectSummary;
        }

        public bool LoadSummaries()
        {
            bool isDataPresent = dbContext.Summary.Any();

            if (!isDataPresent)
            {
                dbContext.Summary.AddRange(GenericHelper.LoadSummaryFromFile());
                dbContext.SaveChanges();
            }
            return true;
        }

        public IEnumerable<SummaryViewModel> LoadDomainSummaries(DateTime date, string subject)
        {
            var domainGroupBy = dbContext.Summary.Where(summary => summary.SubmitDateTime.Value.Date == date.Date && summary.Subject == subject).GroupBy(item => item.Domain);
            List<SummaryViewModel> domainSummary = domainGroupBy
                .Select(item =>
                        new SummaryViewModel()
                        {
                            Title = item.Key,
                            TotalProgress = item.Sum(p => p.Progress),
                            TotalAnswersSubmitted = item.Count(),
                            TotalCorrectAnswers = item.Count(summary => summary.Correct == 1)
                        }).ToList();

            return domainSummary;
        }

        public IEnumerable<SummaryViewModel> LoadLearningObjectiveSummaries(DateTime date, string domain)
        {
            var learningObjectiveGroupBy = dbContext.Summary.Where(summary => summary.SubmitDateTime.Value.Date == date.Date && summary.Domain == domain).GroupBy(item => item.LearningObjective);
            List<SummaryViewModel> domainSummary = learningObjectiveGroupBy
                .Select(item =>
                        new SummaryViewModel()
                        {
                            Title = item.Key,
                            TotalProgress = item.Sum(p => p.Progress),
                            TotalAnswersSubmitted = item.Count(),
                            TotalCorrectAnswers = item.Count(summary => summary.Correct == 1)
                        }).ToList();

            return domainSummary;
        }

        public IEnumerable<int> LoadStudents()
        {
            IEnumerable<int> studentIds = dbContext.Summary.Select(summary => summary.UserId);

            return studentIds;
        }
    }
}
