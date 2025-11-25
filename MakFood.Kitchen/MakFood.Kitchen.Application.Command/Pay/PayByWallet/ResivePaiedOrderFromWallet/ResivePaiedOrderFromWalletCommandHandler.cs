using MakFood.Kitchen.Application.Command.Exceptions;
using MakFood.Kitchen.Application.Command.Helper.ChainValidator;
using MakFood.Kitchen.Application.Command.Helper.OrderHelper;
using MakFood.Kitchen.Domain.Entities.OrderAggrigate.OrderAggrigate;
using MakFood.Kitchen.Domain.Entities.OrderAggrigate.OrderAggrigate.Contract;
using MakFood.Kitchen.Domain.Entities.OrderAggrigate.OrderAggrigate.PaymentAggrigate;
using MakFood.Kitchen.Infrastructure.Persistence.Context.Transactions;
using MakFood.Kitchen.Infrastructure.Substructure.Exceptions;
using MediatR;

namespace MakFood.Kitchen.Application.Command.Pay.PayByWallet.ResivePaiedOrderFromWallet
{
    public class ResivePaiedOrderFromWalletCommandHandler : IRequestHandler<ResivePaiedOrderFromWalletCommand, ResivePaiedOrderFromWalletResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IOrderRepository _orderRepository;
        public ResivePaiedOrderFromWalletCommandHandler(IUnitOfWork unitOfWork, IOrderRepository orderRepository)
        {
            _unitOfWork = unitOfWork;
            _orderRepository = orderRepository;
        }
        public async Task<ResivePaiedOrderFromWalletResponse> Handle(ResivePaiedOrderFromWalletCommand request, CancellationToken ct)
        {
            var order = await _orderRepository.GetOrderByIdAsync(request.OrderId, ct);
            validate(order, request);
            if (request.IsPaied) {
                order.Payment.Pay(request.UserId);
                await _unitOfWork.Commit(ct);
            }
            return response(order, request.UserId);

        }
        #region behaviar
        private ResivePaiedOrderFromWalletResponse response(Order order, Guid customerId)
        {
            PayOrderDTO result;
            if (order.Payment is SharedPayment sharedPayment) {
                result = new SharedPayOrderDTO(customerId, sharedPayment.OwnerId, sharedPayment.PartnerId, sharedPayment.OwnerPaidAmount,
                                                   sharedPayment.PartnerPaidAmount, sharedPayment.PaymentStatus.CreationDateTime,
                                                   sharedPayment.PaymentStatus.Status, sharedPayment.OwnerPaymentStatus,
                                                   sharedPayment.PartnerPaymentStatus, sharedPayment.TotalAmount, sharedPayment.ReminingAmount);
            }
            else if (order.Payment is SinglePayment singlePayment) {
                result = new SinglePaymentDTO(singlePayment.OwnerId, singlePayment.OwnerPaidAmount, singlePayment.PaymentStatus.CreationDateTime,
                                                  singlePayment.PaymentStatus.Status, singlePayment.TotalAmount, singlePayment.ReminingAmount);
            }
            else throw new InvalidPaymentTypeException();

            return new ResivePaiedOrderFromWalletResponse(result);
        }
        private void validate(Order order, ResivePaiedOrderFromWalletCommand request)
        {
            order.ToValidate()
                 .Then<NotFoundException>(c => c is null)
                 .Then<ThisIsNotYourOrderException>(c => !(c.Payment.NeedToPay(request.UserId)))
                 .Then<PartnerNotRespondedException>(c => c.Payment is SharedPayment sharedPayment && sharedPayment.PartnerApproved is null)
                 .Then<PartnerRejecteTheOrderException>(c => c.Payment is SharedPayment sp && sp.PartnerApproved == false)
                 .Validate(ValidationPolicy.ThrowIfErrorOccured)
                 .ThrowFirstIfRequired();
        }
        #endregion
    }
}
