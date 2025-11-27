namespace MakFood.Kitchen.Domain.BussinesRules.Exceptions
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