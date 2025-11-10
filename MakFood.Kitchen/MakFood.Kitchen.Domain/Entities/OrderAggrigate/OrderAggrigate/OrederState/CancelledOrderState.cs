namespace MakFood.Kitchen.Domain.Entities.OrderAggrigate.OrderAggrigate.OrederState
{
    public sealed class CancelledOrderState : OrderState
    {
        internal CancelledOrderState() {} //ef
        public override OrderStatus Status => OrderStatus.Cancelled;

    }

}