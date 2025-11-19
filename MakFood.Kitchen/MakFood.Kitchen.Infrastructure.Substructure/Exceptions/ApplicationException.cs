namespace MakFood.Kitchen.Infrastructure.Substructure.Exceptions
{
    public class ApplicationBaseException : Exception
    {
        public ApplicationBaseException()
        {
        }

        public ApplicationBaseException(string? message) : base(message)
        {
        }

        public ApplicationBaseException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}
