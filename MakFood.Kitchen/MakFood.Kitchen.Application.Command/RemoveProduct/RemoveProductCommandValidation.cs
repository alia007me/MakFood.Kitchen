using FluentValidation;

namespace MakFood.Kitchen.Application.Command.RemoveProduct
{
    public class RemoveProductCommandValidation : AbstractValidator<RemoveProductCommand>
    {
        public RemoveProductCommandValidation()
        {
            RuleFor(x => x.ProductId).NotEmpty()
           .WithMessage("The ProductId is Not Empty");
        }

    }
}
