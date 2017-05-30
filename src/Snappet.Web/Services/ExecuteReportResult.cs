using System.Collections.Generic;

namespace Snappet.Web.Services
{
    public class ExecuteReportResult
    {
        public int Id { get; set; }
        public string DisplayName { get; set; }
        public List<string> Columns { get; set; } = new List<string>();
        public List<List<object>> Rows { get; set; } = new List<List<object>>();
    }
}