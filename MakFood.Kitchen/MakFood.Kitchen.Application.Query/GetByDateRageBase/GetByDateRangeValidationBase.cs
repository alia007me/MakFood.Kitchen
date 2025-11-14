using FluentValidation;

namespace MakFood.Kitchen.Application.Query.GetByDateRageBase
{
    public class GetByDateRangeValidationBase : AbstractValidator<GetByDateRangeQueryBase>
    {
        public GetByDateRangeValidationBase()
        {
            RuleFor(x => x.FromDate).NotEmpty().WithMessage("FromDate Can Not Be empty").NotNull().WithMessage("FromDate Can Not Be empty");
            RuleFor(x => x.ToDate).NotEmpty().WithMessage("ToDate Can Not Be empty").NotNull().WithMessage("ToDate Can Not Be empty");
        }
    }
}
