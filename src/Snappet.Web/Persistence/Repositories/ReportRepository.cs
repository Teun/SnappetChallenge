using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Snappet.Web.Persistence.Models;

namespace Snappet.Web.Persistence.Repositories
{
    public class ReportRepository : IReportRepository
    {
        private SnappetDbContext context;

        public ReportRepository(SnappetDbContext context)
        {
            this.context = context;
        }

        public Task<List<Report>> GetReportsAsync()
        {
            return context.Reports.ToListAsync();
        }

        public Task<Report> GetReportByIdAsync(int id)
        {
            return context.Reports.FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}