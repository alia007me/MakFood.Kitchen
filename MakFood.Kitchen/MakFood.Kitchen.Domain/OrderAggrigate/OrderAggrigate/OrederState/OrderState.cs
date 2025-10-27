using MakFood.Kitchen.Domain.Base;

namespace MakFood.Kitchen.Domain.OrderAggrigate.OrderAggrigate.OrederState
{
    public abstract class OrderState : BaseEntity<Guid>
    {
        protected OrderState() {
        }
        public Guid Id { get; set; }
        public DateTime CreationDateTime { get; private set; }
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
