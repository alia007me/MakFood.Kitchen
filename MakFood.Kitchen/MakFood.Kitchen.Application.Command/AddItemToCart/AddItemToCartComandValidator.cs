using FluentValidation;

namespace MakFood.Kitchen.Application.Command.UpdateCart
{
    public class AddItemToCartComandValidator : AbstractValidator<AddItemToCartComand>
    {
        public AddItemToCartComandValidator()
        {
            RuleFor(x => x.CartId).NotNull().NotEmpty().NotEqual(Guid.Empty).WithMessage("your guid is not valid");
            RuleFor(x => x.ItemId).NotNull().NotEmpty().NotEqual(Guid.Empty).WithMessage("your guid is not valid");
        }
    }
}
