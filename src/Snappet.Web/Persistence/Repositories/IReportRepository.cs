using System.Collections.Generic;
using System.Threading.Tasks;
using Snappet.Web.Persistence.Models;

namespace Snappet.Web.Persistence.Repositories
{
    public interface IReportRepository
    {
        Task<List<Report>> GetReportsAsync();

        Task<Report> GetReportByIdAsync(int id);
    }
}
