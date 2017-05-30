using System.Collections.Generic;

namespace Snappet.Web.Persistence.Models
{
    public class ReportConfiguration
    {
        public int Id { get; set; }
        public int ReportId { get; set; }
        public Report Report { get; set; }
        public IEnumerable<ReportParameter> Parameters { get; set; }
    }
}