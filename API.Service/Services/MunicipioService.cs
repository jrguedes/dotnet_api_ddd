using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using API.Domain.Dtos.Municipio;
using API.Domain.Entities;
using API.Domain.Interfaces.Repositories;
using API.Domain.Interfaces.Services.Municipio;
using AutoMapper;

namespace API.Service.Services
{
    public class MunicipioService : IMunicipioService
    {
        private IMapper _mapper;
        private IMunicipioRepository _repository;

        public MunicipioService(IMunicipioRepository repository, IMapper mapper)
        {
            _mapper = mapper;
            _repository = repository;
        }
        public async Task<bool> DeleteAsync(Guid id)
        {
            return await _repository.DeleteAsync(id);
        }

        public async Task<IEnumerable<MunicipioDto>> GetAllAsync()
        {
            var result = await _repository.GetAsync();            
            return _mapper.Map<IEnumerable<MunicipioDto>>(result);
        }

        public async Task<MunicipioDto> GetAsync(Guid id)
        {
            var result = await _repository.GetAsync(id);
            return _mapper.Map<MunicipioDto>(result);
        }

        public async Task<MunicipioDto> GetByIBGEAsync(int codIBGE)
        {
            var result = await _repository.GetByCodIBGE(codIBGE);
            return _mapper.Map<MunicipioDto>(result);
        }

        public async Task<MunicipioDto> PostAsync(MunicipioDto municipio)
        {
            var model = _mapper.Map<Municipio>(municipio);
            var result = await _repository.InsertAsync(model);
            return _mapper.Map<MunicipioDto>(result);
        }

        public async Task<MunicipioDto> PutAsync(MunicipioDto municipio)
        {
            var model = _mapper.Map<Municipio>(municipio);
            var result = await _repository.UpdateAsync(model);
            return _mapper.Map<MunicipioDto>(result);
        }
    }
}
