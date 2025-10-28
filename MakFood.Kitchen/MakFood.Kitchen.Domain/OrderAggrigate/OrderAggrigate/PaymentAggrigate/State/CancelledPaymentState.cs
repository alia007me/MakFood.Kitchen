using MakFood.Kitchen.Domain.OrderAggrigate.OrderAggrigate.PaymentAggrigate.Enum;

namespace MakFood.Kitchen.Domain.OrderAggrigate.OrderAggrigate.PaymentAggrigate.State
{
    public sealed class CancelledPaymentState : PaymentState
    {
        public override PaymentStatus Status => PaymentStatus.Cancelled;
    }
}
