namespace MakFood.Kitchen.Domain.BussinesRules.Exceptions
{
    
    internal class QuantityCannotBeDecreasedBeyondAvalibleException : Exception
    {
        public QuantityCannotBeDecreasedBeyondAvalibleException()
        {
        }

        public QuantityCannotBeDecreasedBeyondAvalibleException(string? message) : base(message)
        {
        }

        public QuantityCannotBeDecreasedBeyondAvalibleException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}