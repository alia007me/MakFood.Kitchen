namespace MakFood.Kitchen.Domain.BussinesRules.Exceptions
{
    public class FoodRequestDateMustBeInFutureException : Exception
    {
        public FoodRequestDateMustBeInFutureException()
        {
        }

        public FoodRequestDateMustBeInFutureException(string? message) : base(message)
        {
        }

        public FoodRequestDateMustBeInFutureException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}
