using MakFood.Kitchen.Application.Command.Base;
using MakFood.Kitchen.Domain.Entities.OrderAggrigate.OrderAggrigate.PaymentAggrigate.Enum;
using MediatR;

namespace MakFood.Kitchen.Application.Command.AddOrder.SharedPayment
{
    public class AddSinglePaymentOrderCommand : ComandBase, IRequest<AddSinglePaymentOrderCommandResponse>
    {
        public Guid CartId { get; set; }
        public string DiscountCodeTitle { get; set; }
        public PaymentMathods OwnerPaymentMethod { get; set; }

        public override void Validate()
        {
            new AddSinglePaymentOrderCommandValidator().Validate(this).ThrowIfNeeded();
        }
    }

}
