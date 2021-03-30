using FluentValidation;

namespace Data.Students.GetStudentOverviewByUserId
{
    public class GetStudentOverviewByUserIdDataRequestValidator : AbstractValidator<
        GetStudentOverviewByUserIdDataRequest>
    {
        public GetStudentOverviewByUserIdDataRequestValidator()
        {
            RuleFor(r => r.UserId)
                .GreaterThan(0)
                .WithMessage(r => $"{nameof(r.UserId)}_should_be_greater_than_zero");
        }
    }
}
