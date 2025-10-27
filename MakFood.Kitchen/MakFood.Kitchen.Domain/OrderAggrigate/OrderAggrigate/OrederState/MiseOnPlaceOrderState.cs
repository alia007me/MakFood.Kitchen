namespace MakFood.Kitchen.Domain.OrderAggrigate.OrderAggrigate.OrederState
{
    public sealed class MiseOnPlaceOrderState : OrderState
    {
        internal MiseOnPlaceOrderState() { }
        public override OrderStatus Status => OrderStatus.MiseOnPlace;

    }

}