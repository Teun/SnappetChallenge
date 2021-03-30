using FluentValidation;

namespace Service.Students.GetStudentOverviewByUserId
{
    public class GetStudentOverviewByUserIdServiceRequestValidator : AbstractValidator<
        GetStudentOverviewByUserIdServiceRequest>
    {
        public GetStudentOverviewByUserIdServiceRequestValidator()
        {
            RuleFor(r => r.UserId)
                .GreaterThan(0)
                .WithMessage(r => $"{nameof(r.UserId)}_should_be_greater_than_zero");
        }
    }
}
