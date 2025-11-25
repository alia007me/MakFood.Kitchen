using MakFood.Kitchen.Application.Command.Helper.CartHelper;
using MakFood.Kitchen.Domain.Entities.CartAggrigate.Contract;
using MediatR;

namespace MakFood.Kitchen.Application.Query.GetCart
{
    public class GetCartQueryHandler : IRequestHandler<GetCartQuery, GetCartDTO>
    {
        private readonly ICartRepository _cartRepo;
        public GetCartQueryHandler(ICartRepository cartRepository)
        {
            _cartRepo = cartRepository;
        }

        #region getCartItems
        public async Task<GetCartDTO> Handle(GetCartQuery getCartQuery, CancellationToken ct)
        {
            var cart = await _cartRepo.GetCartById(getCartQuery.CartId, ct, false);
            var CartItemsDTO = cart.CartItems.Select(c => new GetCartItemDTO(c.ProductName,c.ProductThumbnailPath,c.ProductId,c.Quantity));
            var result = new GetCartDTO(CartItemsDTO);
            return result;
        }
        #endregion

    }
}
