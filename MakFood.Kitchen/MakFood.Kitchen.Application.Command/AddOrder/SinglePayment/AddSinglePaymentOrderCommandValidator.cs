using FluentValidation;

namespace MakFood.Kitchen.Application.Command.AddOrder.SinglePayment
{
    public class AddSinglePaymentOrderCommandValidator : AbstractValidator<AddSinglePaymentOrderCommand>
    {
        public AddSinglePaymentOrderCommandValidator()
        {
            RuleFor(x => x.CartId)
            .NotEmpty()
            .WithMessage("The Cart ID is required.");

            RuleFor(x => x.OwnerPaymentMethod)
                .IsInEnum()
                .WithMessage("The selected Owner Payment Method is invalid.");
        }
    }

}
