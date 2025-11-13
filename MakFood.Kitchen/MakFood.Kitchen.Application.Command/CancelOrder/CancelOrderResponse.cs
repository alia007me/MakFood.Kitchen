namespace MakFood.Kitchen.Application.Command.CancelOrder
{
    public class CancelOrderResponse
    {
        public bool Success { get; set; }
        public Guid OrderId { get; set; }
    }
}
