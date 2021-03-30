using Data.Students.GetStudentOverviewByUserId;
using MediatR;
using Sdk.Core.Exceptions;
using Service.Students.Models;
using Service.Utils;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace Service.Students.GetStudentOverviewByUserId
{
    public class GetStudentOverviewByUserIdServiceRequestHandler : IRequestHandler<GetStudentOverviewByUserIdServiceRequest, GetStudentOverviewByUserIdServiceResponse>
    {
        private readonly IMediator _mediator;

        public GetStudentOverviewByUserIdServiceRequestHandler(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<GetStudentOverviewByUserIdServiceResponse> Handle(GetStudentOverviewByUserIdServiceRequest request, CancellationToken cancellationToken)
        {
            var overviewResponse = await _mediator.Send(new GetStudentOverviewByUserIdDataRequest
            {
                UserId = request.UserId
            }, cancellationToken);

            if (overviewResponse.Items.Count < 1)
                throw new CustomException(TranslationKeys.Students.NoRecordFoundForStudentOverview, HttpStatusCode.NotFound);

            return new GetStudentOverviewByUserIdServiceResponse
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
