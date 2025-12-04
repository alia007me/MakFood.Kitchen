namespace MakFood.Kitchen.Domain.BussinesRules.Exceptions
{
    
    internal class TheCartItemMustExistInTheCartToBeDeletedException : Exception
    {
        public TheCartItemMustExistInTheCartToBeDeletedException()
        {
        }

        public TheCartItemMustExistInTheCartToBeDeletedException(string? message) : base(message)
        {
        }

        public TheCartItemMustExistInTheCartToBeDeletedException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}