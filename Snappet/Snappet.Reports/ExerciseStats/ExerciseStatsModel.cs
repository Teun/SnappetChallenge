using System.Collections.Generic;

namespace Snappet.Reports.ExerciseStats
{
    public class ExerciseStatsModel<TGroupLevel> : ReportModel<ExerciseStatsParameters>
    {
        public IList<TGroupLevel> ExerciseStats { get; set; }
    }
}