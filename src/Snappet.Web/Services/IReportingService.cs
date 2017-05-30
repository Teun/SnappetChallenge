using System.Collections.Generic;
using System.Threading.Tasks;
using Snappet.Web.Persistence.Models;

namespace Snappet.Web.Services
{
    public interface IReportingService
    {
        Task<ExecuteReportResult> ExecuteReport(Report report, Dictionary<string, object> parameters);
    }
}
