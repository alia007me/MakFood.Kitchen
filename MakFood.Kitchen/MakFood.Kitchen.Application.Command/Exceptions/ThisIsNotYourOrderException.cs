namespace MakFood.Kitchen.Application.Command.Exceptions
{
    [Serializable]
    public class ThisIsNotYourOrderException : Exception
    {
        public ThisIsNotYourOrderException()
        {
        }

        public ThisIsNotYourOrderException(string? message) : base(message)
        {
        }

        public ThisIsNotYourOrderException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}