namespace MakFood.Kitchen.Infrastructure.Substructure.Exceptions
{
    public class CustomerOrderMismatchException : Exception
    {
        public CustomerOrderMismatchException()
        {
        }

        public CustomerOrderMismatchException(string? message) : base(message)
        {
        }

        public CustomerOrderMismatchException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}
