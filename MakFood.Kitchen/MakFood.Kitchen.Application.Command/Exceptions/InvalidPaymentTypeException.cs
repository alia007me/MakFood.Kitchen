namespace MakFood.Kitchen.Application.Command.Exceptions
{
    
    internal class InvalidPaymentTypeException : ApplicationException
    {
        public InvalidPaymentTypeException()
        {
        }

        public InvalidPaymentTypeException(string? message) : base(message)
        {
        }

        public InvalidPaymentTypeException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}