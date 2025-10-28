namespace MakFood.Kitchen.Infrastructure.Substructure.Exceptions
{
    public class ValidationFailedDomainException : DomainException
    {
        public ValidationFailedDomainException()
        {
        }

        public ValidationFailedDomainException(string? message) : base(message)
        {
        }

        public ValidationFailedDomainException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}
