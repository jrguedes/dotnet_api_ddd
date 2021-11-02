using API.Domain.Dtos.Endereco;
using API.Domain.Dtos.Municipio;
using API.Domain.Dtos.UF;
using API.Domain.Dtos.User;
using API.Domain.Entities;
using AutoMapper;

namespace API.CrossCutting.Mappings
{
    public class DtoToModelProfile : Profile
    {
        public DtoToModelProfile()
        {
            CreateMap<UserDto, User>().ReverseMap();
            CreateMap<UFDto, UF>().ReverseMap();
            CreateMap<EnderecoDto, Endereco>().ReverseMap();
            CreateMap<MunicipioDto, Municipio>().ReverseMap();
        }
    }
}
