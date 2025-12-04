using MakFood.Kitchen.Application.Command.Exceptions;
using MakFood.Kitchen.Domain.Entities.DiscountAggrigate;
using MakFood.Kitchen.Infrastructure.Substructure.Exceptions;

namespace MakFood.Kitchen.Application.Command.Helper.DiscountCalculatorHelper
{
    public static class DiscountCalculatorHelper
    {
        public static decimal AmountCalculator(decimal amount, Discount? discount, Guid customerId)
        {
            if (discount == null) return amount;

            DiscountValidation(discount, customerId);

            if (amount < discount.MinimumBalance)
            {
                throw new OrderTooCheapForDiscountCodeException();
            }
            else if (amount > discount.MaximumBalance)
            {
                return (amount - (discount.MaximumBalance * discount.Percent / 100));
            }
            else
            {
                return (amount * (discount.Percent / 100));
            }
        }
        public static void DiscountValidation(Discount discount, Guid cartId)
        {
            if (discount.ExpiryDate < DateOnly.FromDateTime(DateTime.Now))
            {
                throw new DiscountCodeExpiredException();
            }
            else if (!discount.AvailableForCustomer(cartId))
            {
                throw new CustomerNotAuthorizedForDiscountException();
            }
        }
    }
}
