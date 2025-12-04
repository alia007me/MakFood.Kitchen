
namespace MakFood.Kitchen.Domain.BussinesRules.Exceptions
{
    
    internal class PriceMustBePositiveException : Exception
    {
        public PriceMustBePositiveException()
        {
        }

        public PriceMustBePositiveException(string? message) : base(message)
        {
        }

        public PriceMustBePositiveException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}