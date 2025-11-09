using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakFood.Kitchen.Infrastructure.Persistence.Context.Transactions
{
    public interface IUnitOfWork
    {
        public Task<int> commit(CancellationToken ct);
    }

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
