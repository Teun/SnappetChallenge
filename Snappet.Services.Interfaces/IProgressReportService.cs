using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Snappet.Entities.Interfaces;

namespace Snappet.Services.Interfaces
{
    public interface IProgressReportService
    {
	    IEnumerable<IDailyReport> GetDailyProgressBefore(DateTime before);
    }
}
