using Snappet.Challenge.Facade;
using Snappet.Challenge.Helpers;
using Snappet.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace Snappet.Challenge.Controllers
{
    public class ScatterPlotGeneratorController:ApiController
    {
        private readonly IStudentSkillRepository _studentSkillRepository;
        private readonly IScatterPlotDataFacade _scatterPlotDataFacade;
        public ScatterPlotGeneratorController(IStudentSkillRepository studentSkillRepository, IScatterPlotDataFacade scatterPlotDataFacade)
        {
            _studentSkillRepository = studentSkillRepository;
            _scatterPlotDataFacade = scatterPlotDataFacade;
        }

        [HttpGet]
        [Route("api/scatterplot/generate")]
        public IHttpActionResult GenerateScatterPlotData(string givenDateTimeUTC, string subject)
        {
            if (string.IsNullOrWhiteSpace(givenDateTimeUTC)) return BadRequest();
            var targetDate = DateValidater.ValidateDate(givenDateTimeUTC);
            if (targetDate == DateTime.MinValue) return BadRequest("Invalid Date");
            var dataSample = CreateScatterPlotSample(targetDate, subject);
            if (dataSample == null) return NotFound();
            return Ok(dataSample);
        }

        private IEnumerable<KeyValuePair<double, double>> CreateScatterPlotSample(DateTime targetDate, string subject)
        {
            var students = _studentSkillRepository.FindByDate(targetDate);

            var isValidDataSample = students.Count() > 0;
            if (!isValidDataSample)
            {
                return null;
            }
            var dataSample = _scatterPlotDataFacade.GenerateScatterPlotData(students, subject);
            if (dataSample.Count() == 0)
            {
                return null;
            }
            return dataSample;
        }
       

    }
}