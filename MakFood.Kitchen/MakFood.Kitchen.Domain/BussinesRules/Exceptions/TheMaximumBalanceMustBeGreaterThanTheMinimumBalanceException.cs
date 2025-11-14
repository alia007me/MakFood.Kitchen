namespace MakFood.Kitchen.Domain.BussinesRules.Exceptions
{
    [Serializable]
    internal class TheMaximumBalanceMustBeGreaterThanTheMinimumBalanceException : Exception
    {
        public TheMaximumBalanceMustBeGreaterThanTheMinimumBalanceException()
        {
        }

        public TheMaximumBalanceMustBeGreaterThanTheMinimumBalanceException(string? message) : base(message)
        {
        }

        public TheMaximumBalanceMustBeGreaterThanTheMinimumBalanceException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}