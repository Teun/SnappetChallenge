using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Snappet.Models;

namespace Snappet.Services
{
    public interface IWorkResultService
    {
        IList<WorkResult> GetResults();
        IList<WorkResult> GetResults(DateTime startDate, DateTime endDate);
    }
}
