namespace MakFood.Kitchen.Infrastructure.Persistence.Context.Transactions
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        public UnitOfWork( ApplicationDbContext context)
        {
           
            _context = context;
        }
       public async Task<int> commit(CancellationToken ct)
        {
            return await _context.SaveChangesAsync(ct);
        }
    }
}
