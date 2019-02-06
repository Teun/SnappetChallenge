using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Snappet.ClassInsights.Model.Dto;
using Snappet.ClassInsights.Orm;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Snappet.ClassInsights.Business.Services
{
    internal class InsightsService : IInsightsService
    {
        private readonly InsightsContext _context;
        private readonly ILogger<InsightsService> _logger;

        public InsightsService(InsightsContext context, ILogger<InsightsService> logger)
        {
            _context = context;
            _logger = logger;
        }
        public async Task<List<PubilDailyInsight>> GetPubilsDailyInsightsAsync(DateTime day)
        {
            var from = new DateTime(day.Year, day.Month, day.Day, 0, 0, 0, DateTimeKind.Utc);
            var to = from.AddDays(1);
            _logger.LogInformation($"Get Pubils insights from :{from.ToString("O")}, to : {to.ToString("O")}");
            var result = await _context.SubmittedAnswers
                  .Where(a => a.SubmitDateTime > from && a.SubmitDateTime < to)
                  .GroupBy(a => new { a.UserId, a.Subject, a.Domain })
                  .Select(grp => new PubilDailyInsight
                  {
                      PubilId = grp.Key.UserId,
                      Subject = grp.Key.Subject,
                      Domain = grp.Key.Domain,
                      CountOfSubmittedAnswers = grp.Count(),
                      NumberOfCorrectAnswers = grp.Where(a => a.Correct > 0).Count()
                  }).ToListAsync();
            _logger.LogInformation($"{result?.Count ?? 0} results found!");
            return result;
        }

        public Task<List<DailySubmittedAnswersPerSubjectInsight>> GetSubmittedAnswersPerSubjectInsights(DateTime day)
        {
            throw new NotImplementedException();
        }
    }
}
