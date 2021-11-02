using System.Linq;
using API.Data.DatabaseContext;
using API.Domain.Entities;
using API.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace API.Data.Repositories
{
    public class UFRepository : BaseRepository<UF>, IUFRepository
    {
        private DbSet<UF> _dataset;
        public UFRepository(DataContext context): base(context)
        {
            _dataset = context.Set<UF>();            
        }
    }
}
