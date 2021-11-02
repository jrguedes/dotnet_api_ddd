using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using API.Domain.Dtos.UF;
using API.Domain.Interfaces.Repositories;
using API.Domain.Interfaces.Services.UF;
using AutoMapper;

namespace API.Service.Services
{
    public class UFService : IUFService
    {
        private IUFRepository _repository;
        private IMapper _mapper;

        public UFService(IUFRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<UFDto>> GetAllAsync()
        {
            var result = await _repository.GetAsync();
            var dtos = _mapper.Map<IEnumerable<UFDto>>(result);
            return dtos;
        }

        public async Task<UFDto> GetAsync(Guid id)
        {
            var result = await _repository.GetAsync();
            var dto = _mapper.Map<UFDto>(result);
            return dto;
        }
    }
}
