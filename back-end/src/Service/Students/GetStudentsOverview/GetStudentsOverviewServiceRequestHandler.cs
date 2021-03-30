using Data.Students.GetStudentsOverview;
using MediatR;
using Sdk.Core.Exceptions;
using Service.Students.Models;
using Service.Utils;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace Service.Students.GetStudentsOverview
{
    public class GetStudentsOverviewServiceRequestHandler : IRequestHandler<GetStudentsOverviewServiceRequest, GetStudentsOverviewServiceResponse>
    {
        private readonly IMediator _mediator;

        public GetStudentsOverviewServiceRequestHandler(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<GetStudentsOverviewServiceResponse> Handle(GetStudentsOverviewServiceRequest request, CancellationToken cancellationToken)
        {
            var overviewResponse = await _mediator.Send(new GetStudentsOverviewDataRequest(), cancellationToken);

            if (overviewResponse.Items.Count < 1)
                throw new CustomException(TranslationKeys.Students.NoRecordFoundForStudentsOverview, HttpStatusCode.NotFound);

            return new GetStudentsOverviewServiceResponse
            {
                Items = overviewResponse.Items.Select(o => new StudentOverviewModel
                {
                    UserId = o.UserId,
                    Subject = o.Subject,
                    AnswerCount = o.AnswerCount,
                    Min = o.Min,
                    Mean = o.Mean,
                    High = o.High
                })
                .ToList()
            };
        }
    }
}
