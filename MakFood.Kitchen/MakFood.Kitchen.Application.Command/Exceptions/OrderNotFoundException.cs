using MakFood.Kitchen.Infrastructure.Substructure.Exceptions;

namespace MakFood.Kitchen.Application.Command.Exceptions
{
    [Serializable]
    internal class OrderNotFoundException : NotFoundException
    {
        public OrderNotFoundException()
        {
        }

        public OrderNotFoundException(string? message) : base(message)
        {
        }

        public OrderNotFoundException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}