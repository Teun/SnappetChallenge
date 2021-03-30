using Data.Students.GetStudentsOverview;
using MediatR;
using Moq;
using Sdk.Core.Entities;
using Sdk.Core.Exceptions;
using Service.Students.GetStudentsOverview;
using Service.Utils;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Service.Tests.Students.GetStudentsOverview
{
    public class GetStudentsOverviewServiceRequestHandlerTest
    {
        private readonly Mock<IMediator> _mockMediator;

        public GetStudentsOverviewServiceRequestHandlerTest()
        {
            _mockMediator = new Mock<IMediator>();
        }

        [Fact]
        public async Task Handle_WithNoRecord_ThrowsException()
        {
            // Arrange         
            _mockMediator
                .Setup(m => m.Send(It.IsAny<GetStudentsOverviewDataRequest>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new GetStudentsOverviewDataResponse
                {
                    Items = new List<StudentOverviewEntity>()
                });

            var request = new GetStudentsOverviewServiceRequest();
            var handler = new GetStudentsOverviewServiceRequestHandler(_mockMediator.Object);

            // Action          
            var exception = await Assert.ThrowsAsync<CustomException>(async () =>
                await handler.Handle(request, CancellationToken.None));

            // Assert
            Assert.True(exception.Message == TranslationKeys.Students.NoRecordFoundForStudentsOverview);
        }


        [Fact]
        public async Task Handle_HappyPath_ReturnsRecords()
        {
            // Arrange                       
            _mockMediator
                 .Setup(m => m.Send(It.IsAny<GetStudentsOverviewDataRequest>(), It.IsAny<CancellationToken>()))
                 .ReturnsAsync(new GetStudentsOverviewDataResponse
                 {
                     Items = new List<StudentOverviewEntity>
                     {
                         new StudentOverviewEntity()
                     }
                 });

            var request = new GetStudentsOverviewServiceRequest();
            var handler = new GetStudentsOverviewServiceRequestHandler(_mockMediator.Object);

            // Action          
            var result = await handler.Handle(request, CancellationToken.None);

            // Assert
            Assert.IsAssignableFrom<GetStudentsOverviewServiceResponse>(result);
            Assert.NotEmpty(result.Items);
        }
    }
}
