using System;
namespace Snappet.WebAPI.Models
{
    public interface IReportService
    {
        System.Collections.Generic.IEnumerable<LearningObjectiveProgress> GetLearningObjectiveProgressReport(DateTime dateVal);
    }
}
