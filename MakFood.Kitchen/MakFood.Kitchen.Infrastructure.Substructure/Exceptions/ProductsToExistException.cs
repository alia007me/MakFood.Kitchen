namespace MakFood.Kitchen.Infrastructure.Substructure.Exceptions
{
    [Serializable]
    public class ProductsToExistException : Exception
    {
        public ProductsToExistException()
        {
        }

        public ProductsToExistException(string? message) : base(message)
        {
        }

        public ProductsToExistException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}