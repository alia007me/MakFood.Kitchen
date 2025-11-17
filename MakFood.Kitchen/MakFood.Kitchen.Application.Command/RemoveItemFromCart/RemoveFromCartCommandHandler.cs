using MakFood.Kitchen.Application.Command.Helper.CartHelper;
using MakFood.Kitchen.Domain.Entities.CartAggrigate;
using MakFood.Kitchen.Domain.Entities.CartAggrigate.Contract;
using MakFood.Kitchen.Domain.Entities.ProductAggrigate.Contract;
using MakFood.Kitchen.Infrastructure.Persistence.Context.Transactions;
using MediatR;

namespace MakFood.Kitchen.Application.Command.UpdateCart
{
    public class RemoveFromCartCommandHandler : IRequestHandler<RemoveFromCartCommand, RemoveFromCartCommandResponse>
    {
        private readonly ICartRepository _cartRepository;
        private readonly IUnitOfWork _unitOfWork;
        public RemoveFromCartCommandHandler(ICartRepository cartRepository, IUnitOfWork unitOfWork
            , IProductRepository productRepository)
        {
            _cartRepository = cartRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task<RemoveFromCartCommandResponse> Handle(RemoveFromCartCommand cartComand, CancellationToken ct)
        {
            var cart = await _cartRepository.GetCartById(cartComand.CartId, ct);
            var cartItem = cart.GetCartItemByID(cartComand.ItemId);
            validate(cartItem);
            await Reduce(cart, cartItem);
            await _unitOfWork.Commit(ct);
            return response(cart);
        }
        #region validation
        public void validate(CartItem cartItem)
        {
            if (cartItem is null)
                throw new ArgumentException("item not found in cart (you dont have this item in your cart)");
        }
        #endregion
        #region response
        private RemoveFromCartCommandResponse response(Cart cart)
        {
            var CartItemsDTO = cart.CartItems.Select(c => new GetCartItemDTO(c.ProductName, c.ProductThumbnailPath, c.ProductId, c.Quantity));
            var items = new GetCartDTO(CartItemsDTO);
            return new RemoveFromCartCommandResponse() { items = items };
        }
        private async Task Reduce(Cart cart, CartItem cartItem)
        {
            if (cartItem.IsReducible())
                cartItem.DecreaseQuantity();
            else
                cart.RemoveCartItem(cartItem);
        }
        #endregion
    }
}
