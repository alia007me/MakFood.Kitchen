using MakFood.Kitchen.Domain.Entities.OrderAggrigate.OrderAggrigate.PaymentAggrigate.Enum;

namespace MakFood.Kitchen.Domain.Entities.OrderAggrigate.OrderAggrigate.PaymentAggrigate.State
{
    public sealed class CancelledPaymentState : PaymentState
    {
        public override PaymentStatus Status => PaymentStatus.Cancelled;
    }
}
