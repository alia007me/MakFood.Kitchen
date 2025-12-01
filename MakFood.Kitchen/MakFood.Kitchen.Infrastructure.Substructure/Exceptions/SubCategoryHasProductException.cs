namespace MakFood.Kitchen.Infrastructure.Substructure.Exceptions
{
    public class SubCategoryHasProductException : Exception
    {
        public SubCategoryHasProductException()
        {
        }

        public SubCategoryHasProductException(string entityName, Guid id) : base($"{entityName} with Id '{id}' cannot be removed because it has related items.")
        {
        }

        public SubCategoryHasProductException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}
