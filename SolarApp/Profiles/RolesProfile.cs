using AutoMapper;

namespace SolarApp.Profiles
{
    public class RolesProfile : Profile
    {
        public RolesProfile()
        {
            CreateMap<Entities.Role, Models.RoleDTO>();
        }
    }
}
