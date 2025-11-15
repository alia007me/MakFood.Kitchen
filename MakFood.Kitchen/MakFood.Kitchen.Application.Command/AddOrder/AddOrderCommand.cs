using FluentValidation;
using MakFood.Kitchen.Application.Command.AddOrder;
using MakFood.Kitchen.Application.Command.Base;
using MakFood.Kitchen.Domain.Entities.CartAggrigate.Contract;
using MakFood.Kitchen.Domain.Entities.DiscountAggrigate;
using MakFood.Kitchen.Domain.Entities.DiscountAggrigate.Contract;
using MakFood.Kitchen.Domain.Entities.OrderAggrigate;
using MakFood.Kitchen.Domain.Entities.OrderAggrigate.OrderAggrigate.Contract;
using MakFood.Kitchen.Domain.Entities.OrderAggrigate.OrderAggrigate.PaymentAggrigate;
using MakFood.Kitchen.Domain.Entities.OrderAggrigate.OrderAggrigate.PaymentAggrigate.Enum;
using MakFood.Kitchen.Domain.Entities.OrderAggrigate.OrderAggrigate.PaymentAggrigate.PaymentBase;
using MakFood.Kitchen.Domain.Entities.ProductAggrigate.Contract;
using MakFood.Kitchen.Infrastructure.Persistence.Context.Transactions;
using MediatR;

namespace MakFood.Kitchen.Application.Command.AddOrder
{
    public class AddOrderCommand : ComandBase, IRequest<AddOrderCommandResponse>
    {
        public Guid CartId { get; set; }
        public String DiscountCodeTitle { get; set; }
        public PaymentType PaymentType{ get; set; }

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
            , IUnitOfWork unitOfWork, IDiscountCodeRepository discountCodeRepository)
        {
            _cartRepository = cartRepository;
            _productRepository = productRepository;
            _orderRepository = orderRepository;
            _discountCodeRepository = discountCodeRepository;

            _unitOfWork = unitOfWork;
        }
        public async Task<AddOrderCommandResponse> Handle(AddOrderCommand addOrderCommand, CancellationToken ct)
        {
            var cart = await _cartRepository.GetCartById(addOrderCommand.CartId, ct);
            var Items = cart.CartItems.ToList();
            var Constituents = new List<Constituent>();
            var Discount = _discountCodeRepository.GetDiscountByTitleTracked(addOrderCommand.DiscountCodeTitle);
            for (int i = 0; i < Items.Count(); i++) {
                Constituents.Add(new Constituent(await _productRepository.GetProduct(Items[i].ProductId, ct), Items[i]));
            }
            _orderRepository.AddOrder(cart.Id, Discount, , Constituents);
            //Guid customerId, Discount discountCode,Payment payment,List<Constituent> constituents
        }
    }
    public static class OrderHelper
    {
        public static Payment paymentcreator(this PaymentType paymentType,PaymentMathods ownerPaymentMethod, Discount? discount, List<Constituent> constituents,Guid cartId)
        {
            Payment payment;
            DiscountValidation(discount, cartId);
            var TotalAmount = constituents.Sum(c => c.Price);
            var FinallAmount = amountCalculator(TotalAmount,discount);
            paymentType == PaymentType.singel ? payment = new SinglePayment(TotalAmount, FinallAmount, ownerPaymentMethod):
            // decimal totalAmount, decimal reminingAmount, PaymentMathods ownerPaymentMethod, decimal ownerAmount)
        }
        private static decimal amountCalculator(decimal amount, Discount discount)
        {
            if (amount < discount.MinimumBalance) {
                throw new Exception("your order is so cheep for this dicont code");
            }
            else if (amount > discount.MaximumBalance) {
                return (amount - discount.MaximumBalance * (discount.Percent));
            }
            else {
                return (amount * (discount.Percent));
            }
        }
        private static void DiscountValidation(Discount discount, Guid custopmerId)
        {
            if (discount.ExpiryDate < DateOnly.FromDateTime(DateTime.Now)) {
                throw new Exception("This code is expierd");
            }
            else if (!discount.AvailableForCustomer(custopmerId)) {
                throw new Exception("this is not your code");
            }
        }
    }
    public class AddOrderCommandValidator : AbstractValidator<AddOrderCommand>
    {
    }
    public class AddOrderCommandResponse
    {
    }

}
