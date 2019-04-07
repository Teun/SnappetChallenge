using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FluentAssertions;
using NUnit.Framework;
using RReporter.Application.Domain;
using RReporter.Framework;

namespace RReporter.Framework
{
    public class MemoryWorkEventStorageTests
    {
        [Test]
        [TestCaseSource (nameof (TestCases))]
        public async Task WhenStoredAnEventWillBeRetrieved (WorkEvent workEvent)
        {
            // arrange
            var storageUnderTest = new MemoryWorkEventStorage ();

            // act
            await storageUnderTest.StoreAsync (workEvent);
            IEnumerable<WorkEvent> readEvents = await storageUnderTest.GetDayWorkEventsForPupilAsync (
                workEvent.UserId, workEvent.SubmitDateTime + TimeSpan.FromMinutes (1)
            );

            // assert
            readEvents.Should ().Contain (ev => ev.SubmittedAnswerId == workEvent.SubmittedAnswerId);
        }

        [Test]
        [TestCaseSource (nameof (TestCases))]
        public async Task WhenStoredAnEventWillNotBeRetrievedForAnotherDay (WorkEvent workEvent)
        {
            // arrange
            var storageUnderTest = new MemoryWorkEventStorage ();

            // act
            await storageUnderTest.StoreAsync (workEvent);
            IEnumerable<WorkEvent> readEvents = await storageUnderTest.GetDayWorkEventsForPupilAsync (
                workEvent.UserId, workEvent.SubmitDateTime + TimeSpan.FromDays (1)
            );

            // assert
            readEvents.Should ().NotContain (ev => ev.SubmittedAnswerId == workEvent.SubmittedAnswerId);
        }

        [Test]
        [TestCaseSource (nameof (TestCases))]
        public async Task WhenStoredAnEventWillNotBeRetrievedForADifferentUser (WorkEvent workEvent)
        {
            // arrange
            var storageUnderTest = new MemoryWorkEventStorage ();

            // act
            await storageUnderTest.StoreAsync (workEvent);
            IEnumerable<WorkEvent> readEvents = await storageUnderTest.GetDayWorkEventsForPupilAsync (
                workEvent.UserId + 1, workEvent.SubmitDateTime + TimeSpan.FromMinutes (1)
            );

            // assert
            readEvents.Should ().NotContain (ev => ev.SubmittedAnswerId == workEvent.SubmittedAnswerId);
        }

        public static object[] TestCases
        {
            get
            {
                var exClassA = new ExerciseClassification ("Rekenen", "Getallen", "Vermenigvuldigen 8 x 32");
                var exClassB = new ExerciseClassification ("Rekenen", "Getallen", "Getallenrij");
                return new object[]
                {
                    WorkEvent.Create (6632025, DateTime.Parse ("2015-03-03T08:16:55.900"), 40285,
                            new Exercise (361830, exClassA, null), 0, 0
                        ),
                        WorkEvent.Create (6631989, DateTime.Parse ("2015-03-03T08:16:56.113"), 40276,
                            new Exercise (407108, exClassA, null), 0, 0
                        ),
                };
            }
        }
    }
}