using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using API.Domain.Dtos.Municipio;

namespace API.Domain.Interfaces.Services.Municipio
{
    public interface IMunicipioService
    {
        Task<MunicipioDto> GetAsync(Guid id);
        Task<MunicipioDto> GetByIBGEAsync(int codIBGE);
        Task<IEnumerable<MunicipioDto>> GetAllAsync();
        Task<MunicipioDto> PostAsync(MunicipioDto municipio);
        Task<MunicipioDto> PutAsync(MunicipioDto municipio);
        Task<bool> DeleteAsync(Guid id);

    }
}
