using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Snappet_challenge_api.Services;


namespace Snappet_challenge_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentsController : ControllerBase
    {
        public readonly IConfiguration _config;
        public readonly IStudentsService _studentsService;

        public StudentsController(IConfiguration config, IStudentsService studentsService)
        {
            _config = config;
            _studentsService = studentsService;
        }

        [HttpGet("get-students")]
        public IActionResult GetSubjects()
        {
            var students = _studentsService.GetStudents();
            if (students is null)
            {
                return BadRequest("Error retrieving data");
            }

            return Ok(students);
        }
    }
}
