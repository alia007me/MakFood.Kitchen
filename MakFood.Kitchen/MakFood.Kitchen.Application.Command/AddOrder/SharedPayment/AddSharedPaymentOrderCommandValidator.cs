using FluentValidation;

namespace MakFood.Kitchen.Application.Command.AddOrder.SharedPayment
{
    public class AddSharedPaymentOrderCommandValidator : AbstractValidator<AddSharedPaymentOrderCommand>
    {
        public AddSharedPaymentOrderCommandValidator()
        {
            RuleFor(x => x.CartId)
                .NotEmpty()
                .WithMessage("Cart ID cannot be empty.");

            RuleFor(x => x.OwnerPaymentMethod)
                    .IsInEnum()
                    .WithMessage("The selected Owner Payment Method is invalid.");

            RuleFor(x => x.PartnerId)
                    .NotEmpty()
                    .WithMessage("Partner ID cannot be empty.");
        }
    }
}


