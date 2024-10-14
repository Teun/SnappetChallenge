using Microsoft.AspNetCore.Mvc;
using backend.Services;
using backend.Models;

namespace backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentWorkController : ControllerBase
    {
        private readonly IStudentWorkService _studentWorkService;

        public StudentWorkController(IStudentWorkService studentWorkService)
        {
            _studentWorkService = studentWorkService;
        }

        [HttpGet("today")]
        public ActionResult<List<StudentWork>> GetAllStudentWorksToday()
        {
            var studentWorks = _studentWorkService.GetStudentWorksBySubmitDateTime(DateTime.Parse("2015-03-24T11:30:00.000"));
            return Ok(studentWorks);
        }

        // Endpoint to get submission count by submit date
        [HttpGet("today/submission-count")]
        public IActionResult GetSubmissionCountToday()
        {
            var count = _studentWorkService.GetSubmissionCountBySubmitDateTime(DateTime.Parse("2015-03-24T11:30:00.000"));
            return Ok(count);
        }

        // Endpoint to get average score of subject by submit date
        [HttpGet("today/average-score")]
        public IActionResult GetAverageScoreOfSubjectToday()
        {
            var SubjectProgresss = _studentWorkService.GetAverageScoreOfSubjectBySubmitDateTime(DateTime.Parse("2015-03-24T11:30:00.000"));
            return Ok(SubjectProgresss);
        }

        // Endpoint to get top-performing students by submit date and limit
        [HttpGet("today/top-performing-students")]
        public IActionResult GetTopPerformingStudentsToday()
        {
            var topStudents = _studentWorkService.GetStudentPerformancesBySubmitDateTime(DateTime.Parse("2015-03-24T11:30:00.000"));
            return Ok(topStudents);
        }
    }
}
