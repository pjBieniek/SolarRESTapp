using AutoMapper;
using SolarApp.DatabaseCreation.Entities;

namespace SolarApp.Data.Profiles
{
    public class RolesProfile : Profile
    {
        public RolesProfile()
        {
            CreateMap<Role, Models.RoleDTO>();
        }
    }
}
