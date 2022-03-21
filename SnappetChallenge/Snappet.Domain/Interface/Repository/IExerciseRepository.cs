using Snappet.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snappet.Domain.Interface.Repository
{
    public interface IExerciseRepository
    {
        public IEnumerable<ExerciseReportModel> GetDailyReport(DateOnly date);

    }
}
