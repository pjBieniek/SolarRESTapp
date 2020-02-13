using AutoMapper;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using SolarApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SolarApp.Controllers
{
    [ApiController]
    //[Route("api/results")]
    public class ResultsController
    {
        private readonly ISolarDbRepository _solarDbRepository;
        private readonly IMapper _mapper;

        public ResultsController(ISolarDbRepository solarDbRepository, IMapper mapper)
        {
            _solarDbRepository = solarDbRepository ??
                throw new ArgumentNullException(nameof(solarDbRepository));
            _mapper = mapper ??
                throw new ArgumentNullException(nameof(mapper));
        }





    }
}
