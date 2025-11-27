using MakFood.Kitchen.Application.Command.Exceptions;
using MakFood.Kitchen.Application.Command.Helper.DiscountCalculatorHelper;
using MakFood.Kitchen.Domain.Entities.CartAggrigate.Contract;
using MakFood.Kitchen.Domain.Entities.DiscountAggrigate;
using MakFood.Kitchen.Domain.Entities.DiscountAggrigate.Contract;
using MakFood.Kitchen.Domain.Entities.OrderAggrigate;
using MakFood.Kitchen.Domain.Entities.OrderAggrigate.OrderAggrigate;
using MakFood.Kitchen.Domain.Entities.OrderAggrigate.OrderAggrigate.Contract;
using MakFood.Kitchen.Domain.Entities.OrderAggrigate.OrderAggrigate.PaymentAggrigate.Enum;
using MakFood.Kitchen.Domain.Entities.ProductAggrigate.Contract;
using MakFood.Kitchen.Infrastructure.Persistence.Context.Transactions;
using MediatR;
using PaymentStates = MakFood.Kitchen.Domain.Entities.OrderAggrigate.OrderAggrigate.PaymentAggrigate;

namespace MakFood.Kitchen.Application.Command.AddOrder.SharedPayment
{
    public class AddSharedPaymentOrderCommandHandler : IRequestHandler<AddSharedPaymentOrderCommand, AddSharedPaymentOrderCommandResponse>
    {
        private readonly IDiscountRepository _discountCodeRepository;
        private readonly IProductRepository _productRepository;
        private readonly ICartRepository _cartRepository;
        private readonly IOrderRepository _orderRepository;
        private readonly IUnitOfWork _unitOfWork;
        public AddSharedPaymentOrderCommandHandler(IProductRepository productRepository, ICartRepository cartRepository, IOrderRepository orderRepository
            , IUnitOfWork unitOfWork, IDiscountRepository discountCodeRepository)
        {
            _cartRepository = cartRepository;
            _productRepository = productRepository;
            _orderRepository = orderRepository;
            _discountCodeRepository = discountCodeRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task<AddSharedPaymentOrderCommandResponse> Handle(AddSharedPaymentOrderCommand command, CancellationToken ct)
        {
            var cart = await _cartRepository.GetCartById(command.CartId, ct);
            await ValidatePartnerExistence(command.PartnerId, ct);
            ValidateCartItems(cart);

            var constituents = await CreateOrderConstituents(cart, ct);

            cart.RemoveAllItems();

            var discount = await _discountCodeRepository.GetDiscountByTitleTracked(command.DiscountCodeTitle, ct);

            var totalAmount = CalculateTotalAmount(constituents);
            var payment = CreateSharedPayment(command.OwnerPaymentMethod, discount, totalAmount, command.CartId, command.PartnerId);

            var order = CreateOrder(cart.Id, discount, payment, constituents);
            _orderRepository.AddOrder(order);

            await _unitOfWork.Commit(ct);

            return new AddSharedPaymentOrderCommandResponse()
            {
                OrderId = order.Id
            };
        }

        #region Private Methods for SRP

        /// <summary>
        /// بررسی می‌کند که آیا پارتنر وجود دارد یا خیر.
        /// </summary>
        private async Task ValidatePartnerExistence(Guid partnerId, CancellationToken ct)
        {
            var partner = await _cartRepository.GetCartById(partnerId, ct, false);
            if (partner is null) {
                throw new PartnerNotFoundException();
            }
        }

        /// <summary>
        /// بررسی می‌کند که آیا سبد خرید حاوی آیتم است یا خیر.
        /// </summary>
        private void ValidateCartItems(Cart cart)
        {
            if (!cart.CartItems.Any()) {
                throw new ThereIsNoCartItemInCartException();
            }
        }

        /// <summary>
        /// محتویات (Constituents) سفارش را بر اساس آیتم‌های سبد خرید ایجاد می‌کند.
        /// </summary>
        private async Task<List<Constituent>> CreateOrderConstituents(Cart cart, CancellationToken ct)
        {
            var constituents = new List<Constituent>();
            foreach (var cartItem in cart.CartItems) {
                var product = await _productRepository.GetProductByIdAsync(cartItem.ProductId, ct);
                constituents.Add(new Constituent(product!, cartItem));
            }
            return constituents;
        }

        /// <summary>
        /// مبلغ کل سفارش را از محتویات محاسبه می‌کند.
        /// </summary>
        private decimal CalculateTotalAmount(List<Constituent> constituents)
        {
            return constituents.Sum(x => x.Price * x.Quantity);
        }

        /// <summary>
        /// موجودیت SharedPayment را ایجاد می‌کند.
        /// </summary>
        private PaymentStates.SharedPayment CreateSharedPayment(PaymentMathod ownerPaymentMethod, Discount? discount, decimal totalAmount, Guid cartId, Guid partnerId)
        {
            var payable = DiscountCalculatorHelper.AmountCalculator(totalAmount, discount, cartId);
            return new PaymentStates.SharedPayment(payable, ownerPaymentMethod, cartId, partnerId);
        }

        /// <summary>
        /// موجودیت Order را ایجاد می‌کند.
        /// </summary>
        private Order CreateOrder(Guid customerId, Discount? discountCode, PaymentStates.SharedPayment payment, List<Constituent> constituents)
        {
            if (discountCode != null) {
                return new Order(customerId, discountCode, payment, constituents);
            }
            else {
                return new Order(customerId, null, payment, constituents);
            }
        }

        #endregion
    }
}


