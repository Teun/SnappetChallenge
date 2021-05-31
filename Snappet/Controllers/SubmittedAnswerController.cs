using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Snappet.Model;
using Snappet.Service;

namespace Snappet.Controllers
{
    [ApiController]
    [Route("SubmittedAnswers")]
    public class SubmittedAnswerController : ControllerBase
    {
        private readonly ISubmittedAnswerService _submittedAnswerService;
        private readonly IReportService _reportService;

        public SubmittedAnswerController(ISubmittedAnswerService submittedAnswerService, IReportService reportService)
        {
            _submittedAnswerService = submittedAnswerService;
            _reportService = reportService;
        }

        [HttpGet]
        [Route("GetReportForStudent")]
        [ProducesResponseType(typeof(StudentReportResponse), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 400)]
        public async Task<IActionResult> GetReportForStudent([FromQuery] StudentReportRequest request)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var answers = (await _submittedAnswerService.GetAllForStudent(request.StudentId, request.Date)).ToArray();

            var result = new StudentReportResponse
            {
                DomainReport = await _reportService.GetDomainReport(answers),
                SubjectReport = await _reportService.GetSubjectReport(answers),
                LearningObjectiveReport = await _reportService.GetLearningObjectiveReport(answers),
                DifficultyRangeReport = await _reportService.GetDifficultyReport(answers)
            };
            
            return Ok(result);
        }

        [HttpGet]
        [Route("GetReportForClass")]
        [ProducesResponseType(typeof(ClassReportResponse), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 400)]
        public async Task<IActionResult> GetReportForClass([FromQuery] ClassReportRequest request)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var answers = (await _submittedAnswerService.GetAll(request.Date)).ToArray();

            var result = new StudentReportResponse
            {
                DomainReport = await _reportService.GetDomainReport(answers),
                SubjectReport = await _reportService.GetSubjectReport(answers),
                LearningObjectiveReport = await _reportService.GetLearningObjectiveReport(answers),
                DifficultyRangeReport = await _reportService.GetDifficultyReport(answers)
            };
            return Ok(result);
        }
    }
}