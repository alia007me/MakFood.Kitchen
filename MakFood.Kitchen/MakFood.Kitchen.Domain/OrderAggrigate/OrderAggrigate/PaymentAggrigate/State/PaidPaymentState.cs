using MakFood.Kitchen.Domain.OrderAggrigate.OrderAggrigate.PaymentAggrigate.Enum;

namespace MakFood.Kitchen.Domain.OrderAggrigate.OrderAggrigate.PaymentAggrigate.State
{
    public sealed class PaidPaymentState : PaymentState
    {
        public override PaymentStatus Status => PaymentStatus.Paid;


        public override CancelledPaymentState Cancelled()
        {
            return new CancelledPaymentState();
        }
    }
}
