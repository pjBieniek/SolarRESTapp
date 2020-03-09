using AutoMapper;
using SolarApp.DatabaseCreation.Entities;
using SolarApp.Data.Models;

namespace SolarApp.API.Profiles
{
    public class TeamsProfiles : Profile
    {
        public TeamsProfiles()
        {
            CreateMap<Session, TeamDTO>();
        }
    }
}
