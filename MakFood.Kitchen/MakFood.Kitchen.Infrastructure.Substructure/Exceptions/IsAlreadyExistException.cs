namespace MakFood.Kitchen.Infrastructure.Substructure.Exceptions
{
    public class IsAlreadyExistException : Exception
    {
        public IsAlreadyExistException()
        {
        }

        public IsAlreadyExistException(string? message) : base(message)
        {
        }

        public IsAlreadyExistException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}
