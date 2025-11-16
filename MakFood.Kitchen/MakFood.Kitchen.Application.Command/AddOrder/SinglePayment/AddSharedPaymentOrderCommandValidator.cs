using FluentValidation;

namespace MakFood.Kitchen.Application.Command.AddOrder.SinglePayment
{
    public class AddSharedPaymentOrderCommandValidator : AbstractValidator<AddSharedPaymentOrderCommand>
    {
        public AddSharedPaymentOrderCommandValidator()
        {
            RuleFor(x => x.CartId)
                .NotEmpty()
                .WithMessage("Cart ID cannot be empty.");


            RuleFor(x => x.DiscountCodeTitle)
                    .NotEmpty()
                    .WithMessage("Discount Code Title cannot be empty.")
                    .MinimumLength(4)
                    .WithMessage("Discount Code Title must be at least 4 characters long.")
                    .MaximumLength(24)
                    .WithMessage("Discount Code Title cannot exceed 24 characters.");

            RuleFor(x => x.OwnerPaymentMethod)
                    .IsInEnum()
                    .WithMessage("The selected Owner Payment Method is invalid.");

            RuleFor(x => x.PartnerId)
                    .NotEmpty()
                    .WithMessage("Partner ID cannot be empty.");
        }
    }
}


