namespace MakFood.Kitchen.Infrastructure.Persistence.Context
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _dbContext;
        public UnitOfWork(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<int> Commit(CancellationToken ct)
        {
            return await _dbContext.SaveChangesAsync(ct);
        }
    }
}
