using MakFood.Kitchen.Application.Query.GetCart;
using MakFood.Kitchen.Domain.Entities.CartAggrigate;
using MakFood.Kitchen.Domain.Entities.CartAggrigate.Contract;
using MakFood.Kitchen.Domain.Entities.ProductAggrigate.Contract;
using MakFood.Kitchen.Infrastructure.Persistence.Context;
using MakFood.Kitchen.Infrastructure.Persistence.Context.Transactions;
using MediatR;

namespace MakFood.Kitchen.Application.Command.UpdateCart
{
    public class AddItemToCartComandHandler : IRequestHandler<AddItemToCartComand, AddItemToCartComandRespnse>
    {
        private readonly IProductRepository _productRepository;
        private readonly ICartRepository _cartRepository;
        private readonly IUnitOfWork _UnitOfWork;
        public AddItemToCartComandHandler(ICartRepository cartRepository, IUnitOfWork unitOfWork
            , IProductRepository productRepository)
        {
            _cartRepository = cartRepository;
            _productRepository = productRepository;
            _UnitOfWork = unitOfWork;
        }
        public async Task<AddItemToCartComandRespnse> Handle(AddItemToCartComand cartComand, CancellationToken ct)
        {
            var cart = await _cartRepository.GetCartByIdTracked(cartComand.CartId, ct);
            var CartsCartitem = cart.CartItems.SingleOrDefault(x => x.ProductId == cartComand.ItemId);
            if ((CartsCartitem) != null) {
                CartsCartitem.IncreaseQuantity();
            }
            else {
                var cartItem = new CartItem(await _productRepository.GetProductTracked(cartComand.ItemId, ct));
                cart.AddCartItem(cartItem);
            }
            await _UnitOfWork.commit(ct);
            var items = new GetCartDTO(cart.CartItems);
            var respon = new AddItemToCartComandRespnse() { items = items };
            return respon;
        }
    }
}
