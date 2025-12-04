namespace MakFood.Kitchen.Domain.BussinesRules.Exceptions
{
    
    internal class ThumbnailPathCanNotBeWhitespaceException : Exception
    {
        public ThumbnailPathCanNotBeWhitespaceException()
        {
        }

        public ThumbnailPathCanNotBeWhitespaceException(string? message) : base(message)
        {
        }

        public ThumbnailPathCanNotBeWhitespaceException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}