namespace MakFood.Kitchen.Domain.Entities.OrderAggrigate.OrderAggrigate.OrederState
{
    public sealed class CreatedOrderState : OrderState
    {
        internal CreatedOrderState() {} //ef
        public override OrderStatus Status => OrderStatus.Created;
        public override MiseOnPlaceOrderState MiseOnPlace()
        {
            return new MiseOnPlaceOrderState();
        }
        public override CancelledOrderState Cancelled()
        {
            return new CancelledOrderState();
        }


    }

}