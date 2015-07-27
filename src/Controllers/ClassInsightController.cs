using System;
using System.Threading.Tasks;

using Microsoft.AspNet.Mvc;

using SnappetChallenge.Models;
using SnappetChallenge.Services.Contracts;
using SnappetChallenge.ViewModels;

namespace SnappetChallenge.Controllers
{
    [Route("api/class-insights")]
    public class ClassInsightController : Controller
    {
        private readonly IClassResults _classResults;

        public ClassInsightController(IClassResults classResults)
        {
            _classResults = classResults;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var start = new DateTime(2015, 3, 24, 0, 0, 0);
            var end = new DateTime(2015, 3, 24, 11, 30, 0);
            var timeRange = new TimeRange(start, end);

            var vm = new ClassInsightsViewModel
            {
                RequestedDate = end.ToShortDateString(),
                AmountOfAnswers = await _classResults.GetAmountOfAnswersAsync(timeRange),
                MostDifficultyWith = await _classResults.GetMostDifficultAsync(timeRange),
                AmountOfAnswersCorrect = await _classResults.GetAmountCorrectAsync(timeRange),
                MostProgress = await _classResults.GetMostProgressAsync(timeRange),
                TopObjectivesStudied = await _classResults.GetTopObjectivesAsync(timeRange),
                TotalProgress = await _classResults.GetTotalProgressAsync(timeRange)
            };

            return Json(vm);
        }
    }
}
