namespace MakFood.Kitchen.Domain.Entities.OrderAggrigate.OrderAggrigate.OrederState
{
    public sealed class MiseOnPlaceOrderState : OrderState
    {
        internal MiseOnPlaceOrderState() { } //ef
        public override OrderStatus Status => OrderStatus.MiseOnPlace;

    }

}