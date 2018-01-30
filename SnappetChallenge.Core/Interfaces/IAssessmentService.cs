using System;
using System.Collections.Generic;
using SnappetChallenge.Core.Entities;

namespace SnappetChallenge.Core.Interfaces
{
    public interface IAssessmentService : IDisposable
    {
        void ClearData();
        void InsertBulkAssessments(string assessments);
        long GetAssessmentsCount();
        IEnumerable<Assessment> GetFilterdAssessments(AssessmentFilterModel assessmentFilterModel);
        IEnumerable<ClassResult> GetClassResults(string submitDateTime = "2015-03-24 11:30:00");
    }
}