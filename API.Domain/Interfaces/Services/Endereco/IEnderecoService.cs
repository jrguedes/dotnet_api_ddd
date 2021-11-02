using System;
using System.Threading.Tasks;
using API.Domain.Dtos.Endereco;

namespace API.Domain.Interfaces.Services.Endereco
{
    public interface IEnderecoService
    {
         Task<EnderecoDto> GetAsync(Guid id);
         Task<EnderecoDto> GetByCEPAsync(string cep);

         Task<EnderecoDto> PostAsync(EnderecoDto endereco);
         Task<EnderecoDto> PutAsync(EnderecoDto endereco);

         Task<bool> DeleteAsync(Guid id);

         
    }
}
