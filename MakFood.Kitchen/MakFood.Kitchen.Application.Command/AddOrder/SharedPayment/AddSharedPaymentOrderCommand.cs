using MakFood.Kitchen.Application.Command.AddOrder.SinglePayment;
using MakFood.Kitchen.Application.Command.Base;
using MakFood.Kitchen.Domain.Entities.OrderAggrigate.OrderAggrigate.PaymentAggrigate.Enum;
using MediatR;

namespace MakFood.Kitchen.Application.Command.AddOrder.SharedPayment
{
    public class AddSharedPaymentOrderCommand : ComandBase, IRequest<AddSharedPaymentOrderCommandResponse>
    {
        public Guid CartId { get; set; }
        public string? DiscountCodeTitle { get; set; }
        public PaymentMathod OwnerPaymentMethod { get; set; }
        public Guid PartnerId { get; set; }

        public override void Validate()
        {
            new AddSharedPaymentOrderCommandValidator().Validate(this).ThrowIfNeeded();
        }
    }
}


