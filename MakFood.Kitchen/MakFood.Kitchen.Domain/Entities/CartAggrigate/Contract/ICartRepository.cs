namespace MakFood.Kitchen.Domain.Entities.CartAggrigate.Contract
{
    public interface ICartRepository
    {
        public Task<Cart> GetCartById(Guid Id, CancellationToken ct, bool needToTrack = true);
        public void AddNewCart(Guid id);

    }
}
