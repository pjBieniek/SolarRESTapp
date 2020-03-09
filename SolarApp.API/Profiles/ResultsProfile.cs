using AutoMapper;
using SolarApp.DatabaseCreation.Entities;
using SolarApp.Data.Models;


namespace SolarApp.API.Profiles
{
    public class ResultsProfile : Profile
    {
        public ResultsProfile()
        {
            CreateMap<Result, ResultDTO>();
            CreateMap<ResultForCreatingDTO, Result>();
        }
    }
}
