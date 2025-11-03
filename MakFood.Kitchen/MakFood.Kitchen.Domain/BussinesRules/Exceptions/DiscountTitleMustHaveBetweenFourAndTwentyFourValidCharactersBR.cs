namespace MakFood.Kitchen.Domain.BussinesRules.Exceptions
{
    [Serializable]
    internal class DiscountTitleMustHaveBetweenFourAndTwentyFourValidCharactersBR : Exception
    {
        public DiscountTitleMustHaveBetweenFourAndTwentyFourValidCharactersBR()
        {
        }

        public DiscountTitleMustHaveBetweenFourAndTwentyFourValidCharactersBR(string? message) : base(message)
        {
        }

        public DiscountTitleMustHaveBetweenFourAndTwentyFourValidCharactersBR(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}