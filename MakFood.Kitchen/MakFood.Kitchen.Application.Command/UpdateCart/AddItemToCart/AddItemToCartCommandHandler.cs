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
        private readonly IUnitOfWork _unitOfWork;
        public AddItemToCartCommandHandler(ICartRepository cartRepository, IUnitOfWork unitOfWork
            , IProductRepository productRepository)
        {
            _cartRepository = cartRepository;
            _productRepository = productRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task<AddItemToCartCommandRespnse> Handle(AddItemToCartCommand cartCommand, CancellationToken ct)
        {
            var cart = await _cartRepository.GetCartById(cartCommand.CartId, ct);
            var cartItem = cart.GetCartItemByID(cartCommand.ItemId);
            await IncreaseQuantity(cart, cartItem, cartCommand, ct);
            await _unitOfWork.Commit(ct);

            return cart.CartItems.ToDto();
        }
        #region AddCartItem
        private async Task addCartItem(Cart cart, AddItemToCartCommand cartCommand, CancellationToken ct)
        {
            var cartItem = new CartItem(await _productRepository.GetProduct(cartCommand.ItemId, ct, false));
            cart.AddCartItem(cartItem);
        }
        private async Task IncreaseQuantity(Cart cart, CartItem cartItem, AddItemToCartCommand cartCommand, CancellationToken ct)
        {
            if (cartItem is not null)
                cartItem.IncreaseQuantity();
            else
                await addCartItem(cart, cartCommand, ct);

        }
        #endregion

    }
}

