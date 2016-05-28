using System.Collections.Generic;

namespace Snappet.Challenge.Services.Dto
{
    public class LearningObjectiveStatisticsDto
    {
        public string LearningObjective { get; set; }
        public IEnumerable<DailyClassStatisticsDto> DailyStatistics { get; set; }
    }
}
