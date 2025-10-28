using MakFood.Kitchen.Domain.OrderAggrigate.OrderAggrigate.PaymentAggrigate.Enum;

namespace MakFood.Kitchen.Domain.OrderAggrigate.OrderAggrigate.PaymentAggrigate.State
{
    public class CreatedPaymentState : PaymentState
    {
        public override PaymentStatus Status => PaymentStatus.Created;

        public override PaidPaymentState Paid()
        {
            return new PaidPaymentState();
        }

        public override CancelledPaymentState Cancelled()
        {
            return new CancelledPaymentState();
        }
    }
}
