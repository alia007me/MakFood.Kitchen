namespace MakFood.Kitchen.Domain.BussinesRules.Exceptions
{
    public class PaymentMethodMustNotBeChangedAfterPaymentStartedException : Exception
    {
        public PaymentMethodMustNotBeChangedAfterPaymentStartedException()
        {
        }

        public PaymentMethodMustNotBeChangedAfterPaymentStartedException(string? message) : base(message)
        {
        }

        public PaymentMethodMustNotBeChangedAfterPaymentStartedException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}
