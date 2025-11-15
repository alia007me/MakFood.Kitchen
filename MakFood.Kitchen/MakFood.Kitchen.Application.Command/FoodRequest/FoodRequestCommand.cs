using MediatR;

namespace MakFood.Kitchen.Application.Command.FoodRequest
{
    public record FoodRequestCommand(Guid UserId,
                                     Guid ProductId,
                                     DateOnly TargetDate
        ) : IRequest<FoodRequestResponse>;


}
