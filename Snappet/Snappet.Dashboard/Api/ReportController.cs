using Common.Logging;
using Newtonsoft.Json;
using Snappet.Reports;
using Snappet.Reports.ExerciseStats;
using System;
using System.Web.Http;

namespace Dashboard.Api
{
    public class ReportController : ApiController
    {
        private readonly IReportFactory _reportFactory;
        private readonly ILog _log;

        public ReportController(IReportFactory factory, ILog log)
        {
            _reportFactory = factory;
            _log = log;
        }

        [HttpPost]
        public IHttpActionResult All(string reportName)
        {
            try
            {
                IReport report = _reportFactory.Create(reportName);
                if (report == null)
                {
                    return NotFound();
                }

                // parameters should come from client, using fixed parameters for demo
                string parameters = CreateTemporaryTestParameters();
                var reportObj = report.Generate(parameters);
                return Ok(reportObj);
            }
            catch (Exception e)
            {
                _log.Error("Exception on report generation reportName={reportName}", e);
                return InternalServerError();
            }
        }

        private string CreateTemporaryTestParameters()
        {
            // temporary put test params here
            var test = new ExerciseStatsParameters
            {
                UtcFrom = new DateTime(2015, 3, 24),
                UtcTo = new DateTime(2015, 3, 24, 11, 30, 0)
            };
            var parameters = JsonConvert.SerializeObject(test);
            return parameters;
        }
    }
}