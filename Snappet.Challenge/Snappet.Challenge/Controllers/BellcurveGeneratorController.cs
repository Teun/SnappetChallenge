using Snappet.Challenge.Facade;
using Snappet.Challenge.Helpers;
using Snappet.Challenge.Models;
using Snappet.Repository;
using System;
using System.Linq;
using System.Web.Http;

namespace Snappet.Challenge.Controllers
{

    public class BellcurveGeneratorController:ApiController
    {
        private readonly IStudentSkillRepository _studentSkillRepository;
        private readonly IStatisticsDataFacade _statisticsDataFacade;
        public BellcurveGeneratorController(IStudentSkillRepository studentSkillRepository, IStatisticsDataFacade statisticsDataFacade)
        {
            _studentSkillRepository = studentSkillRepository;
            _statisticsDataFacade = statisticsDataFacade;
        }

        [HttpGet]
        [Route("api/bellcurve/generate")]
        public IHttpActionResult GenerateBellCurveData(string givenDateTimeUTC, string subject)
        {
            if (string.IsNullOrWhiteSpace(givenDateTimeUTC)) return BadRequest();
            var targetDate = DateValidater.ValidateDate(givenDateTimeUTC);
            if (targetDate == DateTime.MinValue) return BadRequest("Invalid Date");
            var dataSample = CreateBellCurveSample(targetDate, subject);
            if (dataSample == null) return NotFound();
            return Ok(dataSample);
        }

        #region private
        private DataPoint CreateBellCurveSample(DateTime targetDate, string subject)
        {
            var students = _studentSkillRepository.FindByDate(targetDate);

            var isValidDataSample = students.Count() > 0;
            if (!isValidDataSample)
            {
                return null;
            }
            var dataSample = _statisticsDataFacade.GenerateBellCurveData(students, subject);
            if (dataSample.Data.Count() == 0 || dataSample.Data.Count() == 0)
            {
                return null;
            }
            return dataSample;
        }
        #endregion

    }
}