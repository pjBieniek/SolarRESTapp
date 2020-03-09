using AutoMapper;
using SolarApp.DatabaseCreation.Entities;
using SolarApp.Data.Models;

namespace SolarApp.API.Profiles
{
    public class UsersRoleProfiles : Profile
    {
        public UsersRoleProfiles()
        {
            CreateMap<UserRole, UserRoleDTO>();
        }
    }
}
