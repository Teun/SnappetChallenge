using Data.Teachers.GetTeacherDashboard;
using MediatR;
using Sdk.Core.Exceptions;
using Service.Teachers.Models;
using Service.Utils;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace Service.Teachers.GetTeacherDashboard
{
    public class GetTeacherDashboardServiceRequestHandler : IRequestHandler<GetTeacherDashboardServiceRequest, GetTeacherDashboardServiceResponse>
    {
        private readonly IMediator _mediator;

        public GetTeacherDashboardServiceRequestHandler(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<GetTeacherDashboardServiceResponse> Handle(GetTeacherDashboardServiceRequest request, CancellationToken cancellationToken)
        {
            var dashboardResponse = await _mediator.Send(new GetTeacherDashboardDataRequest(), cancellationToken);

            if (dashboardResponse.Items.Count < 1)
                throw new CustomException(TranslationKeys.Teachers.NoRecordFoundForTeacherDashboard, HttpStatusCode.NotFound);

            return new GetTeacherDashboardServiceResponse
            {
                Items = dashboardResponse.Items.Select(d => new DashboardModel
                {
                    Subject = d.Subject,
                    Domain = d.Domain,
                    LearningObjective = d.LearningObjective,
                    AnswerCount = d.AnswerCount,
                    SubmitDateTime = d.SubmitDateTime.ToString("yyyy-MM-dd")
                })
                .ToList()
            };
        }
    }
}
