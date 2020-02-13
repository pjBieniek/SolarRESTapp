using AutoMapper;
using SolarApp.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SolarApp.Profiles
{
    public class CompetitionsProfile : Profile
    {
        public CompetitionsProfile()
        {
            CreateMap<Entities.Competition, Models.CompetitionDTO>()
                .ForMember(
                    c => c.Date,
                    option => option.MapFrom(src => $"{src.CompetitionDate.ToString("d MMM yyyy")} ({src.CompetitionDate.GetDays()})"));
        }
    }
}
