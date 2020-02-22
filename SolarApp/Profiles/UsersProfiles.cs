using AutoMapper;

namespace SolarApp.Profiles
{
    public class UsersProfiles : Profile
    {
        public UsersProfiles()
        {
            string pass = "12345";
            CreateMap<Entities.User, Models.UserDTO>();
            CreateMap<Models.UserForCreatingDTO, Entities.User>()
                .ForMember(u => u.UserPassword, opt => opt.MapFrom(newPassword => pass)); //TODO: password generator
        }
    }
}
