using AutoMapper;
using SolarApp.DatabaseCreation.Entities;
using SolarApp.Data.Models;


namespace SolarApp.API.Profiles
{
    public class SessionsProfile : Profile
    {
        public SessionsProfile()
        {
            CreateMap<Session, SessionDTO>();
        }
    }
}
