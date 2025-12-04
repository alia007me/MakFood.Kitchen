namespace MakFood.Kitchen.Domain.BussinesRules.Exceptions
{
    
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