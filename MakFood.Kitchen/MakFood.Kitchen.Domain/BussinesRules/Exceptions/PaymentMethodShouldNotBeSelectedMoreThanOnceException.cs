namespace MakFood.Kitchen.Domain.BussinesRules.Exceptions
{
    [Serializable]
    public class PaymentMethodShouldNotBeSelectedMoreThanOnceException : Exception
    {
        public PaymentMethodShouldNotBeSelectedMoreThanOnceException()
        {
        }

        public PaymentMethodShouldNotBeSelectedMoreThanOnceException(string? message) : base(message)
        {
        }

        public PaymentMethodShouldNotBeSelectedMoreThanOnceException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}