using Microsoft.AspNetCore.Mvc;
using Snappet.ServiceLayer;
using Snappet.ServiceLayer.Models;
using System;
using System.Collections.Generic;

namespace Snappet.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SummaryController : ControllerBase
    {
        private ISummaryService SummaryService { get; set; }

        public SummaryController(ISummaryService summaryService)
        {
            SummaryService = summaryService;
        }

        [HttpGet]
        public bool Get()
        {
            bool result = SummaryService.LoadSummaries();

            return result;
        }

        [HttpGet]
        [Route("overview")]
        public IEnumerable<SummaryViewModel> LoadSummary(DateTime date)
        {
            IEnumerable<SummaryViewModel> summaries = SummaryService.LoadSubjectSummaries(date);

            return summaries;
        }

        [HttpGet]
        [Route("domainsummary")]
        public IEnumerable<SummaryViewModel> LoadDomainSummary(DateTime date, string subject)
        {
            IEnumerable<SummaryViewModel> summaries = SummaryService.LoadDomainSummaries(date, subject);

            return summaries;
        }

        [HttpGet]
        [Route("learningobjectivesummary")]
        public IEnumerable<SummaryViewModel> LoadLearningObjectiveSummary(DateTime date, string domain)
        {
            IEnumerable<SummaryViewModel> summaries = SummaryService.LoadLearningObjectiveSummaries(date, domain);

            return summaries;
        }
    }
}
