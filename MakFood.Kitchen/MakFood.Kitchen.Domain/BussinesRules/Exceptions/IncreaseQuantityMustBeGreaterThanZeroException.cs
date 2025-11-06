namespace MakFood.Kitchen.Domain.BussinesRules.Exceptions
{
    [Serializable]
    internal class IncreaseQuantityMustBeGreaterThanZeroException : Exception
    {
        public IncreaseQuantityMustBeGreaterThanZeroException()
        {
        }

        public IncreaseQuantityMustBeGreaterThanZeroException(string? message) : base(message)
        {
        }

        public IncreaseQuantityMustBeGreaterThanZeroException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}