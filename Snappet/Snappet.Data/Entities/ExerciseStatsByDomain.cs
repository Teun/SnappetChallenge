using System.Collections.Generic;

namespace Snappet.Data.Entities
{
    public class ExerciseStatsByDomain : ExerciseStatsByAggregate<LearningDomain>
    {
        public IList<LearningSubjectStats> LearningSubjectStats { get; set; }
    }
}
