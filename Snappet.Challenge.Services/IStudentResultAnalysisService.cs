using Snappet.Challenge.Services.Dto;
using System;
using System.Collections.Generic;

namespace Snappet.Challenge.Services
{
    public interface IStudentResultAnalysisService
    {
        IEnumerable<SubjectDomainDto> SearchForSubectDomains(string query);
        IEnumerable<LearningObjectiveStatisticsDto> GetClassLearningObjectiveStatisticsFor(string subject, string domain, 
            DateTime? @from, DateTime? to);
    }
}
