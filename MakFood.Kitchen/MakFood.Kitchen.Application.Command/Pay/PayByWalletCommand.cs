using FluentValidation;
using MakFood.Kitchen.Application.Command.Base;
using MakFood.Kitchen.Application.Command.Exceptions;
using MakFood.Kitchen.Domain.Entities.CartAggrigate.Contract;
using MakFood.Kitchen.Domain.Entities.OrderAggrigate.OrderAggrigate.Contract;
using MakFood.Kitchen.Domain.Entities.OrderAggrigate.OrderAggrigate.PaymentAggrigate;
using MakFood.Kitchen.Domain.Entities.OrderAggrigate.OrderAggrigate.PaymentAggrigate.Enum;
using MakFood.Kitchen.Domain.Entities.OrderAggrigate.OrderAggrigate.PaymentAggrigate.PaymentBase;
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
        public decimal AmountToPay { get; set; }

        public override void Validate()
        {
            new PayByWalletValidation().Validate(this).ThrowIfNeeded();
        }
    }

    public record PayByWalletResponse();

    public class PayByWalletValidation : AbstractValidator<PayByWalletCommand>
    {
        public PayByWalletValidation()
        {

        }
    }

    public class PayByWalletCommandHandler : IRequestHandler<PayByWalletCommand, PayByWalletResponse>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly ICartRepository _cartRepository;
        private readonly IWallerService _walletService;
        private readonly IUnitOfWork _unitOfWork;

        public PayByWalletCommandHandler(IOrderRepository orderRepository, ICartRepository cartRepository,
                                                IWallerService walletService, IUnitOfWork unitOfWork)
        {
            _orderRepository = orderRepository;
            _cartRepository = cartRepository;
            _walletService = walletService;
            _unitOfWork = unitOfWork;
        }

        public async Task<PayByWalletResponse> Handle(PayByWalletCommand request, CancellationToken ct)
        {
            //اوردن یوزر
            var targerUser = await _cartRepository.GetCartById(request.CustomerId, ct, false);

            //اوردن اوردر و برسی وجود داشتنش
            var order = await _orderRepository.GetOrderByIdAsync(request.OrderId, ct);
            if (order is null) throw new CustomerOrderMismatchException();


            if (order.Payment is SharedPayment sharedPayment)
            {
                var orderPayment = sharedPayment;
            }
            else if (order.Payment is SinglePayment singlePayment)
            {
                var orderPayment = singlePayment;
            }
            else
            {
                var orderPayment = order.Payment;
            }


            string ownerOrPartner;

            //برسی این که فرد اونره یا پارتنر
            if (order.CustomerId == request.OrderId)
            {
                ownerOrPartner = "Owner";
            }
            else if (orderPayment == request.CustomerId)
            {
                ownerOrPartner = "Partner";
            }
            else
            {
                throw new CustomerOrderMismatchException();
            }

            //برسی این که اوردر پرداخت شده یا نه
            if (orderPayment.PaymentLog.Any(p => p.Status == PaymentStatus.Paid))
            {
                throw new OrderAlreadyPaidException();
            }
            else if (orderPayment.PaymentLog.Any(p => p.Status == PaymentStatus.Cancelled))
            {
                throw new CancelledOrderCanNotBePaidException();
            }




            //برسی این که قیمتی که میخواد پرداخت کنه بیشتر از چیزی که باید باشه نباشه

            //ارسال برای پرداخت



        }
    }

    public record SendToWallet();


}
