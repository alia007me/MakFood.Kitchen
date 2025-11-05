using MakFood.Kitchen.Domain.Entities.OrderAggrigate.OrderAggrigate.PaymentAggrigate.Enum;

namespace MakFood.Kitchen.Domain.Entities.OrderAggrigate.OrderAggrigate.PaymentAggrigate.State
{
    public sealed class PaidPaymentState : PaymentState
    {
        internal PaidPaymentState() { }//ef
        public override PaymentStatus Status => PaymentStatus.Paid;


        public override CancelledPaymentState Cancelled()
        {
            return new CancelledPaymentState();
        }
    }
}
