
using MakFood.Kitchen.Domain.Entities.OrderAggrigate.OrderAggrigate.PaymentAggrigate.Enum;
namespace MakFood.Kitchen.Application.Command.Helper.OrderHelper
{
    public record SinglePaymentDTO(Guid PayerId,
                                   decimal PaidAmount,
                                   DateTime PaidTime,
                                   PaymentStatus OwnerPaymentStatus,
                                   decimal TotalAmount,
                                   decimal RemainingAmount
                                   ) : PayOrderDTO;
}

