using Data.Teachers.GetTeacherDashboard;
using MediatR;
using Moq;
using Sdk.Core.Entities;
using Sdk.Core.Exceptions;
using Service.Teachers.GetTeacherDashboard;
using Service.Utils;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Service.Tests.Teachers.GetTeacherDashboard
{
    public class GetTeacherDashboardServiceRequestHandlerTest
    {
        private readonly Mock<IMediator> _mockMediator;

        public GetTeacherDashboardServiceRequestHandlerTest()
        {
            _mockMediator = new Mock<IMediator>();
        }

        [Fact]
        public async Task Handle_WithNoRecord_ThrowsException()
        {
            // Arrange         
            _mockMediator
                .Setup(m => m.Send(It.IsAny<GetTeacherDashboardDataRequest>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new GetTeacherDashboardDataResponse
                {
                    Items = new List<DashboardEntity>()
                });

            var request = new GetTeacherDashboardServiceRequest();
            var handler = new GetTeacherDashboardServiceRequestHandler(_mockMediator.Object);

            // Action          
            var exception = await Assert.ThrowsAsync<CustomException>(async () =>
                await handler.Handle(request, CancellationToken.None));

            // Assert
            Assert.True(exception.Message == TranslationKeys.Teachers.NoRecordFoundForTeacherDashboard);
        }


        [Fact]
        public async Task Handle_HappyPath_ReturnsRecords()
        {
            // Arrange                       
            _mockMediator
                .Setup(m => m.Send(It.IsAny<GetTeacherDashboardDataRequest>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new GetTeacherDashboardDataResponse
                {
                    Items = new List<DashboardEntity>
                    {
                        new DashboardEntity
                        {

                        }
                    }
                });

            var request = new GetTeacherDashboardServiceRequest();
            var handler = new GetTeacherDashboardServiceRequestHandler(_mockMediator.Object);

            // Action          
            var result = await handler.Handle(request, CancellationToken.None);

            // Assert
            Assert.IsAssignableFrom<GetTeacherDashboardServiceResponse>(result);
            Assert.NotEmpty(result.Items);
        }
    }
}
