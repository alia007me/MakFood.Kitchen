namespace MakFood.Kitchen.Infrastructure.Substructure.Exceptions
{
    public class IsAlreadyExistException : Exception
    {
        public IsAlreadyExistException()
        {
        }

        public IsAlreadyExistException(string value) : base($"'{value}' already exists.")
        {
        }


        public IsAlreadyExistException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }

    public class SubCategoryIsExistException : IsAlreadyExistException
    {
        public SubCategoryIsExistException() : base("Sub Category")
        {
        }
    }
    public class CategoryIsExistException : IsAlreadyExistException
    {
        public CategoryIsExistException() : base("Category")
        {
            
        }
    }

}
