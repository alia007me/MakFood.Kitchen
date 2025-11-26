
namespace MakFood.Kitchen.Domain.Entities.OrderAggrigate.OrderAggrigate.PaymentAggrigate
{
    [Serializable]
    internal class YouPaidThisOrderException : Exception
    {
        public YouPaidThisOrderException()
        {
        }

        public YouPaidThisOrderException(string? message) : base(message)
        {
        }

        public YouPaidThisOrderException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}