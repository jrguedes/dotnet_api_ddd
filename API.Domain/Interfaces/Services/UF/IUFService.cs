using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using API.Domain.Dtos.UF;

namespace API.Domain.Interfaces.Services.UF
{
    public interface IUFService
    {
         Task<UFDto> GetAsync(Guid id);
         Task<IEnumerable<UFDto>> GetAllAsync();
    }
}
