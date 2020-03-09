using AutoMapper;
using SolarApp.DatabaseCreation.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SolarApp.Profiles
{
    public class ResultsProfile : Profile
    {
        public ResultsProfile()
        {
            CreateMap<Result, Models.ResultDTO>();
            CreateMap<Models.ResultForCreatingDTO, Result>();
        }
    }
}
