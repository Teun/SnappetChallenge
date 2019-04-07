using System;
using System.Globalization;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using RReporter.Application.StoreWorkEvent;
using RReporter.Framework;

namespace RReporter.Framework
{
    public class WorkEventEmitterTests
    {
        [Test]
        public async Task WhenAllWorkIsEmittedThenAtLeastOneEventIsEmitted ()
        {
            // arrange
            var handlerMock = new Mock<IWorkEventHandler> ();
            var workEmitter = new WorkEventEmitter (handlerMock.Object);

            // act
            await workEmitter.EmitAllEventsAsync (DateTime.UtcNow.AddDays(1)); // assuming there are no events from the "real" future

            // assert
            handlerMock.Verify (h => h.HandleAsync (It.IsAny<WorkEventDto> ()), Times.Exactly (37812));
        }

        [Test]
        [TestCase("2015-03-01T00:00:00.000Z", 0)]
        [TestCase("2015-03-02T07:35:38.740Z", 1)]
        [TestCase("2015-03-30T10:50:15.823Z", 37812)]
        [TestCase("2019-03-30T10:50:15.823Z", 37812)]
        public async Task WhenWorkIsEmittedThenAtLeastOneEventIsEmitted (string dtString, int expectedNumber)
        {
            // arrange
            var handlerMock = new Mock<IWorkEventHandler> ();
            var workEmitter = new WorkEventEmitter (handlerMock.Object);

            // act
            var dt = DateTime.Parse(dtString, CultureInfo.InvariantCulture, DateTimeStyles.AdjustToUniversal | DateTimeStyles.AssumeUniversal);
            await workEmitter.EmitEventsUntilAsync (dt); 

            // assert
            handlerMock.Verify (h => h.HandleAsync (It.IsAny<WorkEventDto> ()), Times.Exactly (expectedNumber));
        }
    }
}