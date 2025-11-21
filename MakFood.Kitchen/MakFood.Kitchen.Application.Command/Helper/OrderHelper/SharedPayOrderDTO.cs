using MakFood.Kitchen.Domain.Entities.OrderAggrigate.OrderAggrigate.PaymentAggrigate.Enum;
namespace MakFood.Kitchen.Application.Command.Helper.OrderHelper
{
    public record SharedPayOrderDTO(Guid PayerId,
                                    Guid CustomerId,
                                    Guid partnerId,
                                    decimal OwnerPaidAmount,
                                    decimal PatnerPaidAmount,
                                    DateTime PaidTime,
                                    PaymentStatus PaymentStatus,
                                    PaymentStatus OwnerPaymentStatus,
                                    PaymentStatus PartnerPaymentStatus,
                                    decimal TotalAmount,
                                    decimal ReminingAmount
                                    ) : PayOrderDTO;

}
