using Microsoft.AspNetCore.Mvc;
using Snappet.API.ViewModels;
using Snappet.Domain;
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
                var skip = dailyReportRequest.Page * dailyReportRequest.PageSize;
                var take = dailyReportRequest.PageSize == 0 ? SnappetConstants.PAGE_SIZE : dailyReportRequest.PageSize;
                _logger.LogInformation("Daily report for: {date}", dailyReportRequest.Date);
                var data = _exerciseRepository.GetStudentActivity(DateOnly.FromDateTime(dailyReportRequest.Date), skip, take);
                if (data == null || data.Count() == 0)
                {
                    return NotFound();
                }
                return Ok(data);
            }
        }

        [HttpPost("daily-report/{userId}")]
        public IActionResult DeatailDailyReport(int userId, DailyReportRequest dailyReportRequest)
        {
            using (var unitOfWork = _unitOfWork)
            {
                var skip = dailyReportRequest.Page * dailyReportRequest.PageSize;
                var take = dailyReportRequest.PageSize == 0 ? SnappetConstants.PAGE_SIZE : dailyReportRequest.PageSize;
                _logger.LogInformation("Daily report for: {date}", dailyReportRequest.Date);
                var data = _exerciseRepository.GetStudentExercises(DateOnly.FromDateTime(dailyReportRequest.Date), userId, skip, take);
                if (data == null || data.Count() == 0)
                {
                    return NotFound();
                }
                return Ok(data);
            }
        }

    }
}
