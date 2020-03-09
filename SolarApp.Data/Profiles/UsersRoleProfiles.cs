using AutoMapper;
using SolarApp.DatabaseCreation.Entities;

namespace SolarApp.Data.Profiles
{
    public class UsersRoleProfiles : Profile
    {
        public UsersRoleProfiles()
        {
            CreateMap<UserRole, Models.UserRoleDTO>();
        }
    }
}
