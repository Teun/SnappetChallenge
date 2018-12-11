using System.Collections.Generic;
using System.Web.Http;
using Snappet.Model;
using SnappetRepository.Repository;

namespace SnappetWebAPI.Controllers
{
    public class ClassController : ApiController
    {
        private IClassRepository _classRepository;

        public ClassController(IClassRepository classRepository)
        {
            _classRepository = classRepository;
        }

        [HttpGet]
        [Route("GetReport")]
        public IEnumerable<Report> GetReport(string date,string subject, string domain,string viewtype)
        {
            var reports = _classRepository.GetReport(date, subject, domain, viewtype);
            return reports;
        }


        [HttpGet]
        [Route("GetStudentDetails")]
        public IEnumerable<Student> GetStudentDetails(string date, string subject, string domain,string objective)
        {
            var reports = _classRepository.GetStudentDetails(date, subject, domain, objective);
            return reports;
        }
       
    }
}