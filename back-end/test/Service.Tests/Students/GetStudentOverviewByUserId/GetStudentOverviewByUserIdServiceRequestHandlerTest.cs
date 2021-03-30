using Data.Students.GetStudentOverviewByUserId;
using MediatR;
using Moq;
using Sdk.Core.Entities;
using Sdk.Core.Exceptions;
using Service.Students.GetStudentOverviewByUserId;
using Service.Utils;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Service.Tests.Students.GetStudentOverviewByUserId
{
    public class GetStudentOverviewByUserIdServiceRequestHandlerTest
    {
        private readonly Mock<IMediator> _mockMediator;

        public GetStudentOverviewByUserIdServiceRequestHandlerTest()
        {
            _mockMediator = new Mock<IMediator>();
        }

        [Fact]
        public async Task Handle_WithNoRecord_ThrowsException()
        {
            // Arrange         
            _mockMediator
                .Setup(m => m.Send(It.IsAny<GetStudentOverviewByUserIdDataRequest>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new GetStudentOverviewByUserIdDataResponse
                {
                    Items = new List<StudentOverviewEntity>()
                });

            var request = new GetStudentOverviewByUserIdServiceRequest();
            var handler = new GetStudentOverviewByUserIdServiceRequestHandler(_mockMediator.Object);

            // Action          
            var exception = await Assert.ThrowsAsync<CustomException>(async () =>
                await handler.Handle(request, CancellationToken.None));

            // Assert
            Assert.True(exception.Message == TranslationKeys.Students.NoRecordFoundForStudentOverview);
        }


        [Fact]
        public async Task Handle_HappyPath_ReturnsRecords()
        {
            // Arrange                       
            _mockMediator
                 .Setup(m => m.Send(It.IsAny<GetStudentOverviewByUserIdDataRequest>(), It.IsAny<CancellationToken>()))
                 .ReturnsAsync(new GetStudentOverviewByUserIdDataResponse
                 {
                     Items = new List<StudentOverviewEntity>
                     {
                         new StudentOverviewEntity()
                     }
                 });

            var request = new GetStudentOverviewByUserIdServiceRequest();
            var handler = new GetStudentOverviewByUserIdServiceRequestHandler(_mockMediator.Object);

            // Action          
            var result = await handler.Handle(request, CancellationToken.None);

            // Assert
            Assert.IsAssignableFrom<GetStudentOverviewByUserIdServiceResponse>(result);
            Assert.NotEmpty(result.Items);
        }
    }
}
