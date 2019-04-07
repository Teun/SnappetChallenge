using System;
using System.Collections.Generic;
using System.Linq;

namespace RReporter.Application.Domain
{
    public class LearningObjectiveSummary
    {
        public static IEnumerable<LearningObjectiveSummary> CreateFromWorkEvents (IEnumerable<WorkEvent> workEvents)
        {
            return workEvents
                .GroupBy (e => e.Exercise.Classification)
                .Select (g =>
                {
                    int numAnswers = g.Count ();
                    int numCorrect = g.Where (e => e.Correct != 0).Count ();
                    // NOTE: some "correct" values are 3, don't know what that means.
                    // For now, assume that correctness != 0 means the answer is correct.

                    return new LearningObjectiveSummary
                    {
                        Classification = g.Key,
                            NumberOfAnswers = g.Count (),
                            CorrectPercentage = (double) numCorrect / numAnswers,
                            TotalProgress = g.Sum (e => e.Progress),
                            MaxDifficulty =
                            // this equivalent to Max(), but it is able to cope with null values and empty list.
                            // if either of these occur, MaxDifficulty is null.
                            g.Select (e => e.Exercise.Difficulty).Aggregate (
                                (double?) null, (a, b) => !a.HasValue ? b : !b.HasValue ? a : a > b ? a : b
                            ),
                            MinDifficulty =
                            // this equivalent to Min(), but it is able to cope with null values and empty list.
                            // if either of these occur, MaxDifficulty is null.
                            g.Select (e => e.Exercise.Difficulty).Aggregate (
                                (double?) null, (a, b) => !a.HasValue ? b : !b.HasValue ? a : a < b ? a : b
                            )
                    };
                });
        }

        public static LearningObjectiveSummary CreateNew (
            ExerciseClassification classification,
            int numberOfAnswers, double correctPercentage,
            int totalProgress, double? maxDifficulty, double? minDifficulty)
        {
            return new LearningObjectiveSummary
            {
                Classification = classification,
                    NumberOfAnswers = numberOfAnswers,
                    CorrectPercentage = correctPercentage,
                    TotalProgress = totalProgress,
                    MaxDifficulty = maxDifficulty,
                    MinDifficulty = minDifficulty
            };
        }
        public ExerciseClassification Classification;

        public int NumberOfAnswers { get; private set; }

        public double CorrectPercentage { get; private set; }

        public int TotalProgress { get; private set; }

        public double? MaxDifficulty { get; private set; }

        public double? MinDifficulty { get; private set; }

    }
}