namespace MakFood.Kitchen.Domain.BussinesRules.Exceptions
{
    
    internal class ProductDescriptionCanNotBeWhitespaceException : Exception
    {
        public ProductDescriptionCanNotBeWhitespaceException()
        {
        }

        public ProductDescriptionCanNotBeWhitespaceException(string? message) : base(message)
        {
        }

        public ProductDescriptionCanNotBeWhitespaceException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}