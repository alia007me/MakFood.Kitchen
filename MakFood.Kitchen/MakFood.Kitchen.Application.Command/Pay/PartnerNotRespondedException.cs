
namespace MakFood.Kitchen.Application.Command.Pay
{
    [Serializable]
    internal class PartnerNotRespondedException : Exception
    {
        public PartnerNotRespondedException()
        {
        }

        public PartnerNotRespondedException(string? message) : base(message)
        {
        }

        public PartnerNotRespondedException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}