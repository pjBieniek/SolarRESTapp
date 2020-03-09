using AutoMapper;
using SolarApp.DatabaseCreation.Entities;

namespace SolarApp.Profiles
{
    public class SessionsProfile : Profile
    {
        public SessionsProfile()
        {
            CreateMap<Session, Models.SessionDTO>();
        }
    }
}
