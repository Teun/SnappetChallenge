using Snappet.Challenge.Facade;
using Snappet.Challenge.Helpers;
using Snappet.Repository;
using System;
using System.Web.Http;

namespace Snappet.Challenge.Controllers
{

    public class AppraisalReportController:ApiController
    {
        private readonly IStudentSkillRepository _studentSkillRepository;
        private readonly IReportDataFacade _reportDataFacade;
        public AppraisalReportController(
            IStudentSkillRepository studentSkillsRepository, 
            IReportDataFacade reportDataFacade)
        {
            _studentSkillRepository = studentSkillsRepository;
            _reportDataFacade = reportDataFacade;
        }

        [HttpGet]
        [Route("api/appraisalreport/fetchbydate")]
        public IHttpActionResult FetchStudentsByDate(string givenDateTimeUTC)
        {
            if (string.IsNullOrWhiteSpace(givenDateTimeUTC)) return BadRequest();
            var targetDate = DateValidater.ValidateDate(givenDateTimeUTC);
            if (targetDate == DateTime.MinValue) return BadRequest("Invalid Date");
            var students = _studentSkillRepository.FindByDate(targetDate);
            var report = _reportDataFacade.ProcessSkillsData(students);
            return Ok(students);
        }
        [HttpGet]
        [Route("api/appraisalreport/fetchbydate")]
        public IHttpActionResult FetchStudentsByDateRange(string startDateTimeUTC,string enddate)
        {
            if (string.IsNullOrWhiteSpace(startDateTimeUTC) || string.IsNullOrWhiteSpace(enddate)) return BadRequest();

            var fromDate = DateValidater.ValidateDate(startDateTimeUTC);
            if (fromDate == DateTime.MinValue) return BadRequest("The given startdate date is invalid.");

            var toDate = DateValidater.ValidateDate(enddate);
            if (toDate == DateTime.MinValue) return BadRequest("The given end date is invalid.");


            var students = _studentSkillRepository.FindByDateRange(fromDate,toDate);
            var report = _reportDataFacade.ProcessSkillsData(students);
            return Ok(report);
        }
    }
}