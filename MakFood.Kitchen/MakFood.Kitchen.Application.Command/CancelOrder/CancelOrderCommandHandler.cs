using MakFood.Kitchen.Application.Command.CancelOrder;
using MakFood.Kitchen.Domain.Entities.OrderAggrigate.OrderAggrigate;
using MakFood.Kitchen.Domain.Entities.OrderAggrigate.OrderAggrigate.Contract;
using MakFood.Kitchen.Domain.Entities.OrderAggrigate.OrderAggrigate.OrederState;
using MakFood.Kitchen.Infrastructure.Persistence.Context.Transactions;
using MakFood.Kitchen.Infrastructure.Substructure.Exceptions;
using MediatR;


namespace MakFood.Kitchen.Application.Command.CancelOrder
{
    public class CancelOrderCommandHandler : IRequestHandler<CancelOrderCommand, CancelOrderResponse>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CancelOrderCommandHandler(IOrderRepository orderRepository, IUnitOfWork unitOfWork)
        {
            _orderRepository = orderRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<CancelOrderResponse> Handle(CancelOrderCommand request, CancellationToken ct)
        {
            var targetOrder = await _orderRepository.GetOrderByIdAsync(request.OrderId,ct);

            ValidateOrderExists(targetOrder);

            ValidateOrderOwnership(targetOrder!,request.CustomerId);

            ValidateCancelableOrder(targetOrder!);

            targetOrder!.Cancelled();

            await _unitOfWork.Commit(ct);

            return new CancelOrderResponse { Success = true , OrderId = request.OrderId };
        }

        private void ValidateOrderOwnership(Order targetOrder,Guid ownerId)
        {
            if (targetOrder.CustomerId != ownerId) throw new UnauthorizedOrderAccessException();
        }

        private void ValidateOrderExists(Order? targetOrder)
        {
            if (targetOrder == null) throw new OrderNotFoundException();
        }

        private void ValidateCancelableOrder(Order targetOrder)
        {
            if (targetOrder.CurrentState.Status != OrderStatus.Created) throw new OrderNotCancelableException();
        }
    }
}
