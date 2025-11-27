using MakFood.Kitchen.Domain.Entities.OrderAggrigate.OrderAggrigate.PaymentAggrigate.Enum;

namespace MakFood.Kitchen.Application.Command.AcceptOrder
{
    public record AcceptOrderCommandResponse(PaymentMathod PaymentMathod);
}
