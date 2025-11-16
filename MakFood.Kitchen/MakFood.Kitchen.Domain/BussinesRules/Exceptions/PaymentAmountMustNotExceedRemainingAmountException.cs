namespace MakFood.Kitchen.Domain.BussinesRules.Exceptions
{
    public class PaymentAmountMustNotExceedRemainingAmountException : Exception
    {
        public PaymentAmountMustNotExceedRemainingAmountException()
        {
        }

        public PaymentAmountMustNotExceedRemainingAmountException(string? message) : base(message)
        {
        }

        public PaymentAmountMustNotExceedRemainingAmountException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}
