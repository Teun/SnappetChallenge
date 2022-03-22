using FluentValidation;
using Snappet.API.ViewModels;
using Snappet.Domain.Interface.Service;

namespace Snappet.API.Validators
{
    public class DailyReportRequestValidator : AbstractValidator<DailyReportRequest>
    {
        public DailyReportRequestValidator(IDateService dateService)
        {
            RuleFor(i => i.Date)
                .Cascade(CascadeMode.Stop)
                .NotNull().WithMessage("Date is required")
                .NotEmpty().WithMessage("Date is required")
                .LessThanOrEqualTo(dateService.GetCurrentDateUTC()).WithMessage("Date cannot be in future");
        }
    }
}
