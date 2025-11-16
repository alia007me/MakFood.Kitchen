using FluentValidation;

namespace MakFood.Kitchen.Application.Command.RemoveProduct
{
    public class RemoveProductCommandValidation : AbstractValidator<RemoveProductCommand>
    {
        public RemoveProductCommandValidation()
        {
            RuleFor(x => x.ProductId).NotEmpty()
           .WithMessage("The Name is Not Empty");
        }
    }
}
