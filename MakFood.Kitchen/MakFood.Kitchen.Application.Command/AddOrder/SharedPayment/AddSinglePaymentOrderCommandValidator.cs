using FluentValidation;

namespace MakFood.Kitchen.Application.Command.AddOrder.SharedPayment
{
    public class AddSinglePaymentOrderCommandValidator : AbstractValidator<AddSinglePaymentOrderCommand>
    {
        public AddSinglePaymentOrderCommandValidator()
        {
            RuleFor(x => x.CartId)
            .NotEmpty()
            .WithMessage("The Cart ID is required.");

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
        }
    }

}
