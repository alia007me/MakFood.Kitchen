namespace MakFood.Kitchen.Application.Command.Exceptions
{
    [Serializable]
    public class OrderAlreadyPaidException : Exception
    {
        public OrderAlreadyPaidException()
        {
        }

        public OrderAlreadyPaidException(string? message) : base(message)
        {
        }

        public OrderAlreadyPaidException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}