using MakFood.Kitchen.Infrastructure.Substructure.Exceptions;

namespace MakFood.Kitchen.Application.Command.RemoveItemFromCart
{
    [Serializable]
    internal class CartItemNotFoundException : NotFoundException
    {
        public CartItemNotFoundException()
        {
        }

        public CartItemNotFoundException(string? message) : base(message)
        {
        }

        public CartItemNotFoundException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}