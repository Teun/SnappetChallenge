using Snappet.Domain;

namespace Snappet.API.ViewModels
{
    public class DailyReportRequest
    {
        public DateTime Date { get; set; }
        public int Page { get; set; } = 0;
        public int PageSize { get; set; } = SnappetConstants.PAGE_SIZE;
    }
}
