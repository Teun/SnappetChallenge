using FluentValidation;
using MediatR;
using SnappetChallenge.Application.Responses;
using SnappetChallenge.CrossCutting.Models;
using System;

namespace SnappetChallenge.Application.Requests
{
    public class GetWorksForDateRequest : IRequest<Envelope<GetWorksForDateResponse>>
    {
        public DateTime InitialDate { get; set; }
        public DateTime FinalDate { get; set; }
    }

    public class GetWorksForDateRequestValidator : AbstractValidator<GetWorksForDateRequest>
    {
        public GetWorksForDateRequestValidator()
        {
            RuleFor(x => x.InitialDate).LessThan(x => x.FinalDate).WithMessage("The initial date could not be bigger than final date.");
            RuleFor(x => x.FinalDate).GreaterThan(x => x.InitialDate).WithMessage("The final date could not be less than initial date.");
        }
    }
}
