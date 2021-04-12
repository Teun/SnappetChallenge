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
        IEnumerable<SummaryViewModel> LoadSubjectSummaries(DateTime date);

        IEnumerable<SummaryViewModel> LoadDomainSummaries(DateTime date,string subject);

        IEnumerable<SummaryViewModel> LoadLearningObjectiveSummaries(DateTime date, string domain);

        IEnumerable<int> LoadStudents();

        bool LoadSummaries();
    }
}
