namespace MakFood.Kitchen.Application.Command.Exceptions
{
    public class DiscountCodeExpiredException : Exception
    {
        public DiscountCodeExpiredException()
        {
        }

        public DiscountCodeExpiredException(string? message) : base(message)
        {
        }

        public DiscountCodeExpiredException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}