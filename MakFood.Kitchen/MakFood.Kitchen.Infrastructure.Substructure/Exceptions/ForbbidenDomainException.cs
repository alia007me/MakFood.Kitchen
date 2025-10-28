namespace MakFood.Kitchen.Infrastructure.Substructure.Exceptions
{
    public class ForbbidenDomainException : DomainException
    {
        public ForbbidenDomainException()
        {
        }

        public ForbbidenDomainException(string? message) : base(message)
        {
        }

        public ForbbidenDomainException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}
