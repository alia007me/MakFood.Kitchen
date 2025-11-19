namespace MakFood.Kitchen.Application.Command.AddDiscount
{
    public class CreateDiscountCommandResponse
    {
        public CreateDiscountCommandResponse(Guid discountId)
        {
            DiscountId = discountId;
        }

        public Guid DiscountId { get; set; }
    }
}