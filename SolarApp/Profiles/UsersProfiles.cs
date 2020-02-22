using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SolarApp.Profiles
{
    public class UsersProfiles : Profile
    {
        public UsersProfiles()
        {
            CreateMap<Entities.User, Models.UserDTO>();
        }
    }
}
