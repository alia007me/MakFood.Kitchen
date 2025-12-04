namespace MakFood.Kitchen.Application.Command.Exceptions
{
    public class CustomerNotAuthorizedForDiscountException : Exception
    {
        public CustomerNotAuthorizedForDiscountException()
        {
        }

        public CustomerNotAuthorizedForDiscountException(string? message) : base(message)
        {
        }

        public CustomerNotAuthorizedForDiscountException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}