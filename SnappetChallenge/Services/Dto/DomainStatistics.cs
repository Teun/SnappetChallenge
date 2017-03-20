using System.Collections.Generic;

namespace Services.Dto
{
    public class DomainStatistics
    {
        public string Name { get; set; }

        public IReadOnlyCollection<LearningObjectiveStatistics> LearningObjectives { get; set; }
    }
}
