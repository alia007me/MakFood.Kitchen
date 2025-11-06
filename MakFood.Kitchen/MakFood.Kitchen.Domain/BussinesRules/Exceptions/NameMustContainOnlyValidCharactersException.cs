namespace MakFood.Kitchen.Domain.BussinesRules.Exceptions
{
    public class NameMustContainOnlyValidCharactersException : Exception
    {
        public NameMustContainOnlyValidCharactersException()
        {
        }

        public NameMustContainOnlyValidCharactersException(string? message) : base(message)
        {
        }

        public NameMustContainOnlyValidCharactersException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}
