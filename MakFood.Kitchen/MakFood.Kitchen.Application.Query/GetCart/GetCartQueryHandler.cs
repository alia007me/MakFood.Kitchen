using MakFood.Kitchen.Application.Command.Helper.CartHelper;
using MakFood.Kitchen.Domain.Entities.CartAggrigate.Contract;
using MediatR;

namespace MakFood.Kitchen.Application.Query.GetCart
{
    public class GetCartQueryHandler : IRequestHandler<GetCartQuery, GetCartDTO>
    {
        private readonly ICartRepository _CartRepo;
        public GetCartQueryHandler(ICartRepository cartRepository)
        {
            _CartRepo = cartRepository;
        }

        #region getCartItems
        public async Task<GetCartDTO> Handle(GetCartQuery getCartQuery, CancellationToken ct)
        {
            var Cart = await _CartRepo.GetCartById(getCartQuery.CartId, ct, false);
            var CartItemsDTO = Cart.CartItems.Select(c => new GetCartItemDTO(c.ProductName,c.ProductThumbnailPath,c.ProductId,c.Quantity));
            var resualt = new GetCartDTO(CartItemsDTO);
            return resualt;
        }
        #endregion

    }
}
