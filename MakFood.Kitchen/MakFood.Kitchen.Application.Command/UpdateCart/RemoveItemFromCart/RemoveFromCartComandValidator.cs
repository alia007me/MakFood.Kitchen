using FluentValidation;

namespace MakFood.Kitchen.Application.Command.UpdateCart.RemoveItemFromCart
{
    public class RemoveFromCartComandValidator : AbstractValidator<RemoveFromCartComand>
    {
        public RemoveFromCartComandValidator()
        {
            RuleFor(x => x.CartId).NotNull().NotEmpty().NotEqual(Guid.Empty).WithMessage("your guid is not valid");
            RuleFor(x => x.ItemId).NotNull().NotEmpty().NotEqual(Guid.Empty).WithMessage("your guid is not valid");
        }
    }
}
