namespace MakFood.Kitchen.Infrastructure.Substructure.Exceptions
{
    public class CategoryNotFoundException : Exception
    {
        public CategoryNotFoundException()
        {
        }

        public CategoryNotFoundException(Guid categoryId) : base($"Category with Id '{categoryId}' not found.")
        {
        }

        public CategoryNotFoundException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}
