using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using NUnit.Framework;

namespace RReporter.Application.Domain
{
    [TestFixture]
    public class LearningObjectiveSummaryTests
    {
        [Test]
        [TestCaseSource (nameof (TestCases))]
        public void GivenWorkEventsCalculateLearningObjectSummary (IEnumerable<WorkEvent> workEvents, IEnumerable<LearningObjectiveSummary> expectSummaries)
        {
            var summaries = LearningObjectiveSummary.CreateFromWorkEvents (workEvents);

            summaries.Should ().BeEquivalentTo (expectSummaries);
        }

        public static object[] TestCases
        {
            get
            {
                Exercise a = new Exercise (1, new ExerciseClassification ("a", "a", "a"), 1);
                Exercise b = new Exercise (2, new ExerciseClassification ("b", "b", "b"), 5);

                return new []
                {
                    new object[]
                        {
                            new WorkEvent[]
                                {
                                    WorkEvent.CreateNew (1, a, correct : 1, progress : 2),
                                        WorkEvent.CreateNew (1, a, correct : 3, progress : 3),
                                        WorkEvent.CreateNew (1, a, correct : 1, progress : 4),
                                        WorkEvent.CreateNew (1, a, correct : 1, progress : 5),
                                },
                                new LearningObjectiveSummary[]
                                {
                                    LearningObjectiveSummary.CreateNew (
                                        classification: a.Classification,
                                        numberOfAnswers: 4,
                                        correctPercentage: 1,
                                        totalProgress: 14,
                                        maxDifficulty: 1,
                                        minDifficulty: 1
                                    )
                                }
                        },
                        new object[]
                        {
                            new WorkEvent[]
                                {
                                    WorkEvent.CreateNew (1, a, correct : 1, progress : 2),
                                        WorkEvent.CreateNew (1, a, correct : 3, progress : 3),
                                        WorkEvent.CreateNew (1, b, correct : 1, progress : 4),
                                        WorkEvent.CreateNew (1, b, correct : 1, progress : 5),
                                },
                                new LearningObjectiveSummary[]
                                {
                                    LearningObjectiveSummary.CreateNew (
                                            classification: a.Classification,
                                            numberOfAnswers: 2,
                                            correctPercentage: 1,
                                            totalProgress: 5,
                                            maxDifficulty: 1,
                                            minDifficulty: 1
                                        ),
                                        LearningObjectiveSummary.CreateNew (
                                            classification: b.Classification,
                                            numberOfAnswers: 2,
                                            correctPercentage: 1,
                                            totalProgress: 9,
                                            maxDifficulty: 5,
                                            minDifficulty: 5
                                        )
                                }
                        },
                        new object[]
                        {
                            new WorkEvent[]
                                {
                                    WorkEvent.CreateNew (1, a, correct : 1, progress : 2),
                                        WorkEvent.CreateNew (2, a, correct : 3, progress : 3),
                                        WorkEvent.CreateNew (1, b, correct : 1, progress : 4),
                                        WorkEvent.CreateNew (2, b, correct : 1, progress : 5),
                                },
                                new LearningObjectiveSummary[]
                                {
                                    LearningObjectiveSummary.CreateNew (
                                            classification: a.Classification,
                                            numberOfAnswers: 2,
                                            correctPercentage: 1,
                                            totalProgress: 5,
                                            maxDifficulty: 1,
                                            minDifficulty: 1
                                        ),
                                        LearningObjectiveSummary.CreateNew (
                                            classification: b.Classification,
                                            numberOfAnswers: 2,
                                            correctPercentage: 1,
                                            totalProgress: 9,
                                            maxDifficulty: 5,
                                            minDifficulty: 5
                                        )
                                }
                        }
                };
            }
        }
    }
}