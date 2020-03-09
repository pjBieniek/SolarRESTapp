using AutoMapper;
using SolarApp.DatabaseCreation.Entities;

namespace SolarApp.Profiles
{
    public class TeamsProfiles : Profile
    {
        public TeamsProfiles()
        {
            CreateMap<Session, Models.TeamDTO>();
        }
    }
}
