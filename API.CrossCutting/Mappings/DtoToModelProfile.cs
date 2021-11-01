using API.Domain.Dtos.User;
using API.Domain.Entities;
using AutoMapper;

namespace API.CrossCutting.Mappings
{
    public class DtoToModelProfile : Profile
    {
        public DtoToModelProfile()
        {
            CreateMap<UserDto,User>().ReverseMap();
        }
    }
}
