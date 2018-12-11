using System.Collections.Generic;
using System.Web.Http;
using Snappet.Model;
using SnappetRepository.Repository;

namespace SnappetWebAPI.Controllers
{
    public class ReportController : ApiController
    {
        private IReportRepository _reportRepository;

        public ReportController(IReportRepository reportRepository)
        {
            _reportRepository = reportRepository;
        }

        [HttpGet]
        [Route("GetReport")]
        public IEnumerable<Report> GetReport(string date,string subject, string domain,string viewtype)
        {
            var reports = _reportRepository.GetReport(date, subject, domain, viewtype);
            return reports;
        }


        [HttpGet]
        [Route("GetStudentDetails")]
        public IEnumerable<Student> GetStudentDetails(string date, string subject, string domain,string objective)
        {
            var reports = _reportRepository.GetStudentDetails(date, subject, domain, objective);
            return reports;
        }
       
    }
}