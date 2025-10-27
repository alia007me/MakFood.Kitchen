namespace MakFood.Kitchen.Domain.OrderAggrigate.OrderAggrigate.OrederState
{
    public sealed class CancelledOrderState : OrderState
    {
        internal CancelledOrderState() { }
        public override OrderStatus Status => OrderStatus.Cancelled;

    }

}