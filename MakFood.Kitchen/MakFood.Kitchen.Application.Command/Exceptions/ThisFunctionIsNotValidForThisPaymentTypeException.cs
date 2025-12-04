namespace MakFood.Kitchen.Application.Command.Exceptions
{
    
    internal class ThisFunctionIsNotValidForThisPaymentTypeException : Exception
    {
        public ThisFunctionIsNotValidForThisPaymentTypeException()
        {
        }

        public ThisFunctionIsNotValidForThisPaymentTypeException(string? message) : base(message)
        {
        }

        public ThisFunctionIsNotValidForThisPaymentTypeException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}