using MakFood.Kitchen.Domain.Base;
using MakFood.Kitchen.Domain.OrderAggrigate.OrderAggrigate.OrederState;

namespace MakFood.Kitchen.Domain.OrderAggrigate.OrderAggrigate.PaymentAggrigate.PaymentState
{
    public abstract class PaymentState : BaseEntity<Guid>
    {
        protected PaymentState()
        {
            Id = Guid.NewGuid();
        }

        public abstract OrderStatus Status { get; }
        public virtual CreatedOrderState Aproved()
        {
            throw new Exception("Created Payment status is not valid!");
        }

        public virtual MiseOnPlaceOrderState Paied()
        {
            throw new Exception("MiseOnPlace Payment status is not valid!");
        }

        public virtual CancelledOrderState Cancelled()
        {
            throw new Exception("Cancelled Payment status is not valid!");
        }
    }

}
