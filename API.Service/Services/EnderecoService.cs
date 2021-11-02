using System;
using System.Threading.Tasks;
using API.Domain.Dtos.Endereco;
using API.Domain.Entities;
using API.Domain.Interfaces.Repositories;
using API.Domain.Interfaces.Services.Endereco;
using AutoMapper;

namespace API.Service.Services
{
    public class EnderecoService : IEnderecoService
    {
        private IEnderecoRepository _repository;
        private IMapper _mapper;

        public EnderecoService(IEnderecoRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<bool> DeleteAsync(Guid id)
        {
            return await _repository.DeleteAsync(id);
        }

        public async Task<EnderecoDto> GetAsync(Guid id)
        {
            var result = await _repository.GetAsync(id);
            return _mapper.Map<EnderecoDto>(result);
        }

        public async Task<EnderecoDto> GetByCEPAsync(string cep)
        {
            var result = await _repository.GetByCEPAsync(cep);
            return _mapper.Map<EnderecoDto>(result);
        }

        public async Task<EnderecoDto> PostAsync(EnderecoDto endereco)
        {
            var model = _mapper.Map<Endereco>(endereco);
            var result = await _repository.InsertAsync(model);
            return _mapper.Map<EnderecoDto>(result);
        }

        public async Task<EnderecoDto> PutAsync(EnderecoDto endereco)
        {
            var model = _mapper.Map<Endereco>(endereco);
            var result = await _repository.UpdateAsync(model);
            return _mapper.Map<EnderecoDto>(result);
        }
    }
}
