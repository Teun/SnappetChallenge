using System;
using System.Collections.Generic;
using System.Linq;
using Snappet.Data.DataObjects;

namespace Snappet.Data.Mappers
{
    public class ReportRowMapper : IReportRowMapper
    {
        public IEnumerable<ClassResultRow> MapDataToReportRow(IEnumerable<JsonData> dayResults)
        {
            if (dayResults == null)
            {
                throw new ArgumentNullException(nameof(dayResults));
            }

            var result =
                dayResults.GroupBy(c => new { c.Subject, c.LearningObjective })
                    .Select(groupedDayResult => new ClassResultRow
                    {
                        Subject = groupedDayResult.Key.Subject,
                        LearningObjective = groupedDayResult.Key.LearningObjective,
                        Count = groupedDayResult.Count(),
                        Correct = groupedDayResult.Count(x => x.Correct),
                        Incorrect = groupedDayResult.Count(x => !x.Correct),
                        PercentCorrect = CalculatePercentage(groupedDayResult.Count(x => x.Correct), groupedDayResult.Count())
                    });

            return result;
        }

        private int CalculatePercentage(int correct, int total)
        {
            return (correct *100) / total;
        }
    }
}
