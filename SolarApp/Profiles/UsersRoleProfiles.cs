using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SolarApp.Profiles
{
    public class UsersRoleProfiles : Profile
    {
        public UsersRoleProfiles()
        {
            CreateMap<Entities.UserRole, Models.UserRoleDTO>();
        }
    }
}
