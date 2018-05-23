using AutoMapper;
using FluentValidation;
using MediatR;
using SnappetChallenge.Application.Requests;
using SnappetChallenge.Application.Responses;
using SnappetChallenge.Core.Repositories.Contracts;
using SnappetChallenge.CrossCutting;
using SnappetChallenge.CrossCutting.Models;
using SnappetChallenge.Infrastructure.Models;
using System.Threading;
using System.Threading.Tasks;

namespace SnappetChallenge.Application.Interactors
{
    public class GetWorksForDateInteractor : IRequestHandler<GetWorksForDateRequest, Envelope<GetWorksForDateResponse>>
    {
        private readonly IWorkRepository _workRepository;
        private readonly IValidator<GetWorksForDateRequest> _validator;
        private readonly IMapper _mapper;
        public GetWorksForDateInteractor(IWorkRepository workRepository, IValidator<GetWorksForDateRequest> validator, IMapper mapper)
        {
            _workRepository = workRepository;
            _validator = validator;
            _mapper = mapper;
        }

        public async Task<Envelope<GetWorksForDateResponse>> Handle(GetWorksForDateRequest request, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(request);
            if (!validationResult.IsValid)
                return Envelope<GetWorksForDateResponse>.Error(validationResult.Errors.ToErrors());

            var works = _workRepository.Get(request.InitialDate, request.FinalDate);
            var worksDto = _mapper.Map<WorksDTO>(works);

            return Envelope<GetWorksForDateResponse>.Success(new GetWorksForDateResponse(worksDto));
        }
    }
}
