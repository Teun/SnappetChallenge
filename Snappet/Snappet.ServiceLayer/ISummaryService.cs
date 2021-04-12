using Snappet.ServiceLayer.Models;
using System;
using System.Collections.Generic;

namespace Snappet.ServiceLayer
{
    /// <summary>
    /// Summary service
    /// </summary>
    public interface ISummaryService
    {
        /// <summary>
        /// Loads the summary based on subjects
        /// </summary>
        /// <param name="date">Date</param>
        /// <returns>List of summary</returns>
        IEnumerable<SummaryViewModel> LoadSubjectSummaries(DateTime date);

        IEnumerable<SummaryViewModel> LoadDomainSummaries(DateTime date,string subject);

        IEnumerable<SummaryViewModel> LoadLearningObjectiveSummaries(DateTime date, string domain);

        IEnumerable<int> LoadStudents();

        string LoadSummaries();
    }
}
