using MediatR;


namespace MakFood.Kitchen.Application.Command.CancelOrder
{
    public record CancelOrderCommand( Guid CustomerId,Guid OrderId) : IRequest<CancelOrderResponse>;
}
