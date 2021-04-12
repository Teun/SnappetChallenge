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

        #region Private region 

        /// <summary>
        /// Db context
        /// </summary>
        private SnappetDBContext dbContext { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Constructor for summary service 
        /// </summary>
        /// <param name="snappetDBContext">Dbcontext</param>
        public SummaryService(SnappetDBContext snappetDBContext)
        {
            dbContext = snappetDBContext;
        }

        #endregion

        #region Public methods
        
        /// <summary>
        /// Loads the summary based on subjects
        /// </summary>
        /// <param name="date">Date</param>
        /// <returns>List of summary</returns>
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
        public string LoadSummaries()
        {
            bool isDataPresent = dbContext.Summary.Any();

            if (!isDataPresent)
            {
                dbContext.Summary.AddRange(GenericHelper.LoadSummaryFromFile());
                dbContext.SaveChanges();
            }
            return "<h5>Api is running now</h5>";
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

        /// <summary>
        /// Loads the list of student ids
        /// </summary>
        /// <returns>List of student ids</returns>
        public IEnumerable<int> LoadStudents()
        {
            IEnumerable<int> studentIds = dbContext.Summary.Select(summary => summary.UserId);

            return studentIds;
        }

        #endregion
    }
}
