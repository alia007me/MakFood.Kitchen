
namespace MakFood.Kitchen.Domain.BussinesRules.Exceptions
{
    
    internal class ProductIdCannotBeEmptyException : Exception
    {
        public ProductIdCannotBeEmptyException()
        {
        }

        public ProductIdCannotBeEmptyException(string? message) : base(message)
        {
        }

        public ProductIdCannotBeEmptyException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}