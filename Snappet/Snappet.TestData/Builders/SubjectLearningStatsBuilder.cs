using Snappet.Data.Entities;
using Snappet.TestData.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Snappet.TestData.Builders
{
    internal class SubjectLearningStatsBuilder : EntityBuilder<ExerciseRecord, ExerciseStatsBySubject>, IEntityBuilder
    {
        private const int IncorrectExerciseLimit = 5; // could be a report parameter

        public override IList<ExerciseStatsBySubject> BuildEntities(IEnumerable<ExerciseRecord> records)
        {
            var groupedRecords = records.GroupBy((t) => new { t.Domain, t.Subject });

            var aggregatedStatsList = new List<ExerciseStatsBySubject>();
            foreach (var groupedRecord in groupedRecords)
            {
                var learningSubject = new LearningSubject
                {
                    Name = groupedRecord.Key.Subject,
                    LearningDomain = new LearningDomain { Name = groupedRecord.Key.Domain }
                };

                var learningObjectiveStats = new ExerciseStatsBySubject
                {
                    Aggregate = learningSubject,
                    AverageExerciseCount = groupedRecord.GroupBy(r => r.UserId).Average(r => r.Count()),
                    AverageExerciseInCorrect = groupedRecord.GroupBy(r => r.UserId).Average(r => r.Count(e => e.IsInCorrect)),
                    TopInCorrectExercises = GetTopIncorrectExercises(groupedRecord),
                    NegativeProgressUserStats = GetUserStatsWithoutProgress(groupedRecord),
                    LearningObjectiveStats = GetLearningObjectiveStats(groupedRecord)
                };
                aggregatedStatsList.Add(learningObjectiveStats);
            }
            return aggregatedStatsList;
        }

        private IList<UserStats> GetUserStatsWithoutProgress(IGrouping<object, ExerciseRecord> groupedRecord)
        {
            return groupedRecord.GroupBy(r => r.UserId).Where(r => r.Sum(e => e.Progress) < 0).OrderBy(r => r.Sum(e => e.Progress))
                .Select(g => new UserStats
                {
                    User = new User { Id = g.Key },
                    ExerciseCount = g.Count(),
                    ExerciseInCorrectCount = g.Count(e => e.IsInCorrect),
                    ProgressSum = g.Sum(e => e.Progress)
                }).ToList();
        }

        private IList<SingleExerciseStats> GetTopIncorrectExercises(IGrouping<object, ExerciseRecord> groupedRecord)
        {
            return groupedRecord.GroupBy(r => r.ExerciseId).Where(r => r.Count(e => e.IsInCorrect) > 0).OrderByDescending(r => r.Count(e => e.IsInCorrect))
                .Take(IncorrectExerciseLimit).Select(
                e => new SingleExerciseStats {
                    Exercise = new Exercise { Id = e.Key },
                    ExerciseCount = e.Count(),
                    ExerciseInCorrectCount = e.Count(i => i.IsInCorrect)
                }
                ).ToList();
        }

        private IList<LearningObjectiveStats> GetLearningObjectiveStats(IGrouping<object, ExerciseRecord> groupedRecord)
        {
            return groupedRecord.GroupBy(r => r.LearningObjective).Where(r => r.Sum(e => e.Progress) < 0).OrderBy(r => r.Sum(e => e.Progress))
                .Select(g => new LearningObjectiveStats
                {
                    LearningObjective = new LearningObjective { Name = g.Key },
                    ExerciseCount = g.GroupBy(r => r.UserId).Average(r => r.Count()),
                    ExerciseInCorrectCount = g.GroupBy(r => r.UserId).Average(r => r.Count(e => e.IsInCorrect)),
                    ProgressSum = g.Sum(e => e.Progress)
                }).ToList();
        }
    }
}