namespace MakFood.Kitchen.Infrastructure.Substructure.Exceptions
{
    public class EntityHasRelatedItemsException : Exception
    {
        private const string DefaultMessage = "Entity cannot be deleted because it has related items.";
        public EntityHasRelatedItemsException() : base(DefaultMessage) { }
        public EntityHasRelatedItemsException(string? message) : base(message ?? DefaultMessage)
        {
        }

        public EntityHasRelatedItemsException(string? message, Exception? innerException) : base(message ?? DefaultMessage, innerException)
        {
        }
    }

   
    
}
