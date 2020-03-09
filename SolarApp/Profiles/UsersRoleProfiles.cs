using AutoMapper;
using SolarApp.DatabaseCreation.Entities;

namespace SolarApp.Profiles
{
    public class UsersRoleProfiles : Profile
    {
        public UsersRoleProfiles()
        {
            CreateMap<UserRole, Models.UserRoleDTO>();
        }
    }
}
