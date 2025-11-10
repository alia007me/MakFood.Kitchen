using FluentValidation;


namespace MakFood.Kitchen.Application.Command.CancelOrder
{
    public class CancelOrderValidation : AbstractValidator<CancelOrderCommand>
    {
        public CancelOrderValidation()
        {
            RuleFor(x => x.CustomerId).NotEmpty().WithMessage("CustomerId can not be null").NotEmpty().WithMessage("CustomerId can not be empty");
            RuleFor(x => x.OrderId).NotEmpty().WithMessage("OrderId can not be null").NotEmpty().WithMessage("OrderId can not be empty");
        }
    }
}
