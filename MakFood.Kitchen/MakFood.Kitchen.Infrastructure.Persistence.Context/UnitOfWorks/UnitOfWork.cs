using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakFood.Kitchen.Infrastructure.Persistence.Context.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        public readonly ApplicationDbContext _Context;
        public UnitOfWork(ApplicationDbContext context)
        {
            _Context = context;
        }
        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        {
           return await _Context.SaveChangesAsync(cancellationToken);
        }
    }
}
