namespace MakFood.Kitchen.Domain.BussinesRules.Exceptions
{
    [Serializable]
    internal class DiscountPercentageMustBeBetweenZeroAndOnehundredException : Exception
    {
        public DiscountPercentageMustBeBetweenZeroAndOnehundredException()
        {
        }

        public DiscountPercentageMustBeBetweenZeroAndOnehundredException(string? message) : base(message)
        {
        }

        public DiscountPercentageMustBeBetweenZeroAndOnehundredException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}