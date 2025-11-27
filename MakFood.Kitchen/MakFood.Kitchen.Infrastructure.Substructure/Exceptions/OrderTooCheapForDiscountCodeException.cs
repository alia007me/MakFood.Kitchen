namespace MakFood.Kitchen.Infrastructure.Substructure.Exceptions
{
    [Serializable]
    public class OrderTooCheapForDiscountCodeException : Exception
    {
        public OrderTooCheapForDiscountCodeException()
        {
        }

        public OrderTooCheapForDiscountCodeException(string? message) : base(message)
        {
        }

        public OrderTooCheapForDiscountCodeException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}