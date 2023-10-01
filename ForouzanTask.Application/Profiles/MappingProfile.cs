using AutoMapper;
using ForouzanTask.Application.DTOs.User;
using ForouzanTask.Application.DTOs.User.Role;
using ForouzanTask.DataLayer.Entities.Common;

namespace ForouzanTask.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<TbUser, UserDto>().ReverseMap();
            CreateMap<TbRole, RoleListDto>().ReverseMap();

        }
    }
}
