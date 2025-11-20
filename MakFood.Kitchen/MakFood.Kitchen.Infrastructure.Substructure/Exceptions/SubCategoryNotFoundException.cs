namespace MakFood.Kitchen.Infrastructure.Substructure.Exceptions
{
    [Serializable]
    public class SubCategoryNotFoundException : Exception
    {
        public SubCategoryNotFoundException()
        {
        }

        public SubCategoryNotFoundException(string? message) : base(message)
        {
        }

        public SubCategoryNotFoundException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}