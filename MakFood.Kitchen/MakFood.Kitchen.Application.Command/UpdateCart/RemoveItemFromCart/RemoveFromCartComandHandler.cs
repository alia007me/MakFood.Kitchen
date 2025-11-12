using MakFood.Kitchen.Application.Command.UpdateCart.AddItemToCart;
using MakFood.Kitchen.Domain.Entities.CartAggrigate.Contract;
using MakFood.Kitchen.Domain.Entities.ProductAggrigate.Contract;
using MakFood.Kitchen.Infrastructure.Persistence.Context;
using MediatR;

namespace MakFood.Kitchen.Application.Command.UpdateCart.RemoveItemFromCart
{
    public class RemoveFromCartComandHandler : IRequestHandler<RemoveFromCartComand, RemoveFromCartComandRespnse>
    {
        private readonly IProductRepository _productRepository;
        private readonly ICartRepository _cartRepository;
        private readonly IUnitOfWork _UnitOfWork;
        public RemoveFromCartComandHandler(ICartRepository cartRepository, IUnitOfWork unitOfWork
            , IProductRepository productRepository)
        {
            _cartRepository = cartRepository;
            _productRepository = productRepository;
            _UnitOfWork = unitOfWork;
        }
        public async Task<RemoveFromCartComandRespnse> Handle(RemoveFromCartComand cartComand, CancellationToken ct)
        {
            var cart = await _cartRepository.GetCartByIdTracked(cartComand.CartId, ct);
            var CartsCartitem = cart.CartItems.SingleOrDefault(x => x.ProductId == cartComand.ItemId);
            if ((CartsCartitem) == null) {
                throw new ArgumentException("item not found in cart (you dont have this item in your cart)");
            }
            if (CartsCartitem.Quantity > 1) {
                CartsCartitem.DecreaseQuantity();
            }
            else {
                cart.RemoveCartItem(cartComand.ItemId);
            }
            await _UnitOfWork.Commit(ct);
            var items = new GetCartDTO(cart.CartItems);
            var respon = new RemoveFromCartComandRespnse() { items = items };
            return respon;
        }


    }
}
