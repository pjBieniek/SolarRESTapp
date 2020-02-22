using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SolarApp.Profiles
{
    public class TeamsProfiles : Profile
    {
        public TeamsProfiles()
        {
            CreateMap<Entities.Session, Models.TeamDTO>();
        }
    }
}
