using MakFood.Kitchen.Application.Query.GetCart;
using MakFood.Kitchen.Domain.Entities.CartAggrigate;
using MakFood.Kitchen.Domain.Entities.CartAggrigate.Contract;
using MakFood.Kitchen.Domain.Entities.ProductAggrigate.Contract;
using MakFood.Kitchen.Infrastructure.Persistence.Context.Transactions;
using MediatR;

namespace MakFood.Kitchen.Application.Command.UpdateCart
{
    public class AddItemToCartComandHandler : IRequestHandler<AddItemToCartCommand, AddItemToCartComandRespnse>
    {
        private readonly IProductRepository _productRepository;
        private readonly ICartRepository _cartRepository;
        private readonly IUnitOfWork _unitOfWork;
        public AddItemToCartComandHandler(ICartRepository cartRepository, IUnitOfWork unitOfWork
            , IProductRepository productRepository)
        {
            _cartRepository = cartRepository;
            _productRepository = productRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task<AddItemToCartComandRespnse> Handle(AddItemToCartCommand cartComand, CancellationToken ct)
        {
            var cart = await _cartRepository.GetCartById(cartComand.CartId, ct);

            var cartItem = cart.GetItemById(cartComand.ItemId);

            if (cartItem is not null)
                cartItem.IncreaseQuantity();
            else
                await AddCartItem(cartComand, cart, ct);

            await _unitOfWork.Commit(ct);

            return cart.CartItems.ToDto();
        }

        #region Private Methods

        private async Task AddCartItem(AddItemToCartCommand cartComand, Cart cart, CancellationToken ct)
        {
            var product = await _productRepository.GetProductTracked(cartComand.ItemId, ct);

            cart.AddCartItem(new CartItem(product));
        }

        #endregion
    }

    public static class AddItemToCartMapper
    {
        public static AddItemToCartComandRespnse ToDto(this IEnumerable<CartItem> cartItems)
            => new AddItemToCartComandRespnse
            {
                Items = new GetCartDTO(cartItems)
            };
    }
}
