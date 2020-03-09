using AutoMapper;
using SolarApp.Data.Helpers;
using SolarApp.DatabaseCreation.Entities;
using SolarApp.Data.Models;

namespace SolarApp.API.Profiles
{
    public class CompetitionsProfile : Profile
    {
        public CompetitionsProfile()
        {
            CreateMap<Competition, CompetitionDTO>()
                .ForMember(
                    c => c.Date,
                    option => option.MapFrom(src => $"{src.CompetitionDate.ToString("d MMM yyyy")} ({src.CompetitionDate.GetDays()})"));
            CreateMap<CompetitionForCreatingDTO, Competition>();

        }
    }
}
