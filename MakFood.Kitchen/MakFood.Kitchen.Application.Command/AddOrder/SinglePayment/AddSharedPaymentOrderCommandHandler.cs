using MakFood.Kitchen.Application.Command.Exceptions;
using MakFood.Kitchen.Application.Command.Helper.DiscountCalculatorHelper;
using MakFood.Kitchen.Domain.Entities.CartAggrigate.Contract;
using MakFood.Kitchen.Domain.Entities.DiscountAggrigate;
using MakFood.Kitchen.Domain.Entities.DiscountAggrigate.Contract;
using MakFood.Kitchen.Domain.Entities.OrderAggrigate;
using MakFood.Kitchen.Domain.Entities.OrderAggrigate.OrderAggrigate;
using MakFood.Kitchen.Domain.Entities.OrderAggrigate.OrderAggrigate.Contract;
using MakFood.Kitchen.Domain.Entities.OrderAggrigate.OrderAggrigate.PaymentAggrigate.Enum;
using SharedPaymentState = MakFood.Kitchen.Domain.Entities.OrderAggrigate.OrderAggrigate.PaymentAggrigate;
using MakFood.Kitchen.Domain.Entities.ProductAggrigate.Contract;
using MakFood.Kitchen.Infrastructure.Persistence.Context.Transactions;
using MediatR;

namespace MakFood.Kitchen.Application.Command.AddOrder.SinglePayment
{
    public class AddSharedPaymentOrderCommandHandler : IRequestHandler<AddSharedPaymentOrderCommand, AddSharedPaymentOrderCommandResponse>
    {
        private readonly IDiscountCodeRepository _discountCodeRepository;
        private readonly IProductRepository _productRepository;
        private readonly ICartRepository _cartRepository;
        private readonly IOrderRepository _orderRepository;
        private readonly IUnitOfWork _unitOfWork;
        public AddSharedPaymentOrderCommandHandler(IProductRepository productRepository, ICartRepository cartRepository, IOrderRepository orderRepository
            , IUnitOfWork unitOfWork, IDiscountCodeRepository discountCodeRepository)
        {
            _cartRepository = cartRepository;
            _productRepository = productRepository;
            _orderRepository = orderRepository;
            _discountCodeRepository = discountCodeRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task<AddSharedPaymentOrderCommandResponse> Handle(AddSharedPaymentOrderCommand command, CancellationToken ct)
        {
            //سبد خرید
            var cart = await _cartRepository.GetCartById(command.CartId, ct);

            //ایجاد محتویات سفارش از آیتم های سبد خرید
            if (!cart.CartItems.Any()) throw new ThereIsNoCartItemInCartException();
            var Items = cart.CartItems.ToList();
            var Constituents = new List<Constituent>();

            for (int i = 0; i < Items.Count(); i++)
            {
                Constituents.Add(new Constituent(await _productRepository.GetProduct(Items[i].ProductId, ct), Items[i]));
            }

            cart.RemoveAllItems();


            // دریافت کد تخفیف
            var Discount = await _discountCodeRepository.GetDiscountByTitleTracked(command.DiscountCodeTitle);

            //مبلغ کل سفارش
            var totalAmount = Constituents.Sum(x => x.Price);

            //ایجاد پیمنت
            var payment = CreatePayment(PaymentType.shared, command.OwnerPaymentMethod, Discount, totalAmount, command.CartId, command.PartnerId);

            //ایجاد اوردر
            var order = new Order(cart.Id, Discount, payment, Constituents);
            _orderRepository.AddOrder(order);


            await _unitOfWork.Commit(ct);

            return new AddSharedPaymentOrderCommandResponse()
            {
                OrderId = order.Id
            };
        }
        private SharedPaymentState.SharedPayment CreatePayment(PaymentType paymentType, PaymentMathods ownerPaymentMethod, Discount? discount, decimal totalAmount, Guid cartId, Guid partnerId)
        {
            var payable = DiscountCalculatorHelper.AmountCalculator(totalAmount, discount, cartId);
            SharedPaymentState.SharedPayment payment = new SharedPaymentState.SharedPayment(payable, ownerPaymentMethod, partnerId);
            return payment;
        }
    }
}


