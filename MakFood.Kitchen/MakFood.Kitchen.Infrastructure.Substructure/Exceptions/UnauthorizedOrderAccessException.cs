
namespace MakFood.Kitchen.Application.Command.CancelOrder
{
    [Serializable]
    public class UnauthorizedOrderAccessException : Exception
    {
        public UnauthorizedOrderAccessException()
        {
        }

        public UnauthorizedOrderAccessException(string? message) : base(message)
        {
        }

        public UnauthorizedOrderAccessException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}