namespace MakFood.Kitchen.Application.Command.AddProduct
{
    public class AddProductCommandResponce
    {
        public AddProductCommandResponce(Guid productId)
        {
            ProductId = productId;
        }

        public Guid ProductId { get; set; }
    }
}
