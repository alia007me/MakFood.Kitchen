namespace MakFood.Kitchen.Application.Command.Exceptions
{
    public class CancelledOrderCanNotBePaidException : Exception
    {
        public CancelledOrderCanNotBePaidException()
        {
        }

        public CancelledOrderCanNotBePaidException(string? message) : base(message)
        {
        }

        public CancelledOrderCanNotBePaidException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}