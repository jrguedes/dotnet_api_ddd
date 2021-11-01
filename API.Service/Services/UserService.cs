using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using API.Domain.Dtos.User;
using API.Domain.Entities;
using API.Domain.Interfaces.Repositories;
using API.Domain.Interfaces.Services;
using AutoMapper;

namespace API.Service.Services
{
    public class UserService : IUserService
    {
        private IRepository<User> _repository;
        private readonly IMapper _mapper;

        //nesta class monta a regra de negocio para as entradas caso necessário. As validações
        public UserService(IRepository<User> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<bool> DeleteAsync(Guid id)
        {
            return await _repository.DeleteAsync(id);
        }

        public async Task<IEnumerable<UserDto>> GetAllAsync()
        {
            var listModel = await _repository.GetAsync();
            return _mapper.Map<IEnumerable<UserDto>>(listModel);
        }

        public async Task<UserDto> GetAsync(Guid id)
        {
            var model = await _repository.GetAsync(id);
            return _mapper.Map<UserDto>(model);
        }

        public async Task<UserDto> PostAsync(UserDto user)
        {
            var model = _mapper.Map<User>(user);            
            var result = await _repository.InsertAsync(model);
            return _mapper.Map<UserDto>(result);
        }

        public async Task<UserDto> PutAsync(UserDto user)
        {
            var model = _mapper.Map<User>(user);            
            var result = await _repository.UpdateAsync(model);
            return _mapper.Map<UserDto>(result);
        }
    }
}
