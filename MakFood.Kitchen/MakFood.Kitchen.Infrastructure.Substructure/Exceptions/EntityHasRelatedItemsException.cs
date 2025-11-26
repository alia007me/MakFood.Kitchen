namespace MakFood.Kitchen.Infrastructure.Substructure.Exceptions
{
    public class EntityHasRelatedItemsException : Exception
    {
        public EntityHasRelatedItemsException()
        {
        }

        public EntityHasRelatedItemsException(string entityName, Guid id) : base($"{entityName} with Id '{id}' cannot be removed because it has related items.")
        {
        }

        public EntityHasRelatedItemsException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}
