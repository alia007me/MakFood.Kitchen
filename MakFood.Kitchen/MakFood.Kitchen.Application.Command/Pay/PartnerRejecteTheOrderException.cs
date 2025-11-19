
namespace MakFood.Kitchen.Application.Command.Pay
{
    [Serializable]
    internal class PartnerRejecteTheOrderException : Exception
    {
        public PartnerRejecteTheOrderException()
        {
        }

        public PartnerRejecteTheOrderException(string? message) : base(message)
        {
        }

        public PartnerRejecteTheOrderException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}