using MakFood.Kitchen.Application.Command.Exceptions;
using MakFood.Kitchen.Domain.Entities.OrderAggrigate.OrderAggrigate.Contract;
using MakFood.Kitchen.Domain.Entities.OrderAggrigate.OrderAggrigate.PaymentAggrigate;
using MakFood.Kitchen.Domain.Entities.OrderAggrigate.OrderAggrigate.PaymentAggrigate.Enum;
using MakFood.Kitchen.Domain.Entities.OrderAggrigate.OrderAggrigate.PaymentAggrigate.PaymentBase;
using MakFood.Kitchen.Infrastructure.Persistence.Context.Transactions;
using MediatR;

namespace MakFood.Kitchen.Application.Command.AcceptOrder
{
    public class AcceptOrderComadHandler : IRequestHandler<AcceptOrderCommand, AcceptOrderCommandResponse>
    {
        private readonly IOrderRepository _orderRepository;
        public readonly IUnitOfWork _unitOfWork;

        public AcceptOrderComadHandler(IOrderRepository orderRepository, IUnitOfWork unitOfWork)
        {
            _orderRepository = orderRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<AcceptOrderCommandResponse> Handle(AcceptOrderCommand command, CancellationToken ct)
        {
            var payment = await GetSharedPayment(command.OrderId, ct);

            payment.AproveOrder(command.PartnerApprove, command.PaymentMathod);

            await _unitOfWork.Commit(ct);

            return new AcceptOrderCommandResponse(payment.PartnerPaymentMethod!.Value);
        }

        #region Private Methods

        private async Task<SharedPayment> GetSharedPayment(Guid orderId, CancellationToken ct)
        {
            var order = await _orderRepository.GetOrderByIdAsync(orderId, ct);

            if (order is null)
                throw new OrderNotFoundException("Order not found");

            CheckPaymentIsShared(order.Payment);

            return (order.Payment as SharedPayment)!;
        }

        private void CheckPaymentIsShared(Payment payment)
        {
            if (payment.PaymentType != PaymentType.Shared)
                throw new ThisFunctionIsNotValidForThisPaymentTypeException();
        }


        #endregion
    }
}
