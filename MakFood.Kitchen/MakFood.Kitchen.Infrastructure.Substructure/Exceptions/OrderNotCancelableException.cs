
namespace MakFood.Kitchen.Application.Command.CancelOrder
{
    [Serializable]
    public class OrderNotCancelableException : Exception
    {
        public OrderNotCancelableException()
        {
        }

        public OrderNotCancelableException(string? message) : base(message)
        {
        }

        public OrderNotCancelableException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}