using FluentValidation;

namespace MakFood.Kitchen.Application.Command.Pay.PayByCash
{
    public class PayByCashCommandValidator : AbstractValidator<PayByCashCommand>
    {
        public PayByCashCommandValidator()
        {

            RuleFor(x => x.CustomerId).NotNull().NotEmpty().NotEqual(Guid.Empty).WithMessage("your guid is not valid");
            RuleFor(x => x.OrderId).NotNull().NotEmpty().NotEqual(Guid.Empty).WithMessage("your guid is not valid");
        }
    }
}
