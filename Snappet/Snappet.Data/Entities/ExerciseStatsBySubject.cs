using System.Collections.Generic;

namespace Snappet.Data.Entities
{
    public class ExerciseStatsBySubject : ExerciseStatsByAggregate<LearningSubject>
    {
        public IList<LearningObjectiveStats> LearningObjectiveStats { get; set; }
    }
}