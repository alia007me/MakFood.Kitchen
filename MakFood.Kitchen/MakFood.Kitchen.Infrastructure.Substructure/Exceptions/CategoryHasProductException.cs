namespace MakFood.Kitchen.Infrastructure.Substructure.Exceptions
{
    public class CategoryHasProductException : Exception
    {
        public CategoryHasProductException()
        {
        }

        public CategoryHasProductException(string entityName, Guid id) : base($"{entityName} with Id '{id}' cannot be removed because it has related items.")
        {
        }

        public CategoryHasProductException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}
