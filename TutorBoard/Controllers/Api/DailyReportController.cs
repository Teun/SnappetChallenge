using System.Threading.Tasks;
using System.Web.Http;
using TutorBoard.Dal.Providers;
using TutorBoard.Report.Dtos;
using TutorBoard.Report.Services;

namespace TutorBoard.Controllers.Api
{
    public class DailyReportController : ApiController
    {
        private readonly IDailyReportService _reportService;
        private readonly IDateTimeProvider _dateTime;

        public DailyReportController(IDailyReportService reportService, IDateTimeProvider dateTime)
        {
            _reportService = reportService;
            _dateTime = dateTime;
        }

        public async Task<DailyReportDto> Get()
        {
            return await _reportService.CreateDailyReportAsync(_dateTime.UtcNow);
        }
    }
}
