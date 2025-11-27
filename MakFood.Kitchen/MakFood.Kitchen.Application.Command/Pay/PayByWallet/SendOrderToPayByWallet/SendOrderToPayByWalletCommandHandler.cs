using MakFood.Kitchen.Application.Command.Exceptions;
using MakFood.Kitchen.Application.Command.Helper.ChainValidator;
using MakFood.Kitchen.Domain.Entities.CartAggrigate.Contract;
using MakFood.Kitchen.Domain.Entities.OrderAggrigate.OrderAggrigate;
using MakFood.Kitchen.Domain.Entities.OrderAggrigate.OrderAggrigate.Contract;
using MakFood.Kitchen.Domain.Entities.OrderAggrigate.OrderAggrigate.PaymentAggrigate;
using MakFood.Kitchen.Infrastructure.Persistence.Context.Transactions;
using MakFood.Kitchen.Infrastructure.Substructure.Exceptions;
using MediatR;

namespace MakFood.Kitchen.Application.Command.Pay.PayByWallet.SendOrderToPayByWallet
{
    public class SendOrderToPayByWalletCommandHandler : IRequestHandler<SendOrderToPayByWalletCommand, SendOrderToPayByWalletResponse>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly ICartRepository _cartRepository;
        private readonly IUnitOfWork _unitOfWork;

        public SendOrderToPayByWalletCommandHandler(IOrderRepository orderRepository, ICartRepository cartRepository,
                                                 IUnitOfWork unitOfWork)
        {
            _orderRepository = orderRepository;
            _cartRepository = cartRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<SendOrderToPayByWalletResponse> Handle(SendOrderToPayByWalletCommand request, CancellationToken ct)
        {
            var order = await _orderRepository.GetOrderByIdAsync(request.OrderId, ct);
            validate(order, request);
            order.Payment.Pay(request.CustomerId);
            await _unitOfWork.Commit(ct);
            return await response(order, request.CustomerId);
        }
        #region
        private async Task validate(Order order, SendOrderToPayByWalletCommand request)
        {

            order.ToValidate()
                 .Then<NotFoundException>(c => c is null)
                 .Then<ThisIsNotYourOrderException>(c => !(c.Payment.NeedToPay(request.CustomerId)))
                 .Then<PartnerNotRespondedException>(c => c.Payment is SharedPayment sharedPayment && sharedPayment.PartnerApproved is null)
                 .Then<PartnerRejecteTheOrderException>(c => c.Payment is SharedPayment sp && sp.PartnerApproved == false)
                 .Validate(ValidationPolicy.ThrowIfErrorOccured)
                 .ThrowFirstIfRequired();
        }

        private async Task<SendOrderToPayByWalletResponse> response(Order order, Guid Customerid)
        {
            decimal amount;
            if (order.Payment is SharedPayment sharedPayment) {
                amount = sharedPayment.GetPaymentAmountById(Customerid);
            }
            else if (order.Payment is SinglePayment singlePayment) {
                amount = singlePayment.OwnerAmount;
            }

            else throw new InvalidPaymentTypeException();

            return new SendOrderToPayByWalletResponse(Customerid, order.Id, amount);
        }
        #endregion
    }
}
