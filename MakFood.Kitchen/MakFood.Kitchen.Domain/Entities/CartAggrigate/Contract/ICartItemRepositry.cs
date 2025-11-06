namespace MakFood.Kitchen.Domain.Entities.CartAggrigate.Contract
{
    public interface ICartItemRepositry
    {
        public Task<bool> IsCartItemExist(CartItem cartItem);
    }
}
