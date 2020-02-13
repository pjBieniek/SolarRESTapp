﻿using AutoMapper;
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
            CreateMap<Entities.Result, Models.ResultDTO>();
        }
    }
}
