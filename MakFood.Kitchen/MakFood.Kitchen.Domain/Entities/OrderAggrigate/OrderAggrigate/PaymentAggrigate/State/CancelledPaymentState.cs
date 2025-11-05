using MakFood.Kitchen.Domain.Entities.OrderAggrigate.OrderAggrigate.PaymentAggrigate.Enum;

namespace MakFood.Kitchen.Domain.Entities.OrderAggrigate.OrderAggrigate.PaymentAggrigate.State
{
    public sealed class CancelledPaymentState : PaymentState
    {
        internal CancelledPaymentState() { }//ef
        public override PaymentStatus Status => PaymentStatus.Cancelled;
    }
}
