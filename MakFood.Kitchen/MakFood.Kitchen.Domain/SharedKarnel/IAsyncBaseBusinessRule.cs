namespace MakFood.Kitchen.Domain.SharedKarnel
{
    public interface IAsyncBaseBusinessRule 
    {
        Task<bool> Check(CancellationToken ct);
        Exception Throws();
    }
}
