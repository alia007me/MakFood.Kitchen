using FluentValidation;

namespace MakFood.Kitchen.Application.Command.Pay.PayByWallet.SendOrderToPayByWallet
{
    public class SendOrderToPayByWalletValidation : AbstractValidator<SendOrderToPayByWalletCommand>
    {
        public SendOrderToPayByWalletValidation()
        {
            RuleFor(x => x.CustomerId).NotNull().NotEmpty().NotEqual(Guid.Empty).WithMessage("your user guid is not valid");
            RuleFor(x => x.OrderId).NotNull().NotEmpty().NotEqual(Guid.Empty).WithMessage("your order guid is not valid");
        }
    }
}
