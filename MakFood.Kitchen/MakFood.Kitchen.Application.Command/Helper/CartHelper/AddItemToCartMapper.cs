using MakFood.Kitchen.Application.Command.UpdateCart;
using MakFood.Kitchen.Domain.Entities.CartAggrigate;

namespace MakFood.Kitchen.Application.Command.Helper.CartHelper
{
    public static class AddItemToCartMapper
    {
        public static AddItemToCartCommandRespnse ToDto(this IEnumerable<CartItem> cartItems)
        {
            var CartItemsDTO = cartItems.Select(c => new GetCartItemDTO(c.ProductName, c.ProductThumbnailPath, c.ProductId, c.Quantity));
            return new AddItemToCartCommandRespnse
               {
                   Items = new GetCartDTO(CartItemsDTO)
               };
        }
    } 
}

