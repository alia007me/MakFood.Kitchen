using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakFood.Kitchen.Infrastructure.Persistence.Context
{
    public interface IUnitOfWork
    {
        public Task<int> Commit(CancellationToken ct);
    }
}
