using AutoMapper;
using SolarApp.DatabaseCreation.Entities;
using SolarApp.Data.Models;


namespace SolarApp.API.Profiles
{
    public class RolesProfile : Profile
    {
        public RolesProfile()
        {
            CreateMap<Role, RoleDTO>();
        }
    }
}
