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
        IEnumerable<Assessment> Query(AssessmentFilterModel assessmentFilterModel);
    }
}