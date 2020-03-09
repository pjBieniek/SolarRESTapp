using AutoMapper;
using SolarApp.DatabaseCreation.Entities;
using SolarApp.Data.Models;


namespace SolarApp.API.Profiles
{
    public class UsersProfiles : Profile
    {
        public UsersProfiles()
        {
            string pass = "12345";
            CreateMap<User, UserDTO>();
            CreateMap<UserForCreatingDTO, User>()
                .ForMember(u => u.UserPassword, opt => opt.MapFrom(newPassword => pass)); //TODO: password generator
            CreateMap<UserForUpdateDTO, User>();
            CreateMap<UserForLoginDTO, User>();
        }
    }
}
