using MakFood.Kitchen.Domain.Entities.Base;

namespace MakFood.Kitchen.Domain.Entities.OrderAggrigate.OrderAggrigate.OrederState
{
    public abstract class OrderState : BaseEntity<Guid>
    {
        protected OrderState()
        {
            Id = Guid.NewGuid();
        }
        public abstract OrderStatus Status { get; }
        public virtual CreatedOrderState Created()
        {
            throw new Exception("Created order is not valid!");
        }

        public virtual MiseOnPlaceOrderState MiseOnPlace()
        {
            throw new Exception("MiseOnPlace order status is not valid!");
        }

        public virtual CancelledOrderState Cancelled()
        {
            throw new Exception("Cancelled order status is not valid!");
        }
    }

}
