using System;
using System.Threading.Tasks;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using RReporter.Application.Domain;
using RReporter.Application.StoreWorkEvent;
using RReporter.Application.StoreWorkEvent.Depends;

namespace RReporter.Application.StoreWorkEvent
{
    [TestFixture]
    public class WorkEventHandlerTest
    {
        [Test]
        [TestCaseSource (nameof (TestCases))]
        public async Task WhenWorkEventDtoIsHandledWorkEventIsStored (WorkEventDto workEventDto, WorkEvent storedWorkEvent)
        {
            // arrange
            var storageMock = new Mock<IStoreWorkEvents> ();
            storageMock
                .Setup (storage => storage.StoreAsync (It.IsAny<WorkEvent> ()))
                // assert in the callback
                .Callback<WorkEvent> (e => e.Should ().BeEquivalentTo (storedWorkEvent))
                .Returns (Task.CompletedTask);
            var handlerUnderTest = new WorkEventHandler (storageMock.Object);

            // act
            await handlerUnderTest.HandleAsync (workEventDto);

            // assert
            storageMock.Verify (storage => storage.StoreAsync (It.IsAny<WorkEvent> ()), Times.Once);
        }

        public static object[] TestCases
        {
            get
            {
                var exClassA = new ExerciseClassification ("a", "a", "a");
                var exClassB = new ExerciseClassification ("b", "b", "b");

                return new []
                {
                    new object[]
                        {
                            new WorkEventDto
                            {
                                SubmittedAnswerId = 6632025,
                                    SubmitDateTime = DateTime.Parse ("2015-03-03T08:16:55.900"),
                                    Correct = 0,
                                    Progress = 0,
                                    UserId = 40285,
                                    ExerciseId = 361830,
                                    Difficulty = "NULL",
                                    Subject = "a",
                                    Domain = "a",
                                    LearningObjective = "a"
                            },
                            WorkEvent.Create (
                                6632025, DateTime.Parse ("2015-03-03T08:16:55.900"), 40285,
                                new Exercise (361830, exClassA, null), 0, 0
                            )
                        },
                        new object[]
                        {
                            new WorkEventDto
                            {
                                SubmittedAnswerId = 6631989,
                                    SubmitDateTime = DateTime.Parse ("2015-03-03T08:16:56.113"),
                                    Correct = 1,
                                    Progress = 2,
                                    UserId = 40276,
                                    ExerciseId = 407108,
                                    Difficulty = "263.0050573",
                                    Subject = "b",
                                    Domain = "b",
                                    LearningObjective = "b"
                            },
                            WorkEvent.Create (
                                6631989, DateTime.Parse ("2015-03-03T08:16:56.113"), 40276,
                                new Exercise (407108, exClassB, 263.0050573), 1, 2
                            )
                        }
                };
            }
        }
    }
}