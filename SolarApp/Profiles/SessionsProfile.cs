using AutoMapper;

namespace SolarApp.Profiles
{
    public class SessionsProfile : Profile
    {
        public SessionsProfile()
        {
            CreateMap<Entities.Session, Models.SessionDTO>();
        }
    }
}
