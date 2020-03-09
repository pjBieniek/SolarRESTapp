using AutoMapper;
using SolarApp.DatabaseCreation.Entities;

namespace SolarApp.Data.Profiles
{
    public class TeamsProfiles : Profile
    {
        public TeamsProfiles()
        {
            CreateMap<Session, Models.TeamDTO>();
        }
    }
}
