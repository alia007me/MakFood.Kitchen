namespace MakFood.Kitchen.Domain.BussinesRules.Exceptions
{
    public class PayAmountMustBePositiveException : Exception
    {
        public PayAmountMustBePositiveException()
        {
        }

        public PayAmountMustBePositiveException(string? message) : base(message)
        {
        }

        public PayAmountMustBePositiveException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}
