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
}
