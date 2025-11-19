namespace MakFood.Kitchen.Application.Command.Helper.CartHelper
{
    public record GetCartItemDTO(string productName, string productThumbnailPath, Guid productId, uint quantity);
}
