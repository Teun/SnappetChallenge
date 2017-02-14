using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Chart.Mvc.ComplexChart;
using SnappetChallenge.BusinessLogicLayer.Interfaces;
using SnappetChallenge.Interfaces;
using SnappetChallenge.Models;

namespace SnappetChallenge.Controllers
{
    [Authorize]
    public class ChartsController : Controller
    {
        private readonly ISubmittedAnswerService _submittedAnswerService;
        private readonly IChartService _chartService;

        public ChartsController(ISubmittedAnswerService submittedAnswerService, IChartService chartService)
        {
            if (submittedAnswerService == null) throw new ArgumentNullException(nameof(submittedAnswerService));
            if (chartService == null) throw new ArgumentNullException(nameof(chartService));

            _submittedAnswerService = submittedAnswerService;
            _chartService = chartService;
        }

        // GET: Charts
        public ActionResult Index()
        {
            var submittedAnswers = _submittedAnswerService.GetSubmittedAnswers();

            var model = new ChartsViewModel()
            {
                ProgressBySubjectChart = _chartService.GenerateProgressBySubjectChart(submittedAnswers),
                CorrectAnswerAmountChart = _chartService.GenerateCorrectAnswerAmountChart(submittedAnswers),
                CorrectAnswersByDomainsChart = _chartService.GenerateCorrectAnswersByDomainsChart(submittedAnswers)
            };
            return View(model);
        }
    }
}