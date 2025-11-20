namespace MakFood.Kitchen.Infrastructure.Substructure.Exceptions
{
    public class EntityHasRelatedItemsException : Exception
    {
        public EntityHasRelatedItemsException()
        {
        }

        public EntityHasRelatedItemsException(string? message) : base(message)
        {
        }

        public EntityHasRelatedItemsException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}
