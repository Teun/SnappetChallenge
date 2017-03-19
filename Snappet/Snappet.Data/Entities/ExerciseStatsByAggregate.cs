using System.Collections.Generic;

namespace Snappet.Data.Entities
{
    public abstract class ExerciseStatsByAggregate<TAggregate>
    {
        public TAggregate Aggregate { get; set; }
        public double AverageExerciseCount { get; set; }
        public double AverageExerciseInCorrect { get; set; }
        public IList<SingleExerciseStats> TopInCorrectExercises { get; set; }
        public IList<UserStats> NegativeProgressUserStats { get; set; }
    }
}
