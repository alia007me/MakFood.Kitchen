namespace MakFood.Kitchen.Application.Command.AddProduct
{
    public class AddProductCommandResponse
    {
        public AddProductCommandResponse(Guid productId)
        {
            ProductId = productId;
        }

        public Guid ProductId { get; set; }
    }
}
