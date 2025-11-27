using FluentValidation;

namespace MakFood.Kitchen.Application.Command.Pay.PayByWallet.ResivePaiedOrderFromWallet
{
    public class ResivePaiedOrderFromWalletCommandValidature : AbstractValidator<ResivePaiedOrderFromWalletCommand>
    {
        public ResivePaiedOrderFromWalletCommandValidature()
        {
            RuleFor(R => R.Amount).NotEmpty().NotNull().GreaterThan(0).LessThan(decimal.MaxValue).WithMessage("your amount is not valid");
            RuleFor(R => R.OrderId).NotNull().NotEmpty().NotEqual(Guid.Empty).WithMessage("your prder guid is not valid");
            RuleFor(R => R.UserId).NotNull().NotEmpty().NotEqual(Guid.Empty).WithMessage("your order guid is not valid");
            RuleFor(R => R.IsPaied).NotEmpty().NotNull().WithMessage("Your boolean is not valid");
        }
    }
}
