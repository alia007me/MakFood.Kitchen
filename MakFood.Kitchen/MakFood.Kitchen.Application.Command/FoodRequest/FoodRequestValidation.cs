using FluentValidation;

namespace MakFood.Kitchen.Application.Command.FoodRequest
{
    public class FoodRequestValidation : AbstractValidator<FoodRequestCommand>
    {
        public FoodRequestValidation()
        {
            RuleFor(x => x.UserId).NotNull().WithMessage("UserId can not be null").NotEmpty().WithMessage("UserId can not be empty");
            RuleFor(x => x.ProductId).NotNull().WithMessage("ProductId can not be null").NotEmpty().WithMessage("ProductId can not be empty");
            RuleFor(x => x.TargetDate).NotNull().WithMessage("TargetDate can not be null").NotEmpty().WithMessage("TargetDate can not be empty");
        }
    }


}
