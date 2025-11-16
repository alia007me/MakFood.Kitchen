using MakFood.Kitchen.Application.Command.Helper.CartHelper;
using MakFood.Kitchen.Domain.Entities.CartAggrigate;
using MakFood.Kitchen.Domain.Entities.CartAggrigate.Contract;
using MakFood.Kitchen.Domain.Entities.ProductAggrigate.Contract;
using MakFood.Kitchen.Infrastructure.Persistence.Context.Transactions;
using MediatR;

namespace MakFood.Kitchen.Application.Command.UpdateCart.AddItemToCart
{
    public class AddItemToCartCommandHandler : IRequestHandler<AddItemToCartCommand, AddItemToCartCommandRespnse>
    {
        private readonly IProductRepository _productRepository;
        private readonly ICartRepository _cartRepository;
        private readonly IUnitOfWork _UnitOfWork;
        public AddItemToCartCommandHandler(ICartRepository cartRepository, IUnitOfWork unitOfWork
            , IProductRepository productRepository)
        {
            _cartRepository = cartRepository;
            _productRepository = productRepository;
            _UnitOfWork = unitOfWork;
        }
        public async Task<AddItemToCartCommandRespnse> Handle(AddItemToCartCommand cartCommand, CancellationToken ct)
        {
            var cart = await _cartRepository.GetCartById(cartCommand.CartId, ct);
            var CartItem = cart.GetCartItemByID(cartCommand.ItemId);
            if (CartItem is not null)
                CartItem.IncreaseQuantity();
            else
                await addCartItem(cart, cartCommand, ct);

            await _UnitOfWork.Commit(ct);

            return cart.CartItems.ToDto();
        }
        #region AddCartItem
        private async Task addCartItem(Cart cart, AddItemToCartCommand cartCommand, CancellationToken ct)
        {

            var cartItem = new CartItem(await _productRepository.GetProductById(cartCommand.ItemId, ct, false));
            cart.AddCartItem(cartItem);
        }
        #endregion

    }
}

