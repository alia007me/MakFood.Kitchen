using FluentValidation;
using MakFood.Kitchen.Application.Command.Base;
using MakFood.Kitchen.Application.Command.UpdateCart.AddItemToCart;
using MakFood.Kitchen.Domain.Entities.CartAggrigate.Contract;
using MakFood.Kitchen.Domain.Entities.DiscountAggrigate.Contract;
using MakFood.Kitchen.Domain.Entities.OrderAggrigate;
using MakFood.Kitchen.Domain.Entities.OrderAggrigate.OrderAggrigate.Contract;
using MakFood.Kitchen.Domain.Entities.ProductAggrigate.Contract;
using MakFood.Kitchen.Infrastructure.Persistence.Context;
using MediatR;

namespace MakFood.Kitchen.Application.Command.AddOrder
{
    public class AddOrderCommand : ComandBase, IRequest<AddOrderCommandResponse>
    {
        public Guid CartId { get; set; }
        public String DiscountCodeTitle { get; set; }
        //public Guid ProductId{ get; set; }

        public override void Validate()
        {
            new AddOrderCommandValidator().Validate(this).ThrowIfNeeded();
        }
    }
    public class AddOrderCommandHandler : IRequestHandler<AddOrderCommand, AddOrderCommandResponse>
    {
        private readonly IDiscountCodeRepository _discountCodeRepository;
        private readonly IProductRepository _productRepository;
        private readonly ICartRepository _cartRepository;
        private readonly IOrderRepository _orderRepository;
        private readonly IUnitOfWork _unitOfWork;
        public AddOrderCommandHandler(IProductRepository productRepository, ICartRepository cartRepository, IOrderRepository orderRepository
            , IUnitOfWork unitOfWork , IDiscountCodeRepository discountCodeRepository)
        {
            _cartRepository = cartRepository;
            _productRepository = productRepository;
            _orderRepository = orderRepository;
            _discountCodeRepository = discountCodeRepository;

            _unitOfWork = unitOfWork;
        }
        public async Task<AddItemToCartComandRespnse> Handle(AddOrderCommand addOrderCommand, CancellationToken ct)
        {
            var cart = await _cartRepository.GetCartById(addOrderCommand.CartId, ct);
            var Items = cart.CartItems.ToList();
            var Constituents = new List<Constituent>();
            var Discount = _discountCodeRepository.GetDiscountByTitleTracked(addOrderCommand.DiscountCodeTitle);
            for (int i = 0; i < Items.Count(); i++) {
                Constituents.Add(new Constituent( await _productRepository.GetProduct(Items[i].ProductId, ct), Items[i]));
            }
            _orderRepository.AddOrder(cart.Id, Discount, , Constituents);
            //Guid customerId, Discount discountCode,Payment payment,List<Constituent> constituents
        }
    }
    public class AddOrderCommandValidator : AbstractValidator<AddOrderCommand>
    {
    }
    public class AddOrderCommandResponse
    {
    }

}
