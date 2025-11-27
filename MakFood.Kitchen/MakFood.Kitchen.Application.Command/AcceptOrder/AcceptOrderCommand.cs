using MakFood.Kitchen.Application.Command.Base;
using MakFood.Kitchen.Domain.Entities.OrderAggrigate.OrderAggrigate.PaymentAggrigate.Enum;
using MediatR;

namespace MakFood.Kitchen.Application.Command.AcceptOrder
{
    public class AcceptOrderCommand : ComandBase, IRequest<AcceptOrderCommandResponse>
    {
        public Guid OrderId { get; set; }
        public PaymentMathod PaymentMathod { get; set; }
        public bool PartnerApprove { get; set; }
        public override void Validate()
        {
            new AcceptOrderCommandValidator().Validate(this).ThrowIfNeeded();
        }
    }
}
