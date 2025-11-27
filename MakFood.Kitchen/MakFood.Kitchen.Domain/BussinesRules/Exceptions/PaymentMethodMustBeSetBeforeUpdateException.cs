namespace MakFood.Kitchen.Domain.BussinesRules.Exceptions
{
    public class PaymentMethodMustBeSetBeforeUpdateException : Exception
    {
        public PaymentMethodMustBeSetBeforeUpdateException()
        {
        }

        public PaymentMethodMustBeSetBeforeUpdateException(string? message) : base(message)
        {
        }

        public PaymentMethodMustBeSetBeforeUpdateException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}
