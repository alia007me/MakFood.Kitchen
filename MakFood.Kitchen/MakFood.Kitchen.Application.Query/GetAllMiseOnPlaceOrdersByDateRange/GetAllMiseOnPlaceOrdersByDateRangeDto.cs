using MakFood.Kitchen.Domain.Entities.DiscountAggrigate;
using MakFood.Kitchen.Domain.Entities.OrderAggrigate.OrderAggrigate.PaymentAggrigate.PaymentBase;

namespace MakFood.Kitchen.Application.Query.GetAllMiseOnPlaceOrdersByDateRange
{
    public record GetAllMiseOnPlaceOrdersByDateRangeDto(
                                                        Guid CustomerId,
                                                        Discount DiscountCode,
                                                        decimal DiscountPrice,
                                                        decimal Price,
                                                        decimal Payable,
                                                        Payment Payment
                                                        );

}
