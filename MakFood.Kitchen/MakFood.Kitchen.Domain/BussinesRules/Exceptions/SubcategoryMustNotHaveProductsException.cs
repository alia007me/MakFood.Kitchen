namespace MakFood.Kitchen.Domain.BussinesRules.Exceptions
{
    internal class SubcategoryMustNotHaveProductsException : Exception
    {
        public SubcategoryMustNotHaveProductsException() { }
        public SubcategoryMustNotHaveProductsException(string? message) : base(message)
        {
        }

        public SubcategoryMustNotHaveProductsException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}
