namespace MakFood.Kitchen.Domain.Constituent.Order.OrederState
{
    public sealed class MiseOnPlaceOrderState : OrderState
    {
        internal MiseOnPlaceOrderState() { }
        public override OrderStatus Status => OrderStatus.MiseOnPlace;

    }

}