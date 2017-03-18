using System.Web.Http;
using Snappet.Borisov.Test.Domain;
using Snappet.Borisov.Test.Domain.Reporting;

namespace Snappet.Borisov.Test.WebApp.Controllers
{
    public class OverviewReportController : ApiController
    {
        private readonly IGenerateOverviewReports _reports;

        public OverviewReportController(IGenerateOverviewReports reports)
        {
            _reports = reports;
        }

        [HttpGet]
        [Route("api/report/overview")]
        public OverviewReport Generate()
        {
            return _reports.Generate();
        }
    }
}