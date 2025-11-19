using FluentValidation;
using MakFood.Kitchen.Application.Command.Base;
using MakFood.Kitchen.Application.Command.Exceptions;
using MakFood.Kitchen.Domain.Entities.CartAggrigate.Contract;
using MakFood.Kitchen.Domain.Entities.OrderAggrigate.OrderAggrigate.Contract;
using MakFood.Kitchen.Domain.Entities.OrderAggrigate.OrderAggrigate.PaymentAggrigate;
using MakFood.Kitchen.Domain.WalletService;
using MakFood.Kitchen.Infrastructure.Persistence.Context.Transactions;
using MakFood.Kitchen.Infrastructure.Substructure.Exceptions;
using MediatR;

namespace MakFood.Kitchen.Application.Command.Pay
{
    public class PayByWalletCommand : ComandBase, IRequest<PayByWalletResponse>
    {
        public Guid OrderId { get; set; }
        public Guid CustomerId { get; set; }

        public override void Validate()
        {
            new PayByWalletValidation().Validate(this).ThrowIfNeeded();
        }
    }


    public class PayByWalletCommandHandler : IRequestHandler<PayByWalletCommand, PayByWalletResponse>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly ICartRepository _cartRepository;
        //private readonly IWallerService _walletService;
        private readonly IUnitOfWork _unitOfWork;

        public PayByWalletCommandHandler(IOrderRepository orderRepository, ICartRepository cartRepository,
                                                 IUnitOfWork unitOfWork)
        {
            _orderRepository = orderRepository;
            _cartRepository = cartRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<PayByWalletResponse> Handle(PayByWalletCommand request, CancellationToken ct)
        {
            //اوردن یوزر
            var targerUser = await _cartRepository.GetCartById(request.CustomerId, ct, false);

            //اوردن اوردر و برسی وجود داشتنش
            var order = await _orderRepository.GetOrderByIdAsync(request.OrderId, ct);
            if (order is null) throw new CustomerOrderMismatchException();


            if (order.Payment is SharedPayment sharedPayment) {
                var orderPayment = sharedPayment;
            }
            else if (order.Payment is SinglePayment singlePayment) {
                var orderPayment = singlePayment;
            }
            else {
                var orderPayment = order.Payment;
            }


            return new PayByWalletResponse();

        }
    }

    public record PayByWalletResponse();

    public class PayByWalletValidation : AbstractValidator<PayByWalletCommand>
    {
        public PayByWalletValidation()
        {

        }
    }
}
