using AutoMapper;
using SolarApp.DatabaseCreation.Entities;

namespace SolarApp.Profiles
{
    public class UsersProfiles : Profile
    {
        public UsersProfiles()
        {
            string pass = "12345";
            CreateMap<User, Models.UserDTO>();
            CreateMap<Models.UserForCreatingDTO, User>()
                .ForMember(u => u.UserPassword, opt => opt.MapFrom(newPassword => pass)); //TODO: password generator
            CreateMap<Models.UserForUpdateDTO, User>();
            CreateMap<Models.UserForLoginDTO, User>();
        }
    }
}
