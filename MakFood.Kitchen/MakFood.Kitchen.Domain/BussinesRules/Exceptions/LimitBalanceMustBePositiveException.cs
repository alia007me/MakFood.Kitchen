namespace MakFood.Kitchen.Domain.BussinesRules.Exceptions
{
    
    internal class LimitBalanceMustBePositiveException : Exception
    {
        public LimitBalanceMustBePositiveException()
        {
        }

        public LimitBalanceMustBePositiveException(string? message) : base(message)
        {
        }

        public LimitBalanceMustBePositiveException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}