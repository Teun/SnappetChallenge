using Microsoft.AspNetCore.Mvc;
using Snappet.API.ViewModels;
using Snappet.Domain.Interface;
using Snappet.Domain.Interface.Repository;

namespace Snappet.API.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class ReportController : ControllerBase
    {
        private readonly ILogger<ReportController> _logger;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IExerciseRepository _exerciseRepository;

        public ReportController(
            ILogger<ReportController> logger
            , IUnitOfWork unitOfWork
            , IExerciseRepository exerciseRepository)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
            _exerciseRepository = exerciseRepository;
        }

        [HttpPost("daily-report")]
        public IActionResult DailyReport(DailyReportRequest dailyReportRequest)
        {
            using (var unitOfWork = _unitOfWork)
            {
                _logger.LogInformation("Daily report for: {date}", dailyReportRequest.Date);
                var data = _exerciseRepository.GetStudentActivity(DateOnly.FromDateTime(dailyReportRequest.Date));
                return Ok(data);
            }
        }

    }
}
