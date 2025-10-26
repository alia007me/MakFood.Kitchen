namespace MakFood.Kitchen.Domain.Constituent.Order.OrederState
{
    public sealed class CancelledOrderState : OrderState
    {
        internal CancelledOrderState() { }
        public override OrderStatus Status => OrderStatus.Cancelled;

    }

}