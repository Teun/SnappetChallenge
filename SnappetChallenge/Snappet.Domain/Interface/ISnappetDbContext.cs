using Snappet.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snappet.Domain.Interface
{
    public class ISnappetDbContext
    {
        public IEnumerable<ExerciseReportModel> ExerciseReports { get; init; }
    }
}
