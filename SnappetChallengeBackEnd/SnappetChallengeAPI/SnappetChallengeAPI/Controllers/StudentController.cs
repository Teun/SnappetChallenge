using Microsoft.AspNetCore.Mvc;
using SnappetChallengAPI.Helper;
using SnappetChallengAPI.Model;
using SnappetChallengAPI.Service;


namespace SnappetChallengAPI.Controllers
{
    [Route("api/[controller]/")]
    [ApiController]
    public class StudentController : Controller, IStudentController
    {

        private readonly StudentService _studentService;
        public StudentController(StudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpGet]
        [Route("GetTodayStatisticalReport")]
        public virtual JsonWrapper GetTodayStatisticalReport()
        {
            var from = new DateTime(2015, 03, 24, 00, 00, 00);
            var to = new DateTime(2015, 03, 24, 11, 30, 00);
            var report =  _studentService.GetStatisticalReportService(from, to);
            return new JsonWrapper(report);
        }

        [HttpGet]
        [Route("GetSubjects")]
        public virtual JsonWrapper GetSubjects()
        {
            var subjects = _studentService.GetSubjects();
            return new JsonWrapper(subjects);
        }

        [HttpGet]
        [Route("GetDomains")]
        public virtual JsonWrapper GetDomains()
        {
            var domains = _studentService.GetDomains();
            return new JsonWrapper(domains);
        }

        [HttpPost]
        [Route("GetFilteredStudents")]
        public virtual JsonWrapper GetFilteredStudents(FilterReport filter)
        {
            var report = _studentService.GetFilteredStudents(filter);
            return new JsonWrapper(report);
        }

        
    }
}