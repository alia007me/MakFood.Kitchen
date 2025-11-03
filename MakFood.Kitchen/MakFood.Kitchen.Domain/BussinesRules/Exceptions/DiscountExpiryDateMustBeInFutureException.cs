namespace MakFood.Kitchen.Domain.BussinesRules.Exceptions
{
    [Serializable]
    internal class DiscountExpiryDateMustBeInFutureException : Exception
    {
        public DiscountExpiryDateMustBeInFutureException()
        {
        }

        public DiscountExpiryDateMustBeInFutureException(string? message) : base(message)
        {
        }

        public DiscountExpiryDateMustBeInFutureException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}