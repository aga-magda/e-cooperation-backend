using AutoMapper;
using Ecooperation_backend.DTOs;
using Ecooperation_backend.Entities;

namespace Ecooperation_backend.Helpers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserDTO>();
            CreateMap<UserDTO, User>();
        }
    }
}
