using System.Linq;
using System.Threading.Tasks;
using API.Data.DatabaseContext;
using API.Domain.Entities;
using API.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace API.Data.Repositories
{
    public class EnderecoRepository : BaseRepository<Endereco>, IEnderecoRepository
    {
        private DbSet<Endereco> _dataset;
        public EnderecoRepository(DataContext context) : base(context)
        {
            _dataset = context.Set<Endereco>();
        }

        public async Task<Endereco> GetByCEPAsync(string cep)
        {
            return await _dataset.Include(e => e.Municipio)
                                 .ThenInclude(m => m.UF)
                                 .FirstOrDefaultAsync(e => e.CEP == cep);
        }
    }
}
