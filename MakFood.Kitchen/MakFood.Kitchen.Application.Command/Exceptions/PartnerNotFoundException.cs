namespace MakFood.Kitchen.Application.Command.Exceptions
{
    
    public class PartnerNotFoundException : Exception
    {
        public PartnerNotFoundException()
        {
        }

        public PartnerNotFoundException(string? message) : base(message)
        {
        }

        public PartnerNotFoundException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}