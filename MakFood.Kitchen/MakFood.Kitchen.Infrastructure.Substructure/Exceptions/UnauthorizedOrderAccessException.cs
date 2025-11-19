namespace MakFood.Kitchen.Infrastructure.Substructure.Exceptions
{
    [Serializable]
    public class UnauthorizedOrderAccessException : Exception
    {
        public UnauthorizedOrderAccessException()
        {
        }

        public UnauthorizedOrderAccessException(string? message) : base(message)
        {
        }

        public UnauthorizedOrderAccessException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}