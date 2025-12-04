namespace MakFood.Kitchen.Application.Command.Exceptions
{
    public class ThereIsNoCartItemInCartException : Exception
    {
        public ThereIsNoCartItemInCartException()
        {
        }

        public ThereIsNoCartItemInCartException(string? message) : base(message)
        {
        }

        public ThereIsNoCartItemInCartException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}