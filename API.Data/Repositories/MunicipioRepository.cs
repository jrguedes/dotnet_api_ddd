using System.Linq;
using System.Threading.Tasks;
using API.Data.DatabaseContext;
using API.Domain.Entities;
using API.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace API.Data.Repositories
{
    public class MunicipioRepository : BaseRepository<Municipio>, IMunicipioRepository
    {
        private DbSet<Municipio> _dataset;
        public MunicipioRepository(DataContext context) : base(context)
        {
            _dataset = context.Set<Municipio>();
        }

        public async Task<Municipio> GetByCodIBGE(int codIBGE)
        {
            return await _dataset.Include(m => m.UF).FirstOrDefaultAsync(m => m.CodIBGE == codIBGE);
        }
    }
}
