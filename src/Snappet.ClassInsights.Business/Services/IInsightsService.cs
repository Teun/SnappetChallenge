using Snappet.ClassInsights.Model.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Snappet.ClassInsights.Business.Services
{
    public interface IInsightsService
    {
        Task<List<DailySubmittedAnswersPerSubjectInsight>> GetSubmittedAnswersPerSubjectInsights(DateTime day); 
        Task<List<PubilDailyInsight>> GetPubilsDailyInsightsAsync(DateTime day);
    }
}
