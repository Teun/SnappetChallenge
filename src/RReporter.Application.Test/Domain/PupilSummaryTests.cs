using System.Collections.Generic;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using RReporter.Application.Domain;

namespace RReporter.Application.Domain
{
    [TestFixture]
    public class PupilSummaryTests
    {

        [Test]
        [TestCaseSource (nameof (TestCases))]
        public void GivenWorkEventsCalculatePupilSummary (Pupil pupil, IEnumerable<WorkEvent> workEvents, int expectNumberOfLearningObjectives)
        {
            var summary = PupilSummary.CreateFromWorkEvents (pupil, workEvents);

            summary.LearningObjectiveSummaries.Length.Should ().Be (expectNumberOfLearningObjectives);
            summary.UserId.Should ().Be (pupil.UserId);
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
                            new Pupil (1, "name1"),
                                new WorkEvent[]
                                {
                                    WorkEvent.CreateNew (1, a, correct : 1, progress : 2),
                                        WorkEvent.CreateNew (1, a, correct : 3, progress : 3),
                                        WorkEvent.CreateNew (1, a, correct : 1, progress : 4),
                                        WorkEvent.CreateNew (1, a, correct : 1, progress : 5),
                                },
                                1
                        },
                        new object[]
                        {
                            new Pupil (2, "name2"),
                                new WorkEvent[]
                                {
                                    WorkEvent.CreateNew (1, a, correct : 1, progress : 2),
                                        WorkEvent.CreateNew (1, a, correct : 3, progress : 3),
                                        WorkEvent.CreateNew (1, b, correct : 1, progress : 4),
                                        WorkEvent.CreateNew (1, b, correct : 1, progress : 5),
                                },
                                0
                        },
                        new object[]
                        {
                            new Pupil (1, "name1"),
                                new WorkEvent[]
                                {
                                    WorkEvent.CreateNew (1, a, correct : 1, progress : 2),
                                        WorkEvent.CreateNew (1, a, correct : 3, progress : 3),
                                        WorkEvent.CreateNew (1, b, correct : 1, progress : 4),
                                        WorkEvent.CreateNew (1, b, correct : 1, progress : 5),
                                },
                                2
                        },
                        new object[]
                        {
                            new Pupil (2, "name2"),
                                new WorkEvent[]
                                {
                                    WorkEvent.CreateNew (1, a, correct : 1, progress : 2),
                                        WorkEvent.CreateNew (2, a, correct : 3, progress : 3),
                                        WorkEvent.CreateNew (1, b, correct : 1, progress : 4),
                                        WorkEvent.CreateNew (2, b, correct : 1, progress : 5),
                                },
                                2
                        }
                };
            }
        }
    }

}