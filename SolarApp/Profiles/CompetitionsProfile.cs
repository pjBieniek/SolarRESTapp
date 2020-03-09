using AutoMapper;
using SolarApp.Helpers;
using SolarApp.DatabaseCreation.Entities;

namespace SolarApp.Profiles
{
    public class CompetitionsProfile : Profile
    {
        public CompetitionsProfile()
        {
            CreateMap<Competition, Models.CompetitionDTO>()
                .ForMember(
                    c => c.Date,
                    option => option.MapFrom(src => $"{src.CompetitionDate.ToString("d MMM yyyy")} ({src.CompetitionDate.GetDays()})"));
            CreateMap<Models.CompetitionForCreatingDTO, Competition>();

        }
    }
}
