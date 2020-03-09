using AutoMapper;
using SolarApp.DatabaseCreation.Entities;

namespace SolarApp.Data.Profiles
{
    public class SessionsProfile : Profile
    {
        public SessionsProfile()
        {
            CreateMap<Session, Models.SessionDTO>();
        }
    }
}
