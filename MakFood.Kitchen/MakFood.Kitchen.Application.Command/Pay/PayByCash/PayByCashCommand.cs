using MakFood.Kitchen.Application.Command.Base;
using MediatR;

namespace MakFood.Kitchen.Application.Command.Pay.PayByCash
{
    public class PayByCashCommand : ComandBase, IRequest<PayByCashResponse>
    {
        public Guid OrderId { get; set; }
        public Guid CustomerId { get; set; }
        public override void Validate()
        {
            new PayByCashCommandValidator().Validate(this).ThrowIfNeeded();
        }
    }
}
