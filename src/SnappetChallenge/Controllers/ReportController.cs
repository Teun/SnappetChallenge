using Microsoft.AspNetCore.Mvc;
using SnappetChallenge.Business;
using SnappetChallenge.Models.ViewModels;

namespace SnappetChallenge.Controllers
{
    [Route("api/[controller]/[action]")]
    public class ReportController : Controller
    {
        private readonly ReportManager _reportManager;

        public ReportController(ReportManager reportManager)
        {
            _reportManager = reportManager;
        }

        [HttpPost]
        [ActionName("correctanswerreport")]
        public IActionResult GetCorrectAnswerReport([FromBody] CorrectAnswerRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(_reportManager.BuildAnswerReport(request));
        }

        [HttpGet]
        [ActionName("subjects")]
        public IActionResult GetSubjects()
        {
            return Ok(_reportManager.GetFilters());
        }
    }
}
