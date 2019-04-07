using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using RReporter.Application.Domain;
using RReporter.Application.ReportWorkSummary;
using RReporter.Application.ReportWorkSummary.Depends;

namespace RReporter.Application.ReportWorkSummary
{
    [TestFixture]
    public class WorkSummaryQueriesTest
    {
        [Test]
        [TestCaseSource (nameof (TestCases))]
        public async Task GivenStoredWorkEventsCalculateWorkSummary (
            IEnumerable<Pupil> pupilsInClass,
            IEnumerable<WorkEvent> workEvents,
            DateTime now
        )
        {
            // arrange
            var pupilsInClassStoreMock = new Mock<IGetPupilsInClass> ();
            pupilsInClassStoreMock
                .Setup (m => m.GetPupilsInClassAsync (It.IsAny<int> ()))
                .ReturnsAsync (pupilsInClass);
            var dayWorkEventsForPupilStoreMock = new Mock<IGetDayWorkEventsForPupil> ();
            dayWorkEventsForPupilStoreMock
                .Setup (m => m.GetDayWorkEventsForPupilAsync (It.IsAny<int> (), It.IsAny<DateTime> ()))
                .Returns<int, DateTime> ((uid, dt) => Task.FromResult (workEvents.Where (e => e.UserId == uid)));
            var queriesUnderTest = new WorkSummaryQueries (
                dayWorkEventsForPupilStoreMock.Object,
                pupilsInClassStoreMock.Object
            );

            // act
            var queryResult = await queriesUnderTest.GetDaySummaryAtTimeAsync (10, now);

            // assert
            queryResult.Timestamp.Should ().Be (now);
            queryResult.PupilSummaries.Count ().Should ().Be (pupilsInClass.Count ());
        }

        public static object[] TestCases
        {
            get
            {
                var ex1 = new Exercise (1, new ExerciseClassification ("1", "1", "1"), 100);
                var now = DateTime.Parse ("2010-01-01 10:00");

                return new object[]
                {
                    new object[]
                        {
                            new Pupil[]
                                {
                                    new Pupil (1, "name1"),
                                        new Pupil (2, "name2")
                                },
                                new WorkEvent[]
                                {
                                    WorkEvent.Create (id: 1, submittedAt: now, userId: 1, exercise: ex1, correct: 1, progress: 100),
                                        WorkEvent.Create (id: 2, submittedAt: now, userId: 2, exercise: ex1, correct: 1, progress: 100),
                                },
                                now
                        },
                        new object[]
                        {
                            new Pupil[]
                                {
                                    new Pupil (1, "name1"),
                                        new Pupil (2, "name2")
                                },
                                new WorkEvent[]
                                {
                                    WorkEvent.Create (id: 1, submittedAt: now, userId: 1, exercise: ex1, correct: 1, progress: 100),
                                },
                                now
                        },
                        new object[]
                        {
                            new Pupil[]
                                {
                                    new Pupil (1, "name1"),
                                        new Pupil (2, "name2")
                                },
                                new WorkEvent[]
                                {
                                    WorkEvent.Create (id: 1, submittedAt: now, userId: 1, exercise: ex1, correct: 1, progress: 100),
                                        WorkEvent.Create (id: 2, submittedAt: now, userId: 2, exercise: ex1, correct: 1, progress: 100),
                                        WorkEvent.Create (id: 3, submittedAt: now, userId: 3, exercise: ex1, correct: 1, progress: 100),
                                },
                                now
                        }
                };
            }
        }
    }

}